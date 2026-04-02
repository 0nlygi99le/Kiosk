using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// Button 컨트롤을 하나 만들어서 Label만 바꿔서 재사용하는 목적
// - Label에 값만 달리하여 구분하려함.
namespace KioskByGT.Components
{
    public partial class RoundedButton : UserControl
    {
        public RoundedButton()
        {
            InitializeComponent();
        }

        // Form UI에서 Border 변경을 위한 속성 정의
        public Color BorderColor { get => roundedPanel1.BorederColor; set => roundedPanel1.BorederColor = value; }
        public int BorderWidth { get => roundedPanel1.BorederWidth; set => roundedPanel1.BorederWidth = value; }

        // 화면에서 Text를 부여하려했더니 Text가 속성창에 없음
        // - override or new로 할거임.
        public override string Text { get => lblText.Text; set => lblText.Text = value; }


    }
}
