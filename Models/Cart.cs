using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineShop.Models
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }

        public int Amount { get; set; }

        [Display(Name = "Wine")]
        public int WineID { get; set; }

        public int ClientID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime AddedOn { get; set; }

        public virtual User Client { get; set; }
        public virtual Wine Wine { get; set; }
    }
}
