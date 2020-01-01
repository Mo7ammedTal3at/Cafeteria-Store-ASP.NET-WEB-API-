using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.StoreViewModels.GoodsSellViewModel
{
    public class GoodsSellViewModel
    {
        public int KafteriaId { get; set; }
        public int SellerId { get; set; }
        public int GoodsId { get; set; }
        public int NumberOfBoxes { get; set; }
    }
}