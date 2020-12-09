using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConexionWeb.Models
{
    public class Aplicaciones
    {
        [Required, StringLength(100), Display(Name = "Codigo"), Key]
        public string Codigo { get; set; }
        public string NombreAplicacion{ get; set; }
        public string Servidores { get; set; }
        public string Estado { get; set; }
        public string HerramientaAlmacenamiento { get; set; }
        public bool ClasificarSOX { get; set; }
        public string Celula{ get; set; }
        public string InactivadoPor{ get; set; }
        public string EstadoAuditoria { get; set; }
    }
    
}
