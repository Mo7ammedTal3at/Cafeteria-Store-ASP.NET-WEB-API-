using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.StoreViewModels.GoodsSellViewModel
{
    public class GoodsSellsResponseViewModel
    {
        public int GoodsSellId { get; set; }
        public string GoodsName { get; set; }
        public int NumberOfBoxes { get; set; }
        public int PreviousNumberOfBoxes { get; set; }
        public int UpdatedNumberOfBoxes { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double ItemsBuyPrice { get; set; }
        public double ItemsSellPrice { get; set; }
        public double Proofts { get; set; }
        public string KafteriaName { get; set; }
        public string RecieverName { get; set; }
    }
}