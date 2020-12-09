using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class ControlCSV
    {
        public string Codigo { get; set; }
        public string NombreControl { get; set; }
        public string InicialesControl { get; set; }
        public string Estado { get; set; }
    }
}
