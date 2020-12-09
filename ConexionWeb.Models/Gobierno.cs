using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexionWeb.Models
{
    public class Gobierno
    {
        [Required, StringLength(100), Display(Name = "Codigo"), Key]
        public string Codigo { get; set; }
        
        [Required]
        public string NombreProceso { get; set; }
        
        [Required]
        public string URL { get; set; }
        
        public string Estado { get; set; }

        public string InactivadoPor { get; set; }

    }
}
