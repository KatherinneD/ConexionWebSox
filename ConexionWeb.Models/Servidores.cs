using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConexionWeb.Models
{
    public class Servidores
    {
        [Required, StringLength(100), Display(Name = "Nombre"), Key]
        public string Nombre { get; set; }
        public string Ip { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

    }
    
}
