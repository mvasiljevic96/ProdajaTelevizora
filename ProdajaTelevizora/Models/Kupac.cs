using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProdajaTelevizora.Models
{
    public class Kupac
    {
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }

    }
}