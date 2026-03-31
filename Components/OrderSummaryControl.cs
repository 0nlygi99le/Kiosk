using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskByGT.Components
{
    public partial class OrderSummaryControl : UserControl
    {
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        // Form UI에서 Border 변경을 위한 속성 정의
        public Color BorderColor { get => roundedPanel1.BorederColor; set => roundedPanel1.BorederColor = value; }
        public int BorderWidth { get => roundedPanel1.BorederWidth; set => roundedPanel1.BorederWidth = value; }


        private int _count;
        private decimal _totalPrice;


        // 빌드 시 lblCount,lblTotalPrice 초기화 되지 않음.
        // 해결책:
        // 초기화하는 문장을 메서드로 따로 빼서 만들고, 생성자에서 호출하는 방식으로 만들 것임.
        public int Count
        {
            get { return _count; }
            set 
            { 
                _count = value; 
                lblCount.Text = _count.ToString();  
            }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set 
            { 
                _totalPrice = value;
                lblTotalPrice.Text = $"{_totalPrice:#,##0}원";
            }
        }
    }
}
