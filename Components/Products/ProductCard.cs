using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskByGT.Components.Products
{
    /// <summary>
    ///[IProductCard 인터페이스 정의]
    /// ProductCard가 가져야 할 속성(ID/Title/Price/Image) 목록을 명시
    /// - 카드 구현체가 달라도(IProductCard로 받으면) ID/Title/Price/Image는 동일한 방식으로 처리 가능
    /// - 이벤트: 외부가 구독할 수 있는 이벤트 멤버를 제공
    /// </summary>
    public interface IProductCard
    {       
        event EventHandler<IProductCard> Clicked;
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Image Image { get; set; }
    }

    /// <summary>
    /// [ProductCard 클래스 정의, IProductCard를 구현]
    /// - WinForms에서 화면에 배치 가능한 “제품 카드 UI(UserControl)” 구현
    /// - UserControl 상속: 컨트롤(그림/배치/이벤트/디자이너 지원)로 동작하기 위한 기반 제공
    /// - [DefaultEvent("Clicked")]: 이 컨트롤의 기본(대표) 이벤트를 Clicked로 지정.
    /// </summary>
    [DefaultEvent("Clicked")]
    public partial class ProductCard : UserControl, IProductCard
    {
        public event EventHandler<IProductCard>? Clicked; // 이벤트 구현

        // Price는 "계산용 데이터(decimal)"로 보관하고, Label.Text는 "표시 문자열"로만 사용(데이터/표시 분리)
        private decimal _price;

        // 생성자에서 AddChickEvent 호출
        public ProductCard()
        {
            InitializeComponent();
            AddChickEvent(this);
        }

        [Category("ProductCard"), Description("상품 ID")]
        public int ID { get ; set ; }

        [Category("ProductCard"), Description("상품명")]
        // Title은 UI(Label)에 바로 매핑(내부 컨트롤이 상태 저장소 역할)
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value.Trim(); }

        [Category("ProductCard"), Description("가격(계산용)")]
        // Price는 "진짜 값"을 필드에 저장하고, 표시 문자열은 별도 메서드[SetPrice()]로 갱신
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                SetPrice(); 
            }
        }

        [Category("ProductCard"), Description("상품 이미지")]
        // Image도 UI(PictureBox)에 바로 매핑
        public Image Image { get => picBox.Image; set => picBox.Image = value; }



        #region Funtion
        /// <summary>
        /// [SetPrice]
        /// - UI에 보이는 lblPrice.Text 가공
        /// - 가격 표시 규칙을 한 곳에 모아(포맷/할인/통화 변경 등) 확장 대비
        /// </summary>
        private void SetPrice()
        { 
            lblPrice.Text = $"{_price.ToString("#,000")}원"; //백 단위의 상품에서 천자리에 0이 들어오는 거 방지
        }


        /// <summary>
        /// [AddChickEvent]
        /// 목적: 어디를 클릭하든 하나의 이벤트로 모음
        /// 원리: 재귀의 형태로 ‘트리(부모-자식)’을 이용해 모든 컨트롤에 ‘최상위 Clicked Invoke’를 붙임
        /// </summary>
        /// <param name="parentControl"></param>
        private void AddChickEvent(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                control.Click += (_, __) => Clicked?.Invoke(this, this);
                if (control.HasChildren)
                {
                    AddChickEvent(control);
                }
            }
        }

        #endregion
    }
}


