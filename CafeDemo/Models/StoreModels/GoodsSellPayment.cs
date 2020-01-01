using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CafeDemo.Models.CafeModels;

namespace CafeDemo.Models.StoreModels
{
    public class GoodsSellPayment
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Time { get; set; }
        public int SellerAdminId { get; set; }
        public int SellerId { get; set; }
        
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }
        [ForeignKey("SellerAdminId")]
        public virtual Seller SellerAdmin { get; set; }
    }
}