using KioskByGT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KioskByGT.Components.Products
{
    /// <summary>
    /// [복합 컨트롤(Composite Control)]
    /// - Items(상품 데이터 목록)를 받아서 ProductCard들을 "동적으로 생성"해 화면에 배치한다.
    /// - 내부 카드 클릭을 외부로 전달할 때, ProductCard가 아니라 Product(데이터)만 전달한다. 
    /// </summary>
    [DefaultEvent("ItemClicked")]
    public partial class ProductList : UserControl
    {
        /// <summary>
        /// [대표 이벤트]
        /// - 외부(Form 등)는 이 이벤트 하나만 구독하면 된다.
        /// - 내부에서 카드가 몇 개 생성되든, 언제 생성되든 외부는 신경 쓸 필요 없다.
        /// - payload(전달 데이터)는 "Product"로 고정 => UI를 외부에 노출하지 않는다.
        /// </summary>
        public event EventHandler<Product>? ItemClicked;

        // ProductList에 Items를 추가하기 위한 '디자이너 직렬화' 설정 - 디자이너 코드에 작성해주는 역할
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]

        /// <summary>
        /// [데이터 저장소 / 카드 재료 창고]
        /// - 여기에는 "Product(데이터)"가 쌓인다.
        /// - Add/Remove/Clear 같은 변경이 일어나면 CollectionChanged 이벤트가 발생한다.
        /// </summary>
        public ObservableCollection<Product> Items { get; set; } = [];

        public ProductList()
        {
            InitializeComponent();

            //step0. Items(데이터 목록)가 바뀌면 → UI(카드)를 다시 그릴 트리거를 건다.
            Items.CollectionChanged += Items_CollectionChanged;
        }

        /// <summary>
        /// Items가 Add/Remove/Clear 등으로 바뀔 때 자동 호출되는 이벤트 핸들러
        /// (ObservableCollection이 제공)
        /// </summary>
        private void Items_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            // Step3. "UI 저장소(flpnl.Controls)"를 초기화한다.
            // - Items는 데이터 목록(누적)이고,
            // - flpnl.Controls는 화면에 올린 컨트롤 목록이다.
            // - 지금 구현은 '변경분만 반영'이 아니라 '전체 다시 그리기' 전략이므로 Clear가 필요하다.
            flpnl.Controls.Clear();

            // Step1.현재 Items(데이터 목록) 전체를 순회하면서,
            //       "데이터(Product) -> 화면용 컨트롤(ProductCard)"로 변환/생성한다.
            foreach (var item in Items)
            {
                // Step2. ProductCard 동적 생성 및 데이터 할당(바인딩)
                ProductCard productCard = new ProductCard
                {
                    ID = item.ID,
                    Title = item.Title,
                    Price = item.Price,

                    // item.Image가 null일 수 있지만, "반드시 할당된다"는 가정이면 !로 강제 가능
                    Image = item.Image!,  
                };

                // 내부 카드 클릭을 ProductList가 먼저 받는다(이벤트 집계/중계).
                productCard.Clicked += ProductCard_Clicked;

                // UI 컨테이너(FlowLayoutPanel)에 컨트롤을 올려서 화면에 표시한다.
                flpnl.Controls.Add(productCard); 
            }
        }

        /// <summary>
        /// 내부 ProductCard 클릭 이벤트를 받은 뒤,
        /// 외부에는 Product(데이터)만 전달하는 "대표 이벤트"를 다시 쏜다.
        /// </summary>
        private void ProductCard_Clicked(object? sender, IProductCard e)
        {
            // Step4. 외부로는 "UI 컨트롤(ProductCard)"이 아니라
            //      "상품 데이터(Product)"만 나가게 만든다.
            //- ProductCard_Clicked 클릭하면 그에 대한 정보는 IProductCard에 들어있음.
            //- 그 정보를 이용해서 Product객체를 만들어 외부 이벤트로 추가할 것임.
            ItemClicked?.Invoke(this, new Product
            {
                ID = e.ID,
                Title = e.Title,
                Price = e.Price,
                Image = e.Image,
            });
            /* c# 최신버전에서는 인터페이스에서 객체를 생성해서 넘겨줄 수 있음
            // 때문에 IProductCard에다가 아래처럼 정의하면 ItemClicked?.Invoke(this, e.ToProduct());를 해서 전달 받을 수 있음
            // public Product ToProduct()
            //{
            //   return new Product
            //   {
            //      ID = ID,
            //      Title = Title,
            //      Price = Price,
            //      Image = Image
            //    }
            */
        }        
    }
}
