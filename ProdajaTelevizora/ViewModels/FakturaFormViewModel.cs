using ProdajaTelevizora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProdajaTelevizora.Models;

namespace ProdajaTelevizora.ViewModels
{
    public class FakturaFormViewModel
    {
        public IEnumerable<Kupac> Kupci { get; set; }
        public IEnumerable<Televizor> Televizori{ get; set; }
        public Faktura Fakture { get; set; }
    }
}