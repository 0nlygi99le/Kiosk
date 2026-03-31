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
            SetlblCount();
            SetTotalPrice();

        }

        // Form UI에서 Border 변경을 위한 속성 정의
        public Color BorderColor { get => roundedPanel1.BorederColor; set => roundedPanel1.BorederColor = value; }
        public int BorderWidth { get => roundedPanel1.BorederWidth; set => roundedPanel1.BorederWidth = value; }


        // Count, TotalPrice의 Setter는 Form1으로부터 값을 전달 받을 것임. 
        public int Count
        {
            get { return _count; }
            set 
            { 
                _count = value;

                // lblCount.Text = _count.ToString();  -> 초기화문 따로 뺄거임. - 아래처럼 매서드 호출로 변환
                SetlblCount();
            }
        }

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set 
            { 
                _totalPrice = value;

                // lblTotalPrice.Text = $"{_totalPrice:#,##0}원"; -> 초기화문 따로 뺄거임.
                SetTotalPrice();
            }
        }
    }
}
