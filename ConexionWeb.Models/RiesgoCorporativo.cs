using System;
using System.ComponentModel.DataAnnotations;

namespace ConexionWeb.Models
{
    public class RiesgoCorporativo
    {
        [ScaffoldColumn(false)]

        [Required, StringLength(100), Display(Name = "Codigo"),Key]
        public string Codigo { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        public string Nivel { get; set; }
        
        [Required]
        public string Tipo { get; set; }
    }
}
