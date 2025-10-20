![화면이미지](Resources/screen01.png)

# 출처
**youtube - Moo ICT**  <br>
https://www.youtube.com/watch?v=fdw-HGIMZFY&list=PLqOxH0kcZ8wPB5ydzHw81hGDdO85b-JsR&index=12

# keyisdown
키를 누를 때 발생

# keyisup
키를 뗄 때 발생

# Control 
this.Controls → 폼(Form1)에 추가된 모든 컨트롤 모음
```csharp
foreach(Control x in this.Controls)
{
    if(x is PictureBox)<br>
    {
        if((string)x.Tag == "coin" && x.Visible == true)<br>
        { }
    }
}
```
foreach → 폼 안에 있는 모든 컨트롤을 순회 <br>
if(x is PictureBox) → 현재 컨트롤이 PictureBox 타입이면 처리<br>

# Environment.NewLine
C#에서 운영체제에 맞는 줄바꿈 문자를 의미
- Windows → \r\n
- Linux/macOS → \n