using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineShop.Models
{
    public class Wine
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(70, ErrorMessage = "Length should not be more than 70 characters.")]
        public string Name { get; set; }

        [Range(5.00, 1250.00)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C2}")]
        public string Price { get; set; }

        [Range(1700, 2100, ErrorMessage = "Year of bottling should be higher than 1700.")]
        public int Year { get; set; }

        [Range(8.5, 23.0, ErrorMessage = "Percentage should be between 8,5 and 23,0.")]
        [Display(Name="Alcohol Percentage")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N1}")]
        public string AlcoholPercentage { get; set; }

        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Type of Wine")]
        public WineType WineType { get; set; }

        [Display(Name = "Winery")]
        public int WineryID { get; set; }

        public virtual Winery Winery { get; set; }
    }

    public enum WineType
    {
        Sauvignon, Rieslinger, Syrah, Merlot, Cabernet, Other
    }
}
