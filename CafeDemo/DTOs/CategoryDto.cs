using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeDemo.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
    }
}