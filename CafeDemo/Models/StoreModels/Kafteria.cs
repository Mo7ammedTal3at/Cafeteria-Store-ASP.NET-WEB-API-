using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.StoreModels
{
    public class Kafteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ///////////  NavigationProperties  ////////////////
        public virtual List<GoodsSell> GoodsSells { get; set; }
    }
}