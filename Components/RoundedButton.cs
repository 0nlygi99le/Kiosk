using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* [RoundedButton]
// - 버튼을 매번 따로 만들지 않고 하나의 UserControl을 재사용하기 위한 컨트롤
// - 내부의 Label(Text) 값만 변경해서 버튼 역할을 구분함
 - BorderColor(테두리 색상), BorderWidth(두께)를 외부(Form 디자이너)에서 설정 가능하도록 속성으로 작성. */

namespace KioskByGT.Components
{
    public partial class RoundedButton : UserControl
    {
        public RoundedButton()
        {
            InitializeComponent();
        }

        public Color BorderColor { get => roundedPanel1.BorderColor; set => roundedPanel1.BorderColor = value; }
        public int BorderWidth { get => roundedPanel1.BorderWidth; set => roundedPanel1.BorderWidth = value; }


        /* [디자이너에서 Text를 사용하기 위한 설정]
        1. 디자이너에서 Text 속성이 보이지 않음
         - 재정의를 통해 Text 속성을 내부 lblText와 연결할 것임.
         - 즉, RoundedButton.Text를 바꾸면 내부 Label의 글자도 함께 바뀌도록 만든 것
         -> public override string Text { get => lblText.Text; set => lblText.Text = value; } 작성

        2. Text가 여전히 보이지 않음.
          - 속성창에서 보이지 않게 설정됨을 의심
          - 유저컨트롤 정의에서 [Browsable(false)]로 지정된 것을 볼 수 있음
             -> 의미: "속성창에 표시하지 않음"
          -> [Browsable(true)]를 로직에 작성

        3. 빌드 시 저장이 안되고 초기화되는 현상 발생
          - 직렬화 문제임을 예상 후 유저 컨트롤 정의부에서 확인 시 hidden으로 설정 됨.
          - visible로 바꿔줌
          -> [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        */


        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text { get => lblText.Text; set => lblText.Text = value; }
    }
}
