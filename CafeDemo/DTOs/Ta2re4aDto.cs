using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeDemo.DTOs
{
    public class Ta2re4aDto
    {
        public int Id { get; set; }
        [Required]
        public float MaxValue { get; set; }
        public float CurrentValue { get; set; } = 0F;

        //[Required]

        //public int PersonId { get; set; }
    }
}