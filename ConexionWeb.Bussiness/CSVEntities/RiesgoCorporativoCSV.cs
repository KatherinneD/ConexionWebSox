using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConexionWeb.Bussiness.CSVEntities
{
    [DelimitedRecord("|")]
    public class RiesgoCorporativoCSV
    {
        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public string Nivel { get; set; }

        public string Tipo { get; set; }

    }
}
