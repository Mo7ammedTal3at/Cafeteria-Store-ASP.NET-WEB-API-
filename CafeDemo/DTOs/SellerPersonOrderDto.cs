using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeDemo.DTOs
{
    public class SellerPersonOrderDto
    {
        [Key]
        [Column(Order = 1)]
        public int SellerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PersonId { get; set; }
        [Key]
        [Column(Order = 3)]
        public int OrderId { get; set; }

    }
}