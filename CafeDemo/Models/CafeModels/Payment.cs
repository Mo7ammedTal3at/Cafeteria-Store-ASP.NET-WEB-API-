﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CafeDemo.Models.EnumClasses;

namespace CafeDemo.Models.CafeModels
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        public float Value { get; set; }
        [Required]
        public int PaymentOptionId { get; set; }

        public DateTime Time { get; set; }

        [ForeignKey("PaymentOptionId")]
        public virtual PaymentOption PaymentOption { get; set; }

        //[Required]
        //public int PersonId { get; set; }

        //[Required]
        //public int SellerId { get; set; }

        //[ForeignKey("PersonId")]
        //public virtual Person Person { get; set; }
        //[ForeignKey("SellerId")]
        //public virtual Seller Seller { get; set; }


        //public List<SellerPersonPayment> SellerPersonPayments { get; set; }
    }
}