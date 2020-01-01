using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CafeDemo.Models.StoreModels;

namespace CafeDemo.Models.CafeModels
{
    public class Category
    {
        public int Id { get; set; }
        [Index(IsUnique =true)]
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        public virtual List<Goods> Goods { get; set; }
    }
}