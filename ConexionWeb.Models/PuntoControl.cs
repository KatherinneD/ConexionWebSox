using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConexionWeb.Models
{
    public class PuntoControl
    {
        [Required, StringLength(100), Display(Name = "Codigo"), Key]
        public string Codigo { get; set; }

        public string PuntoDeControl { get; set; }

        public string Autor { get; set; }

        public string Estado { get; set; }

        public string InactivadoPor { get; set; }
    }
}
