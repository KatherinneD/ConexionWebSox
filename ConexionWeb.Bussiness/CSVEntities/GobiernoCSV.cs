using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class GobiernoCSV
    {
        public string Codigo { get; set; }
        public string NombreProceso { get; set; }
        public string URL { get; set; }
    }
}
