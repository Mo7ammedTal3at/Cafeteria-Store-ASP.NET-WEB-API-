using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.ReportViewModels
{
    public class ReportPageViewModel
    {
        public DateTime From { get; set; }
        public  DateTime To { get; set; }
        public int GoodsId { get; set; }

    }
}