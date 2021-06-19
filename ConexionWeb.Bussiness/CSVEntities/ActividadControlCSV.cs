using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class ActividadControlCSV
    {
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string Codigo { get; set; }

        [FieldOptional]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string NombreActividad { get; set; }

        [FieldOptional]
        [FieldQuoted('"', QuoteMode.OptionalForBoth, MultilineMode.AllowForBoth)]
        public string Estado { get; set; }
    }
}
