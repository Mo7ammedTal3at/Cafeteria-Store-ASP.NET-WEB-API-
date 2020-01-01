using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.Payment
{
    public class PaymentViewModel
    {
        public float Value { get; set; }
        public int PaymentOptionId { get; set; }
        public DateTime Time { get; set; }
    }
}