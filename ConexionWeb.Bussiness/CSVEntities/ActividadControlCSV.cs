using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class ActividadControlCSV
    {
        public string Codigo { get; set; }
        public string NombreActividad { get; set; }
        public string Estado { get; set; }
    }
}
