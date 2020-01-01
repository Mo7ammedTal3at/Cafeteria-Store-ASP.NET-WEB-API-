using CafeDemo.Models.StoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeDemo.Models.CafeModels
{
    public class Seller
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(255)]
        [Required]

        public string Name { get; set; }
        [Index(IsUnique = true)]
        [StringLength(13)]
        [Required]

        public string MilitaryNumber { get; set; }
        [Index(IsUnique =true)]
        [StringLength(13)]
        [Required(ErrorMessage ="the username is required")]

        public string Username { get; set; }
        [Required(ErrorMessage = "the username is required")]

        public string Password { get; set; }

        public virtual List<GoodsAddtion> GoodsAddtions { get; set; }
        public virtual List<GoodsSell> GoodsSells { get; set; }
        public virtual List<GoodsAddtionPayment> GoodsAddtionPayments { get; set; }
        public virtual List<GoodsSellPayment> GoodsSellPayments { get; set; }

    }
}