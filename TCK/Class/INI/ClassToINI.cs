using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCK.Class.INI
{
    /// <summary>
    /// 부모로 상속하여 INI파일을 쉽게 쓸수 있다.
    /// </summary>

    public class ClassToINI
    {
        /// <summary>
        /// INI 저장가능 Type List
        /// </summary>
        protected List<Type> INIReadAndWriteOkTypeList = new List<Type>() { typeof(int), typeof(float), typeof(double), typeof(string), typeof(bool)};

        /// <summary>
        /// INI 사용 여부 Attribute
        /// </summary>
        /// [UseINI(false)] 
        /// public int test {get;set;} = 10;
        protected class UseINI : System.Attribute
        {
            public bool AttributeUse { get; set; }
            public UseINI(bool use)
            {
                this.AttributeUse = use;
            }
        }

        /// <summary>
        /// INI Section Name Attribute 
        /// </summary>          
        /// [SectionName("TestValue")] 
        /// public int test {get;set;} = 10;
        protected class SectionName : System.Attribute
        {
            public string IsSectionName { get; set; }
            public SectionName(string str)
            {
                this.IsSectionName = str;
            }
        }

        /// <summary>
        /// INI File Info
        /// </summary>
        private FileInfo mFile = default(FileInfo);                         
        private string mSectionName = string.Empty;

        /// <summary>
        /// Default Section Name
        /// </summary>
        [UseINI(false)]
        public string IsSectionName
        {
            get
            {
                if (string.IsNullOrEmpty(mSectionName))
                {
                    string className = this.GetType().Name;
                    return className;
                }
                return mSectionName;
            }
            set { mSectionName = value; }
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// IniWriteValue
        /// </summary>
        /// <param name="Section">Section 네임</param>
        /// <param name="Key">Key</param>
        /// <param name="Value">Value</param>
        private void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, mFile.FullName);
        }

        /// <summary>
        /// IniReadValue
        /// </summary>
        /// <param name="Section">Section 네임</param>
        /// <param name="Key">Key</param>
        /// <returns></returns>
        private string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, mFile.FullName);
            return temp.ToString();
        }
          
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="fileInfo">읽고 쓸 파일 경로(ex> new FileInfo("/config.ini"))</param>
        public ClassToINI(FileInfo fileInfo)
        {
            mFile = fileInfo;
            //해당 경로에 파일이 없을경우 Default값으로 파일 생성
            // public int test{get;set;} = 10;
            // 위와 같이 Default값을 지정할수 있다.
            if (mFile.Exists == false)
            {
                SaveINI();
            }
            else
            {
                LoadINI();
            }
        }        

        /// <summary>
        /// Class 안에 있는 Property를 이용하여 값 저장
        /// </summary>
        /// <returns></returns>
        public bool SaveINI()
        {                  
            var Properties = TypeDescriptor.GetProperties(this.GetType());
            foreach (PropertyDescriptor item in Properties)
            {
                bool bUseINI = true;
                string sectionName = IsSectionName;
                // Properti에 Attribute를 검색
                foreach (Attribute attribute in item.Attributes)
                {
                    var attributeSectionName = attribute as SectionName;
                    var attributeUseIni = attribute as UseINI;
                    //SectionName attribute가 존재할 경우 넣어준다
                    if (attributeSectionName != null)
                    {
                        sectionName = attributeSectionName.IsSectionName;
                    }
                    //UseIni attribute가 존재할 사용 여부를 결정한다.
                    if (attributeUseIni != null)
                    {
                        bUseINI = attributeUseIni.AttributeUse;
                    }
                }
                // attribute INI로 사용하지 않게 설정할 경우 파일에 저장하지 않고 넘어 간다.  
                if (bUseINI == false)
                {
                    continue;                                                          
                }
                foreach (var type in INIReadAndWriteOkTypeList)
                {
                    if (type == item.PropertyType)
                    {
                        string inputValue = string.Empty;
                        if (type == typeof(bool))
                        {
                            inputValue = System.Convert.ToInt32(item.GetValue(this)).ToString();
                        }
                        else
                        {
                            inputValue = item.GetValue(this).ToString();     
                        }
                        
                        IniWriteValue(sectionName, item.Name, inputValue);
                        break;
                    }
                }
                             
            }
            return true;
        }

        /// <summary>
        /// 파일을 읽어서 Class 안에 있는 Property에 값을 채워 넣는다
        /// </summary>
        /// <returns></returns>
        public bool LoadINI()
        {
            var Properties = TypeDescriptor.GetProperties(this.GetType());
            foreach (PropertyDescriptor item in Properties)
            {
                bool bUseINI = true;
                string sectionName = IsSectionName;
                foreach (Attribute attribute in item.Attributes)
                {
                    var attributeSectionName = attribute as SectionName;
                    var attributeUseIni = attribute as UseINI;
                    if (attributeSectionName != null)
                    {
                        sectionName = attributeSectionName.IsSectionName;
                    }
                    if (attributeUseIni != null)
                    {
                        bUseINI = attributeUseIni.AttributeUse;
                    }
                }
                if (bUseINI == false)
                {
                    continue;
                }
                foreach (var type in INIReadAndWriteOkTypeList)
                {
                    if (type == item.PropertyType)
                    {
                        var readValue = IniReadValue(sectionName, item.Name);
                        var value = Convert(readValue, item.PropertyType);
                        item.SetValue(this, value);
                        break;
                    }
                }                   
            }
            return true;
        }            

        /// <summary>
        /// 동적 Type 변환 함수
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public static dynamic Convert(dynamic source, Type dest)
        {
            dynamic returnValue;
            try
            {
                if (dest == typeof(bool))
                {
                    int intValue = System.Convert.ToInt32(source);
                    returnValue = System.Convert.ToBoolean(intValue);
                    return returnValue;
                }
                returnValue = System.Convert.ChangeType(source, dest);
            }
            catch
            {
                returnValue = null;
            }
            return returnValue;
        }
    }
}
