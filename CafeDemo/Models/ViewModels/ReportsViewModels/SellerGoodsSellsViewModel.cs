using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.ReportsViewModels
{
    public class SellerGoodsSellsViewModel
    {
        [Required(ErrorMessage = "لابد من إدخال بداية المدة المراد عمل تقرير لها")]
        public DateTime From { get; set; }
        [Required(ErrorMessage = "لابد من إدخال نهاية المدة المراد عمل تقرير لها")]
        public DateTime To { get; set; }
        [Required(ErrorMessage = "لابد من اختيار البائع المراد عمل تقرير له")]
        public int SellerId { get; set; }
    }
}