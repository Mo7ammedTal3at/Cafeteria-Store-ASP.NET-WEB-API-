using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CafeDemo.Models.CafeModels;

namespace CafeDemo.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        [Required]
        public float TotalPrice { get; set; }
        public DateTime Time { get; set; }
        [Required]
        public int BuyerId { get; set; }
        public int PersonId { get; set; }
        public int SellerId { get; set; }
        public virtual List<ProductDto> Products { get; set; }
        public virtual List<OrderProductDto> OrderProducts { get; set; }

    }
}