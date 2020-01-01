using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.ReportsViewModels
{
    public class GoodsSellsResponseViewModel
    {
        public double TotalItemsSellPrice { get; set; }
        public double TotalItemsBuyPrice { get; set; }
        public double TotalProofts { get; set; }
        public List<GoodsSellsViewModel> GoodsSells { get; set; }
    }

    public class GoodsSellsViewModel
    {
        public string Name { get; set; }
        public int BoxesCount { get; set; }
        public double ItemsSellPrice { get; set; }
        public double ItemsBuyPrice { get; set; }
    }
}