using System;
using System.Collections.Generic;

#nullable disable

namespace MobileStore.Models
{
    public partial class MobileSellRecord
    {
        public int Id { get; set; }
        public string MobileModel { get; set; }
        public int BrandId { get; set; }
        public string Price { get; set; }
        public DateTime SellDate { get; set; }
        public string MarketPrice { get; set; }

        public virtual MobileBrandRecord Brand { get; set; }
    }
}
