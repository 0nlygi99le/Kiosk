using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskByGT.Components
{
    public partial class HeaderControl : UserControl
    {
        public HeaderControl()
        {
            InitializeComponent();
        }


        [Category("HeaderControl")] [Description("매점 이름")]
        public string Title 
        { 
            get => lblTitle.Text; 
            set => lblTitle.Text = value; 
        }

        [Category("HeaderControl")] [Description("매점 소개")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]   // 여러줄로 텍스트 입력을 가능해주는 속성
        public string Description 
        { 
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }
    }
}
