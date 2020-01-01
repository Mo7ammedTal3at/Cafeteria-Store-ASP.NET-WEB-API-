using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CafeDemo.DTOs
{
    public class SellerDto
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(255)]
        public string Name { get; set; }
        [Index(IsUnique = true)]
        [StringLength(13)]
        public string MilitaryNumber { get; set; }
        [Index(IsUnique = true)]
        [StringLength(13)]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}