using CafeDemo.Models.CafeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.StoreModels
{
    public class GoodsSellProduct
    {
        //[Key]
        //[Column(Order = 1)]
        //public int GoodsSellId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        //public int ProductId { get; set; }
        //public int Count { get; set; }
        /////////////  NavigationProperties  ////////////////
        //[ForeignKey("GoodsSellId")]
        //public GoodsSell GoodsSell { get; set; }
        //[ForeignKey("ProductId")]
        //public Product Product { get; set; }
    }
}