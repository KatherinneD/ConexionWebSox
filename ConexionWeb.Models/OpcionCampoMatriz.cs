using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexionWeb.Models
{
    public class OpcionCampoMatriz
    {
        [Required, StringLength(100), Display(Name = "Codigo"), Key]
        public string Codigo { get; set; }

        public string Valor { get; set; }
    }
}
