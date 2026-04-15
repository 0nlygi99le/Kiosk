using KioskByGT.Models.Receipts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskByGT.Components.Receipts
{
    public partial class ReceiptItemControl : UserControl
    {
        public ReceiptItemControl()
        {
            InitializeComponent();
        }

        public void SetData(ReceiptItemData receiptItemData)
        {
            lblTitle.Text = receiptItemData.Title;
            lblCount.Text = $"{receiptItemData.Count}개"; // text가 받을 값은 string형이므로 형변환을 해주면서 가공
            lblSumPrice.Text = $"{receiptItemData.SumPrice: #,##0}원"; 
        }

    }
}
