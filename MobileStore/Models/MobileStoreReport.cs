using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class MobileStoreDiscountReport
    {
        public string MobileBrand { get; set; }
        public string MobileModel { get; set; }
        public string Price { get; set; }
        public string MarketPrice { get; set; }
        public DateTime SellDate { get; set; }
        public int Discount => ((int.Parse(MarketPrice) - int.Parse(Price)) * 100) / int.Parse(MarketPrice);
    }
    public class MobileStoreReport
    {
        public string MobileBrand { get; set; }
        public List<MobileStoreRecord> SellRecord { get; set; }
    }
}
