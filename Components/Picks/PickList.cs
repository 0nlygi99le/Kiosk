using KioskByGT.Models;
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

/* PickList 핵심 요약
- AddItem(Product)는 Product를 받아 PickItem으로 관리하는 시작점
- _pickItems는 장바구니 데이터 저장소, flpnl.Controls는 장바구니 UI 저장소
- 같은 상품이면 Count++, 없으면 new PickItem
- PickItem의 개별 변화는 CountChanged, DeleteClicked로 올라옴
- PickList는 이를 받아 ItemValueChanged 하나로 외부에 전체 상태를 다시 전달
 */

namespace KioskByGT.Components.Picks
{
    public delegate void ItemValueChangedHandler(List<PickItem> pickItems);

    [DefaultEvent("ItemValueChanged")]
    public partial class PickList : UserControl
    {
        //PickList의 내부 데이터 저장소
        // - PickItem UI 자체를 저장
        private List<PickItem> _pickItems = new();

        // PickList의 대표 이벤트
        // - 내부 PickItem들의 상태 변화가 발생 시 현재 장바구니 전체 상태를 외부(Form 등)에 전달
        public event ItemValueChangedHandler? ItemValueChanged;

        //PickList의 대표 이벤트를 실제로 발생시키는 메서드
        // - 내부 상태가 바뀌었을 때 현재 _pickItems 전체를 외부에 알림
        private void RaiseItemValueChanged() => ItemValueChanged?.Invoke(_pickItems);

        public PickList()
        {
            InitializeComponent();
        }

        // Form UI에서 Border 변경을 위한 속성 정의
        public Color BorderColor { get => roundedPanel1.BorderColor; set => roundedPanel1.BorderColor = value; }
        public int BorderWidth { get => roundedPanel1.BorderWidth; set => roundedPanel1.BorderWidth = value; }

        public void AddItem(Product product)
        {
            // 같은 상품이 이미 장바구니에 존재하는지 검사
            PickItem pickItem =  _pickItems.FirstOrDefault(item => item.ID == product.ID);
            if (pickItem != null)
            {
                // 새 PickItem을 만들지 않고 기존 항목의 수량만 증가
                pickItem.Count++;
                return;
            }

            // PickItem이 존재하지 않는 경우
            // 상품이 존재하는데 동일 상품을 다시 누르게 되면 다시 담기는 상황이 발생함.
            pickItem = new PickItem
            {
                ID = product.ID,
                Title = product.Title,
                DefaultPrice = product.Price,
                Image = product.Image!,
                Count = 1,
            };

            pickItem.DeleteClicked += PickItem_DeleteClicked;
            pickItem.CountChanged += PickItem_CountChanged;
            _pickItems.Add(pickItem);
            flpnl.Controls.Add(pickItem);

            RaiseItemValueChanged();
        }

        private void PickItem_CountChanged(object? sender, EventArgs e)
        {
            RaiseItemValueChanged();    
        }

        private void PickItem_DeleteClicked(object? sender, EventArgs e)
        {
            PickItem pickItem = (PickItem)sender;   
            _pickItems.Remove(pickItem);
            flpnl.Controls.Remove(pickItem);

            RaiseItemValueChanged();        }

        public List<ReceiptItemData> GetReceiptItemDatas()
        {
            // 리턴할 때 보내줄 List정의
            List<ReceiptItemData> returnReceipt = new List<ReceiptItemData>();

            // 반복문으로 현재 장바구니의 요소를 하나씩 꺼냄
            foreach (PickItem pickItem in _pickItems)
            {
                // 장바구니 요소를 ReceiptItemData로 바꿔줄 핵심 로직
                ReceiptItemData receiptItemData = new ReceiptItemData
                {
                    Title = pickItem.Title,
                    Count = pickItem.Count,
                    Price = pickItem.DefaultPrice,
                    SumPrice = pickItem.DefaultPrice * pickItem.Count
                };

                // 장바구니 요소 하나씩 정제한 후 returnReceipt에 넣어줌 
                returnReceipt.Add(receiptItemData);
            }

            return returnReceipt;
        }

        // 취소하기 버튼을 눌렀을 때 호출할 메서드
        // 내부 패널, 저장소를 Clear하고, 장바구니의 내부 변화를 외부로 알림.
        public void CancelClear()
        {
            _pickItems.Clear();
            flpnl.Controls.Clear();
            RaiseItemValueChanged();
        }
    }
}








