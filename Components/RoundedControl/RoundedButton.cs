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
    [DefaultEvent("ButtonClick")]
    public partial class RoundedButton : UserControl
    {
        // 외부(form1)가 구독할 대표 이벤트 정의
        public event EventHandler? ButtonClick;
        public RoundedButton()
        {
            InitializeComponent();

            // 생성 시점에 내부 컨트롤의 click 이벤트를 모으는 로직 실행
            AddButtonClick(this);
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

        // ProductCard의 AddclickedEvent와 같은 개념
        // 자신 + 내부 자식 컨트롤의 click이벤트를 모두 ButtonCliked으로 연결함.
        private void AddButtonClick(Control parentControl)
        {
            // parentControl 자신 클릭 시 대표 이벤트 발행
            parentControl.Click += (_, __) => ButtonClick?.Invoke(this, EventArgs.Empty);
            
            // 자식 컨트롤들에도 적용하기 위한 재귀 메서드
            foreach(Control control in parentControl.Controls)
            {
                AddButtonClick(control);
            }
        }
    }
}
