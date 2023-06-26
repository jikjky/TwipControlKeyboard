# TCK
배포파일 :[Download](https://github.com/jikjky/TwipControlKeyboard/raw/master/TCK.zip)


# 프로그램 개요

시청자가 특정 금액을 후원을 하면 자신의 컴퓨터에 키를 조작하는 프로그램


- 특정 키를 누른다
- 특정 키를 일정시간 못누르게 된다
- 마우스를 움직인다


# 프로그램 개요

시청자가 특정 금액을 후원을 하면 자신의 컴퓨터에 키를 조작하는 프로그램


- 특정 키를 누른다
- 특정 키를 일정시간 못누르게 된다
- 마우스를 움직인다


# 사용법
![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597586025458_image.png)


초기 실행화면


# Twip Alert Box 추가
![](https://paper-attachments.dropbox.com/s_0F03E0F0A1E6BDFA40F69A5B79E693EC3628948FAE994AF50EDF512A154B821A_1597413410080_image.png)


http://twip.kr/ 접속

![](https://paper-attachments.dropbox.com/s_0F03E0F0A1E6BDFA40F69A5B79E693EC3628948FAE994AF50EDF512A154B821A_1597413444348_image.png)


로그인

![](https://paper-attachments.dropbox.com/s_0F03E0F0A1E6BDFA40F69A5B79E693EC3628948FAE994AF50EDF512A154B821A_1597413496362_image.png)


대시보드 → Alert Box → 복사하기 클릭

![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597586084390_image.png)


상단 Twip 옆 Text Box에 붙여넣기 후 Save 버튼 클릭


# Toonation Alert Box 추가


![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597586157886_image.png)


https://toon.at/ko/index 접속후 스트리머 로그인


![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597586245210_image.png)


위젯 → 알림창 → 상단에 기봇 위젯 URL 혹은 세부 위젯 URL(후원  알람 위젯)을 복사후

![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597586319257_image.png)


상단 Toonation 옆 Text Box에 붙여넣기 후 Save 버튼 클릭


# 조건 설정

Add 버튼으로 조건추가
Edit 버튼으로 기존 조건 변경(클릭한 아이템)
Delete 버튼으로 조건 삭제(클릭한 아이템)

Start 버튼 조건 감시 시작
Stop 버튼 조건 감시 종료


![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597820912776_image.png)


Add, Edit 버튼 클릭시 화면

Click 조건 발동시 키를 누른다
NoneClick 조건 발동시 키를 못누르게 된다
Move 마우스를 Direction에 설정한 방향으로 Time만큼 움직인다(Speed로 속도 조절)
Abs Move x, y 좌표로 바로 마우스를 이동한다

Key 발동할 Key(한글자만됨)(LButton, RButton은 각각 마우스 좌,우클릭)

Ctrl Alt Shift 함깨 누를 키 선택

Direction Move시 이동할 방향

Speed 이동 속도

X Abs 이동시 x 좌표

Y Abs 이동시 y 좌표

Roulette 룰렛 발동 글자

Amount 후원 금액 조건

Time 적용시간(몇초간 누르는지, 못누르게 되는 시간, 이동시간) (ms) (1000은 1초)

Delay 후원 받고 나서 실행 되기 까지 Delay Time(ms) (1000은 1초)




# Twip Roulette 설정


![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597586591041_image.png)


슬롯 머신 시간을

![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597586629703_image.png)


상단 Roulette Delay 옆 Text Box에 넣고 Save를 누른다(단위 ms 7초는 7000)


![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597586487326_image.png)


Twip Roulette 에 아이템 이름을 (위의 그림에 는 asd를)

![](https://paper-attachments.dropbox.com/s_DCF1AF9F90C05014EF8DE1590ED0164983D92B04190066612622FBBA04F2947C_1597821186622_image.png)


조건 설정의 Roulette에 그대로 적어주면 해당 아이템이 걸렸을때 실행된다.



# TIP
- 같은 금액으로 설정하고 Delay를 줘서 여러 가지를 제어 가능
- 마우스 무브를 같은금액으로 Left와 Top을 같이 설정하면 좌상단으로 대각선 이동함
- List Box(조건 항목)을 더블 클릭하면 바로 Edit창으로 가짐



# 버그 및 추후 업데이트 예정사항


- 팔로우 알람 설정되있으면 Amount를 0으로 설정한 조건이 실행됨
- 후원 말고 비트나 다른 알람도 적용됨 (ex 호스팅이 1000명 왔는데 조건이 1000인게 있으면 조건 실행됨)
- 2,147,483,647원 이상 후원하면 안됨…
- Twip, Toonation에서 형식을 바꾸면 안될수도 있음…
- Twip, Toonation 조건을 따로 가지게?
