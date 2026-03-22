using KioskByGT.Components.Products;
using KioskByGT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* [PickItem 개요]
 * - 표현 및 사용자 입력만 담당함.
 * - 즉, 화면에 표시될 직접적인 UI와 컴파일에서 할 수 있는 사용자의 입력만 담당함
 * - 이후 실제 장바구니 목록/삭제/합계 계산은 PickList(부모 컨테이너)가 담당할 것임.
 */

namespace KioskByGT.Components.Picks
{
    public partial class PickItem : UserControl
    {
        public PickItem()
        {

        InitializeComponent();
            Count = 1; // 최소 수량 기본값 - Count 초기값이 0이면 DefaultPrice 설정 시 0원이 나올 수 있어서 그것을 방지하는 역할
        }

        /* [Event]
         - "자식(PickItem) → 부모(PickList) 통신"
         - PickItem에서 요청/변경 신호를 담당
        */
        // 삭제 "요청" 이벤트
        public event EventHandler DeleteClicked;

        // 수량 변경 이벤트
        public event EventHandler CountChanged;


        // Feild (원본 데이터 보관: 계산용)
        private int _count;
        private decimal _defaultPrice;

        // Property  (외부 입력에서 입력받을 값만 정의)
        public int ID { get; set; }
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public Image Image { get => picBox.Image; set => picBox.Image = value; }

        public int Count
        {
            get { return _count; }
            set
            {
                if (value < 1) return;
                _count = value;
                lblCount.Text = _count.ToString();

                // 합계는 "파생 결과"이므로 내부에서 일관되게 계산/표시
                SetSumPrice();

                // 부모에게 "수량 변경"만 알림 → 부모가 총액/요약 갱신
                CountChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public decimal DefaultPrice
        {
            get { return _defaultPrice; }
            set
            {
                _defaultPrice = value;
                SetSumPrice(); // 가격 변경 시 합계 표시 갱신
            }
        }

        // [Method]
        // - "합계 표시(내부 전용)"
        // - lblSumPrice는 내부 계산 결과(표시 전용)이므로 외부에 public으로 열지 않음
        private void SetSumPrice()
        {
            lblSumPrice.Text = (_defaultPrice * _count).ToString("#,###") + "원";
        }

        // Click Event
        private void btnDown_Click(object sender, EventArgs e)
        {
            Count--;
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            Count++;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // EventArgs.Empty = 추가 전달 데이터(페이로드) 없음.
            // 어떤 항목인지 식별은 sender(this) 또는 PickItem.ID로 가능.
            DeleteClicked?.Invoke(this, EventArgs.Empty);   
        }
    }
}



