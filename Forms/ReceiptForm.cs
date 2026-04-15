using KioskByGT.Components.Products;
using KioskByGT.Components.Receipts;
using KioskByGT.Models.Receipts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskByGT.Forms
{
    public partial class ReceiptForm : Form
    {
        private readonly ReceiptData _receiptData;
        public ReceiptForm(ReceiptData receiptData)
        {
            InitializeComponent();

            _receiptData = receiptData;

            Load += ReceiptForm_Load;
        }

        private void ReceiptForm_Load(object? sender, EventArgs e)
        {
            // 내부 컨트롤에 값부여

            // 헤더
            lblStoreName.Text = _receiptData.StoreName;
            lblDescription.Text = _receiptData.StoreDescription;
            lblOrderNumber.Text = $"주문번호: {_receiptData.OrderNumber}";
            lblOrderTime.Text = $"주문시간: {_receiptData.OrderTime: yyyy-MM-dd-HH.mm.ss}";


            /* 중간 계획
             [ProductList의 ProductCard 동적 생성 원리]
             - "상품 데이터 목록" -> "ProductCard 목록" 으로 바꾸어 화면에 보여주는 구조
             1. ProductList는 자신의 데이터 컬렉션인 Items를 순회(foreach)함.
             2. foreach는 Items 안의 요소 하나(item)를 꺼내며 순회함.
             3. foreach내부 동작
                - new ProductCard()로 UI 컨트롤(ProductCard)을 하나 생성함.
                - item에 들어있는 값을 생성한 ProductCard에 할당.
                 (ProductCard는 이 값을 받고 UI에 반영할 속성들이 정의되어있음.)
             4. 마지막으로 flpnl.Controls.Add(productCard)로 패널에 추가함.

             [ReceiptForm에서 만들 ReceiptItemControl의 설계 구조]
             - "영수증 데이터 목록" -> "ReceiptItemControl 목록" 으로 바꾸어 화면에 보여주는 구조
             1. ReceiptForm은 _receiptData.Items(List<ReceiptItemData>)를 순회함.
             2. foreach로 _receiptData안에서 요소 하나(item)을 빼내어서 순회.
             3. foreach 내부 동작
               - new ReceiptItemControl()로 영수증 한 줄 UI(ReceiptItemControl)를 하나 생성함
               - item을 전달해서 ReceiptItemControl에서 받고 값을 주입 
                (ReceiptItemControl은 값을 관리하는 컨트롤이 아니라, 보여주기만 할 것임. 즉, 표시 전용 컨트롤임.)
                (때문에 ReceiptItemControl에서는 개별 속성 여러개를 정의하지 않고,
                item을 받아오는 "매서드"를 정의해서 받아온 데이터를 한번에 주입하는 방식을 선택할 것임.)
             4. 마지막으로 flpnlItems.Controls.Add(control)로 패널에 추가함

             [핵심 차이점]
             1. 데이터 주입 방식의 차이
              - ProductCard: 속성에 값을 넣는 방식
              - ReceiptItemControl: SetData(...) 메서드로 값을 넣는 방식
             2. 역할의 차이
              - ProductCard: 상품을 보여주고 클릭 입력의 시작점이 될 수 있는 UI
              - ReceiptItemControl: 이미 확정된 영수증 데이터를 보여주는 표시 전용 UI

             [정리]
             ReceiptItemControl은 ProductCard, PickItem처럼 상위 객체가 런타임에 new를 이용해서 생성
             그러나 데이터 1개를 받아 UI 1개를 채우는 표시용 컨트롤이라는 점에서 ProductCard와 더 유사. 
             PickItem은 표시 기능에 더해 수량 변경, 삭제와 같은 편집 기능을 더 지닌 컨트롤임. */

            // 중간
            foreach (ReceiptItemData item in _receiptData.Items)
            {
                ReceiptItemControl receiptItemControl = new ReceiptItemControl();

                receiptItemControl.SetData(item);

                flpnlItems.Controls.Add(receiptItemControl);
            }

            // 하단
            lblTotalCount.Text = $"총 수량: {_receiptData.TotalCount}개";
            lblTotalPrice.Text = $"총 금액: {_receiptData.TotalPrice: #,##0}원";
        }            
    }
}



















