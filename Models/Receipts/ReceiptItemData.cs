using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskByGT.Models.Receipts
{
    /// <summary>
    /// [영수증 한 줄 데이터 모델]
    /// - 상품의 "이름, 수량, 단가, 총금액"의 틀을 지님
    /// </summary>
    internal class ReceiptItemData
    {
        public string Title { get; set; } = string.Empty;

        public int Count { get; set; }

        public decimal Price { get; set; }

        public decimal SumPrice { get; set; }
    }
}
