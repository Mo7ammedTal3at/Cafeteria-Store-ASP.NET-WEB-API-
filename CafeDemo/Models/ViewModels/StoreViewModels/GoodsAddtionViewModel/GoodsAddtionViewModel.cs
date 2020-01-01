using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionViewModel
{
    public class GoodsAddtionViewModel
    {
        public int SellerId { get; set; }
        public int TagerId { get; set; }
        public int GoodsId { get; set; }
        public int NumberOfBoxes { get; set; }
    }
}