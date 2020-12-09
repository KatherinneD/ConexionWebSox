using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Web;

namespace ConexionWeb.Models
{
    public class MatrizControles
    {
        [Required, StringLength(100), Display(Name = "Codigo"), Key]
        public string Codigo { get; set; }
        public string CriterioControl { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string CodigoSOX { get; set; }
        public string CodigoPuntoControl { get; set; }
        public string CodigoActividadControl { get; set; }
        public string CodigoDocumento { get; set; }
        public string CodigoAplicacion { get; set; }
        public string CodigoTiempoAplicacion { get; set; }
        public string DescripcionActividadesTercero { get; set; }
        public bool DeficienciaAnoAnterior { get; set; }
        public string CodigoFrecuenciaControl { get; set; }
        public string CodigoNaturalezaControl { get; set; }
        public string ResponsableControl { get; set; }
        public string CodigoTipoControl { get; set; }
        public string EvidenciaRutaArchivos { get; set; }
        public string EvidenciaDescripcionRevision { get; set; }
        public string EvidenciaCodigoHerramientaAlmacenamiento { get; set; }
        public string EvidenciaDescripcionRestricciones { get; set; }
        public string EvidenciaCodigoTiempoPermanencia { get; set; }
        public string CalidadEvidenciaDescripcion { get; set; }
        public string CalidadEvidenciaCodigoAplicacion { get; set; }
        public string CalidadEvidenciaDescripcionTransaccion { get; set; }
        public string CalidadEvidenciaCodigoTipoReporte { get; set; }
        public string CalidadEvidenciaCodigoImportanciaReporte { get; set; }
        public string CalidadEvidenciaDescripcionIntegridad { get; set; }
        public string CalidadEvidenciaDescripcionRevisionesGerencia { get; set; }
        public string ControlCompensatorioDescripcion { get; set; }
        public string ControlCompensatorioDescripcionEvidencia { get; set; }
        public string ControlCompensatorioCodigoAplicacion { get; set; }
        public DateTime? ControlCompensatorioFechaInicio { get; set; }
        public DateTime? ControlCompensatorioFechaCreacion { get; set; }
        public string ControlCompensatorioNotificarJefeArea { get; set; }
        public DateTime? ModificacionFechaAprobacion { get; set; }
        public bool ModificacionAprobado { get; set; }
        public string ModificacionObservaciones { get; set; }

    }
}
