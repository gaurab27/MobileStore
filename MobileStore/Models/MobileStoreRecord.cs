using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class MobileStoreRecord
    {
        public int Id { get; set; }
        [Required]
        public int BrandId { get; set; }
        public string MobileBrand { get; set; }
        [Required]
        [MaxLength(50)]
        public string MobileModel { get; set; }
        [Required]
        [MaxLength(10)]
        public string Price { get; set; }
        [Required]
        public DateTime SellDate { get; set; }
    }
}
