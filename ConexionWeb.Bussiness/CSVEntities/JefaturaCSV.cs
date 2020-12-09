using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class JefaturaCSV
    {
        public string Area { get; set; }
        public string Jefe { get; set; }
    }
}
