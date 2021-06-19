using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConexionWeb.Models
{

    public class ObjetivoControl
    {
        [Required, Display(Name = "Codigo"), Key]
        public int Codigo { get; set; }

        public string ObjetivoDeControl { get; set; }
        
        public string Autor { get; set; }

        public string Estado { get; set; }

        public string InactivadoPor { get; set; }
    }
}
