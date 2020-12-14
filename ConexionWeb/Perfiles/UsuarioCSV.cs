using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConexionWeb.Perfiles
{
    [DelimitedRecord("|")]
    public class UsuarioCSV
    {
        public string Usuario { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Cargo { get; set; }
        public string Jefatura { get; set; }
    }
}