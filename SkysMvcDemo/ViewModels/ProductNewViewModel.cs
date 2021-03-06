using System.ComponentModel.DataAnnotations;

namespace SkysMvcDemo.ViewModels
{
    public class ProductNewViewModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public int Price { get; set; }
        [MaxLength(20)]
        public string Color { get; set; }
        [MaxLength(15)]
        public string Ean13 { get; set; }


        [Range(0, 100)]
        public int PopularityPercent { get; set; }


    }
}