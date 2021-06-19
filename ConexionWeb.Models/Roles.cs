using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConexionWeb.Models
{
    public class Roles
    {
        [Required, StringLength(100), Display(Name = "IdRol"), Key]
        public string IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Permisos { get; set; }
        public string Responsable { get; set; }
        public string ResponsableDelegado { get; set; }
        public string Estado { get; set; }
    }
}
