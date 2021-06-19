using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ConexionWeb.Models
{
    public class Control
    {
        [Required, StringLength(100), Display(Name = "Codigo"), Key]
        public string Codigo { get; set; }
        public string sControl { get; set; }
        public string Objetivo { get; set; }
        public string Estado { get; set; }
        public string InicialesControl { get; set; }
        public string UsuarioModificador { get; set; }
        public string InactivadoPor { get; set; }

    }
}
