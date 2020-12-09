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
        public string Email { get; set; }
    }
}