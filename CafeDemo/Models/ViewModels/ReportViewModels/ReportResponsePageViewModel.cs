using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.ReportViewModels
{
    public class ReportResponsePageViewModel
    {
        public string GoodsName { get; set; }
        public int NumberOfBoxes { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int NumberOfItems { get; set; }
    }
}