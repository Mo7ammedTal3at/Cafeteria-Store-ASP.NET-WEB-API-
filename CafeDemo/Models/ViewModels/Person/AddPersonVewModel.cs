using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CafeDemo.Models.EnumClasses;
using CafeDemo.Models.ViewModels.Daraga;
using CafeDemo.Models.ViewModels.Far3;

namespace CafeDemo.Models.ViewModels.Person
{
    public class AddPersonVewModel
    {
        public List<DaragaViewModel> Daraga { get; set; }
        public List<Far3ViewModel> Far3 { get; set; }
    }
}