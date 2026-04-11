using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskByGT.Models.Receipts
{
    public class ReceiptData
    {
        /* 상단, 중단, 하단의 데이터를 정하기
         * [상단]
         * 가게 이름, 가게 소개, 주문 번호, 주문 시간
         * 
         * [중단]
         * ReceiptItemData 
         * 
         * [하단]
         * Total - Count/Price
         */

        // 상단의 헤더 영역
        public string StoreName { get; set; } = string.Empty;  
        public string StoreDescription { get; set; } = string.Empty;    
        public string OrderNumber { get; set; }
        public DateTime OrderTime { get; set; }


        // 중단의 상품 목록 영역
        List<ReceiptItemData> Items { get; set; } = new();

        // 하단의 합계 영역
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
