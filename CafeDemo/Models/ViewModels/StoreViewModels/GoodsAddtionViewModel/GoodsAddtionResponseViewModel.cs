using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionViewModel
{
    public class GoodsAddtionResponseViewModel
    {
        public int GoodsAddtionId { get; set; }                         
        public string GoodsName { get; set; }
        public int NumberOfBoxes { get; set; }
        public int PreviousNumberOfBoxes { get; set; }                 
        public int UpdatedNumberOfBoxes { get; set; }                  
        public string Date { get; set; }
        public string Time { get; set; }
        public double ItemsBuyPrice { get; set; }
        public double ItemsSellPrice { get; set; }
        public double Proofts { get; set; }
    }
}