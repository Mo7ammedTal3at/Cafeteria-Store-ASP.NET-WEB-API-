using CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionViewModel;
using CafeDemo.Models.ViewModels.StoreViewModels.Kafteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.StoreViewModels.GoodsSellViewModel
{
    public class GoodsSellesPageViewModel
    {
        public List<DropDownItem> Kafterias { get; set; }
        public List<DropDownItem> Recievers { get; set; }
        public List<DropDownItem> Products { get; set; }
    }
}