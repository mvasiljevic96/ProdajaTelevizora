using ProdajaTelevizora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProdajaTelevizora.ViewModels
{
    public class TelevizorFormViewModel
    {
        public IEnumerable<TehnologijaEkrana> TehnlogijeEkrana { get; set; }
        public Televizor Televizor { get; set; }
    }
}