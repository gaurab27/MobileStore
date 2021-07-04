using System;
using System.Collections.Generic;

#nullable disable

namespace MobileStore.Models
{
    public partial class MobileBrandRecord
    {
        public MobileBrandRecord()
        {
            MobileSellRecords = new HashSet<MobileSellRecord>();
        }

        public int Id { get; set; }
        public string MobileBrand { get; set; }

        public virtual ICollection<MobileSellRecord> MobileSellRecords { get; set; }
    }
}
