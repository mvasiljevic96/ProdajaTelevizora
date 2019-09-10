using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProdajaTelevizora.Models
{
    public class Televizor
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string DijagonalaEkrana { get; set; }
        public string Dimenzije { get; set; }
        public TehnologijaEkrana TehnologijaEkrana { get; set; }
        public string Cijena { get; set; }
    }
}