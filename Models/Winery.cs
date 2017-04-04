using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineShop.Models
{
    public class Winery
    {
        [Key]
        public int ID { get; set; }

        public Country Country { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Length should not be more than 100 characters.")]
        public string Name { get; set; }

        public virtual ICollection<Wine> Wines { get; set; }
    }

    public enum Country
    {
        France, Spain, Poland, Germany, Greece, Netherlands, Belgium, Italy, UK, Other
    }
}
