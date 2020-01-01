using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.StoreModels
{
    public class Tager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ///////////  NavigationProperties  ////////////////
        public virtual List<GoodsAddtion> GoodsAddtions { get; set; }
        public virtual List<GoodsAddtionPayment> GoodsAddtionPayments { get; set; }
    }
}