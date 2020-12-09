using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class AplicacionesCSV
    {
        public string Codigo { get; set; }
        public string NombreAplicacion { get; set; }
        public string Servidor { get; set; }
        public string IPServidor{ get; set; }
        public string TipoServidor { get; set; }
    }
}
