using CafeDemo.Models.CafeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.StoreModels
{
    public class GoodsAddtionProduct
    {
        //[Key]
        //[Column(Order = 1)]
        //public int GoodsAddtionId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        //public int ProductId { get; set; }
        //public int Count { get; set; }
        /////////////  NavigationProperties  ////////////////
        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }
        //[ForeignKey("GoodsAddtionId")]
        //public virtual GoodsAddtion GoodsAddtion { get; set; }
    }
}