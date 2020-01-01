using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CafeDemo.Models.ViewModels.StoreViewModels.GoodsAddtionPaymentViewModels;

namespace CafeDemo.Models.ViewModels.StoreViewModels.Tager
{
    public class TagerGoodsAddtionsPaymentsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalPayments { get; set; }
        public double PaidPayments { get; set; }
        public double RemainingPayments { get; set; }
        public List<GoodsAddtionPaymentViewModel> GoodsAddtionsPayments { get; set; }
    }
}