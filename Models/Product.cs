using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskByGT.Models
{
    /// <summary>
    /// [Model] UI와 무관한 "상품 데이터"
    /// - ProductCard가 화면에 표시할 재료
    /// - ProductList가 외부로 이벤트를 보낼 때도 "데이터만" 전달하기 위해 사용
    ///
    /// 핵심 의도:
    ///   UI(컨트롤)를 밖으로 새지 않게 하고,
    ///   밖에서는 Product만 가지고 장바구니/결제 같은 로직을 처리하게 만든다.
    /// </summary>
    public class Product
    {
        // 식별자 (DB/목록/장바구니에서 키로 쓰기 좋음)
        public int ID { get; set; }

        // 표시용 텍스트 (UI 라벨에 뿌릴 값)
        public string Title { get; set; } = string.Empty;

        // 계산용 금액 (장바구니 합산/결제에 바로 씀)
        public decimal Price { get; set; }

        // 이미지 (없을 수도 있으니 nullable)
        public Image? Image { get; set; }
    }
}
