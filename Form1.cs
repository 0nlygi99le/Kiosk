using KioskByGT.Components;
using KioskByGT.Components.Picks;
using KioskByGT.Components.Products;
using KioskByGT.Forms;
using System.ComponentModel;


namespace KioskByGT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void produstList1_ItemClicked(object sender, KioskByGT.Models.Product e)
        {
            //ProductCard와 PickList의 중계자 역할 
            pickList.AddItem(e);
        }

        private void pickList_ItemValueChanged(System.Collections.Generic.List<KioskByGT.Components.Picks.PickItem> pickItems)
        {
            // PickList의 이벤트 구독처리 
            // - OrderSummaryControl에 값을 할당 준비 완료. 
            int TotalCount = 0;
            decimal TotalPrice = 0; 

            foreach (var item in pickItems) 
            {
                TotalCount += item.Count;
                TotalPrice += item.DefaultPrice * item.Count;
            }

            // OrderSummaryControl에 값을 할당
            // - UI에서 PickList의 현재 상황에 따른 값 반영 완료.
            orderSummaryControl1.Count = TotalCount; 
            orderSummaryControl1.TotalPrice = TotalPrice;   
        }
    }
}


