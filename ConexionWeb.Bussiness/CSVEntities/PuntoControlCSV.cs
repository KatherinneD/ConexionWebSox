using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class PuntoControlCSV
    {
        public string Codigo { get; set; }

        public string PuntoControl { get; set; }
    }
}
