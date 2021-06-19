using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConexionWeb.Models
{
    public class RiesgoSOX
    {
        [Required]
        public string CodigoRiesgoCorporativo { get; set; }

        [Required, StringLength(100), Display(Name = "CodigoSOX"), Key]
        public string CodigoSOX { get; set; }

        [Display(Name = "Descripción")]
        public string DescripcionSOX { get; set; }

        [Required]
        public string NivelSOX { get; set; }

        [Required]
        public DateTime FechaCreacion{ get; set; }

        [Required]
        public string Estado { get; set; }

        public string AprobadoPor { get; set; }
        public string InactivadoPor { get; set; }
    }
}
