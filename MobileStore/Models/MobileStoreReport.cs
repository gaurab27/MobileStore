using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class MobileStoreDiscountReport
    {
        public string MobileModel { get; set; }
        public string SellPrice { get; set; }
        public string MarketPrice { get; set; }
        public DateTime SellDate { get; set; }
        public int Loss => int.Parse(MarketPrice) > int.Parse(SellPrice) ? ((int.Parse(MarketPrice) - int.Parse(SellPrice)) * 100) / int.Parse(MarketPrice) : 0;
        public int Profit => int.Parse(MarketPrice) < int.Parse(SellPrice) ? ((int.Parse(SellPrice) - int.Parse(MarketPrice)) * 100) / int.Parse(MarketPrice) : 0;
        public int Discount => Loss > 0 ? Loss : 0;
    }
    public class MobileStoreReport
    {
        public string MobileBrand { get; set; }
        public List<MobileStoreRecord> SellRecord { get; set; }
    }
    public class MobileStoreDiscountReportView
    {
        public string MobileBrand { get; set; }
        public List<MobileStoreDiscountReport> Record { get; set; }
    }
}
