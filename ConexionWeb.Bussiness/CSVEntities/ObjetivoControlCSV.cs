using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|"), IgnoreFirst(1)]
    public class ObjetivoControlCSV
    {
        public int Codigo { get; set; }

        public string ObjetivoControl { get; set; }
    }
}
