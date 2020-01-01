using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CafeDemo.Models.CafeModels;

namespace CafeDemo.Models.StoreModels
{
    public class GoodsAddtionPayment
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Time { get; set; }
        public int TagerId { get; set; }
        public int SellerId { get; set; }
        [ForeignKey("TagerId")]
        public virtual Tager Tager { get; set; }
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }
        //public int GoodsAddtionId { get; set; }
        ///////////  NavigationProperties  ////////////////
        //[ForeignKey("GoodsAddtionId")]
        //public virtual GoodsAddtion GoodsAddtion { get; set; }
    }
}