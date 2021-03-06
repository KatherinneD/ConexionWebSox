using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|"), IgnoreFirst(1)]
    public class PuntoControlCSV
    {
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public int Codigo { get; set; }

        [FieldOptional]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string PuntoControl { get; set; }
    }
}
