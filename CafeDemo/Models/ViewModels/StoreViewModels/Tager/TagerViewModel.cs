﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.ViewModels.StoreViewModels.Tager
{
    public class TagerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double TotalPayments{ get; set; }
        public double PaidPayments{ get; set; }
        public double RemainingPayments{ get; set; }
    }
}