using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class ObjetivoControlCSV
    {
        public string Codigo { get; set; }

        public string ObjetivoControl { get; set; }
    }
}
