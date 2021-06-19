using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexionWeb.Models
{
    public class CampoMatriz
    {
        [Required, StringLength(100), Display(Name = "Codigo"), Key]
        public string Codigo { get; set; }

        public string CampoPadre { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public string Opciones { get; set; }
    }
}
