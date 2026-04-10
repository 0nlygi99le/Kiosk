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
        /// <summary>
        /// [private]
        /// </summary>
        private int _count;
        private decimal _totalPrice;

        // 실제 화면(UI) 반영 전용 메서드 
        private void SetlblCount()
        {
            lblCount.Text = _count.ToString();
        }

        private void SetTotalPrice()
        {
            lblTotalPrice.Text = $"{_totalPrice:#,##0}원";
        }

        /// <summary>
        /// [Public]
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();

            /* [생성자에서 메서드 실행 이유]     
            생성 직후의 아직 외부 값이 들어오지 않았더라도 
            자기 내부 필드 기준으로 화면(UI)을 초기화한 상태가 됨  */
            SetlblCount();
            SetTotalPrice(); 

        }

        // Form UI에서 Border 변경을 위한 속성 정의
        public Color BorderColor { get => roundedPanel1.BorderColor; set => roundedPanel1.BorderColor = value; }
        public int BorderWidth { get => roundedPanel1.BorderWidth; set => roundedPanel1.BorderWidth = value; }


        // 각각 Setter는 Form1으로부터 값을 전달 받을 것.
        public int Count
        {
            get { return _count; }
            set 
            { 
                _count = value;
                SetlblCount();
            }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set 
            { 
                _totalPrice = value;
                SetTotalPrice();
            }
        }
    }
}
