using System;
using System.ComponentModel.DataAnnotations;

namespace SkysMvcDemo.ViewModels
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public int Price { get; set; }
        [MaxLength(20)]
        public string Color { get; set; }
        [MaxLength(15)]
        public string Ean13 { get; set; }

        public int PopularityPercent { get; set; }

    }
}