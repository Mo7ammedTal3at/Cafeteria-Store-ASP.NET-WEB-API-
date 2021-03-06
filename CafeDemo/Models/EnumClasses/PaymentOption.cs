﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CafeDemo.Models.CafeModels;

namespace CafeDemo.Models.EnumClasses
{
    public class PaymentOption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Payment> Payments { get; set; }
    }
}