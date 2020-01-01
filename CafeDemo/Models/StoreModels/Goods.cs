﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CafeDemo.Models.CafeModels;

namespace CafeDemo.Models.StoreModels
{
    public class Goods
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        [Required]
        public float SellPrice { get; set; }
        [Required]
        public float BuyPrice { get; set; }
        [Required]
        public int TotalItemsCount { get; set; }

        public int NumberOfItemsInBox { get; set; } = 0;
        public int AlertLimit { get; set; }
        public DateTime AddtionTime { get; set; }
        public bool IsLimited { get; set; } = false;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        
        public virtual List<GoodsAddtion> GoodsAddtions { get; set; }
        public virtual List<GoodsSell> GoodsSells { get; set; }

        //////////////// Future Update///////////////////
        //public virtual List<GoodsSellProduct> GoodsSellProducts { get; set; }
        //public virtual List<GoodsAddtionProduct> GoodsAddtionProducts { get; set; }
    }
}