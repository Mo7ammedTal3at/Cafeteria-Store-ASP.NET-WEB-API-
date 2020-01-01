using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CafeDemo.Models.CafeModels;

namespace CafeDemo.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Index(IsUnique =true)]
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        [Required]
        public float SellPrice { get; set; }
        [Required]
        public float BuyPrice { get; set; }
        [Required]
        public int NumberByBox { get; set; }
        public int AlertLimit { get; set; }
        public DateTime AddtionTime { get; set; }
        public bool IsLimited { get; set; } = false;
        public int CategoryId { get; set; }
    }
}