using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.StoreViewModels.GoodsViewModels
{
    public class GoodsEditViewModel
    {
        [Index(IsUnique = true)]
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        [Required]
        public float SellPrice { get; set; }
        [Required]
        public float BuyPrice { get; set; }
        public int NumberOfItemsInBox { get; set; } = 0;
        public int AlertLimit { get; set; }
    }
}