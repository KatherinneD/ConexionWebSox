using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ConexionWeb.Models
{
    public class ActividadControl
    {
        [Required, StringLength(100), Display(Name = "Codigo"), Key]
        public string Codigo { get; set; }
        public string NombreActividad { get; set; }
        public string Estado { get; set; }
        public string CodigoObjetivo { get; set; }
        public string CodigoRiesgo { get; set; }
        public string CodigoSubDominio { get; set; }
        public string UsuarioModificador { get; set; }

    }
}
