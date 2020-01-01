using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.Payment
{
    public class PaymentAddtionViewModel
    {
        public double Value { get; set; }
        public int TagerId { get; set; }
        public int SellerId { get; set; }
    }
}