using DocumentFormat.OpenXml.Spreadsheet;
using KioskByGT.Components;
using KioskByGT.Components.Picks;
using KioskByGT.Components.Products;
using KioskByGT.Forms;
using KioskByGT.Models.Receipts;
using System.ComponentModel;
using System.Drawing.Text;


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

        /// <summary>
        /// [결제하기 버튼 클릭 핸들러]
        /// - 사용자가 결제하기 버튼을 누르면 실행될 로직
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roundedButtonPay_ButtonClick(object sender, EventArgs e)
        {
            /* [설계 계획]
             * 1. PickList에게 현재 장바구니 상태를 받아옴.
             *   - Product를 만들었던 거 처럼 데이터만 정제해서 보낼 것임.
             *   - 장바구니 요소 하나씩 전달받을 데이터 모델을 만듬 -> ReceiptItemData
             *   - form1에서 영수증의 데이터를 모조리 정의 
             *     -> 나중에 분리를 하던 일단 form에서 정의해둠 
             *     -> 먼저 영수증의 전체 모양을 데이터 모델로 정의할 것 -> ReceiptData
             *     
             * 2. ReceiptForm에게 전달 
             *   - form1에서 Receiptdata를 직접 만들고 넘겨줌.
             *     (나중에 분리를 하던 일단 먼저 만듦
             *   - ReceiptForm를 생성하고 Receiptdata를 넘겨줌.
             * 
             */

            // 현재 장바구니 상태를 받아옴 
            List<ReceiptItemData> receiptItemDatas = pickList.GetReceiptItemDatas();

            // 영수증 전체 모양을 new로 생성
            ReceiptData receiptData = new ReceiptData
            {
                // 
                StoreName = "경자카야",
                StoreDescription = "주문하신 음식입니다~",
                OrderNumber = DateTime.Now.ToString("yyyyMMddHHmmss"),
                OrderTime = DateTime.Now,

                Items = receiptItemDatas,

                TotalCount = receiptItemDatas.Sum(item => item.Count), 
                TotalPrice = receiptItemDatas.Sum((item) => item.Price),         
            };

            ReceiptForm receiptForm = new ReceiptForm(receiptData);

            receiptForm.ShowDialog();
        }
    }
}


