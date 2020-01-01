using CafeDemo.Models.CafeModels;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.StoreModels
{
    public class GoodsSell
    {
        public int Id { get; set; }
        public int KafteriaId { get; set; }
        public DateTime Time { get; set; }
        public int SellerId { get; set; }
        public int GoodsId { get; set; }
        public int NumberOfItems { get; set; }
         public int PreviousProductsCount { get; set; }
        public int UpdatedProductsCount { get; set; }
        public double ItemsSellPrice { get; set; }
        public double ItemsBuyPrice { get; set; }
        ///////////  NavigationProperties  ////////////////
        [ForeignKey("KafteriaId")]
        public virtual Kafteria Kafteria { get; set; }
        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }
        [ForeignKey("GoodsId")]
        public virtual Goods Goods { get; set; }      
       
    }
}