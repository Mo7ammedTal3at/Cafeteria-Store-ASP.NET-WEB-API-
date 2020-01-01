using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CafeDemo.Models.CafeModels;
using System.ComponentModel.DataAnnotations;

namespace CafeDemo.Models.EnumClasses
{
    public class Far3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
    }
}