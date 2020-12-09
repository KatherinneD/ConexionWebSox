using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConexionWeb.Models
{
    public class Jefatura
    {
        [Required, StringLength(100), Display(Name = "CodigoArea"), Key]
        public string CodigoArea { get; set; }

        public string NombreArea { get; set; }
        public string ProductOwner { get; set; }
        public string ScrumMaster { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
    }
}
