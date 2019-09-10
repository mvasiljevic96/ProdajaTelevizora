using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProdajaTelevizora.Models
{
    public class Faktura
    {
        public int Id { get; set; }

        [Required]
        public Kupac Kupac { get; set; }

        [Required]
        public Televizor Televizor { get; set; }

        [Required]
        public DateTime DatumKupovine { get; set; }
    }
}