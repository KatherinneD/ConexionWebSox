using Microsoft.AspNet.Identity.Owin;
using ConexionWeb.ConexionSOXService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace ConexionWeb.MatrizControles
{
    public partial class Matriz : System.Web.UI.UserControl
    {
        public int IDAleatorioUI { get; set; }
        public TipoMatriz TipoDatosAMostrar { get; set; }

        private static TipoMatriz _TipoDatosAMostrar { get; set; }
        public bool SoloLectura { get; set; }
        
        private static ConexionSOXServiceClient Servicio = new ConexionSOXService.ConexionSOXServiceClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void CargarDatos()
        {
            _TipoDatosAMostrar = TipoDatosAMostrar;
            PonerSoloLecturaControles(false);
            CargarListaJefatura();
            CargarListaAplicaciones();
            CargarListaActividadesControl();
            CargarListaPuntosControl();
            CargarListaRiesgos();
            CargarInformacionMatriz();
            InactivarComponentesEnModoNuevo();
        }

        private void InactivarComponentesEnModoNuevo()
        {
            if (Request["Codigo"] == null && Request["Approve"] == null)
            {
                this.txtDeficienciaAnoAnterior.Enabled = false;
                this.divEvidencias.Visible = false;
            }

        }

        private void CargarInformacionMatriz()
        {
            if (!string.IsNullOrEmpty(Request["Codigo"]))
            {
                switch (_TipoDatosAMostrar)
                {
                    case TipoMatriz.Modificacion:
                        CargarDatosMatriz(Request["Codigo"], true);
                        break;
                    case TipoMatriz.Lectura:
                        CargarDatosMatriz(Request["Codigo"], true);
                        SoloLectura = true;
                        PonerSoloLecturaControles(true);
                        break;
                    case TipoMatriz.Aprobacion:
                        CargarDatosMatriz(Request["Codigo"], false);
                        this.seccionAprobador.Visible = true;
                        this.btnActualizar.Visible = true;
                        this.btnCancelar.Visible = true;
                        break;
                    default:
                        break;
                }
            }
        
        }

        private void CargarDatosMatriz(string codigo, bool modificar)
        {
            var matriz = modificar ? Servicio.ObtenerMatrizControl(codigo) : Servicio.ObtenerMatrizControlPorAprobar(codigo);
            ConexionSOXService.MatrizControles matrizAnterior = null;
            ConexionSOXService.MatrizControlesPorAprobar matrizNueva = null;
            if (matriz != null)
            {
                this.listCalidadEvidenciaCodigoAplicacion.SelectedValue = matriz.CalidadEvidenciaCodigoAplicacion;
                this.listCalidadEvidenciaCodigoImportanciaReporte.SelectedValue = matriz.CalidadEvidenciaCodigoImportanciaReporte;
                this.listCalidadEvidenciaCodigoTipoReporte.SelectedValue = matriz.CalidadEvidenciaCodigoTipoReporte;
                this.txtCalidadEvidenciaDescripcion.Text = matriz.CalidadEvidenciaDescripcion;
                this.txtCalidadEvidenciaDescripcionIntegridad.Text = matriz.CalidadEvidenciaDescripcionIntegridad;
                this.txtCalidadEvidenciaDescripcionRevisionesGerencia.Text = matriz.CalidadEvidenciaDescripcionRevisionesGerencia;
                this.txtCalidadEvidenciaDescripcionTransaccion.Text = matriz.CalidadEvidenciaDescripcionTransaccion;
                this.listCodigoActividadControl.SelectedValue = matriz.CodigoActividadControl;
                CheckBoxListSeleccionados(matriz.CodigoAplicacion, this.listCodigoAplicacion);
                CheckBoxListSeleccionados(matriz.CodigoDocumento, this.listCodigoDocumento);
                this.listFrecuenciaControl.SelectedValue = matriz.CodigoFrecuenciaControl;
                this.listNaturalezaControl.SelectedValue = matriz.CodigoNaturalezaControl;
                CheckBoxListSeleccionados(matriz.CodigoPuntoControl, this.listCodigoPuntoDeControl);
                this.listRiesgos.SelectedValue = matriz.CodigoSOX;
                this.listCodigoTiempoAplicacion.SelectedValue = matriz.CodigoTiempoAplicacion;
                this.listTipoControl.SelectedValue = matriz.CodigoTipoControl;
                this.listControlCompensatorioCodigoAplicacion.SelectedValue = matriz.ControlCompensatorioCodigoAplicacion;
                this.txtControlCompensatorioDescripcion.Text = matriz.ControlCompensatorioDescripcion;
                this.txtControlCompensatorioDescripcionEvidencia.Text = matriz.ControlCompensatorioDescripcionEvidencia;
                this.txtControlCompensatorioFechaInicio.Text = matriz.ControlCompensatorioFechaInicio.Value.Year + matriz.ControlCompensatorioFechaInicio.Value.ToString("-MM-dd");
                this.listCriterios.SelectedValue = matriz.CriterioControl;
                this.txtDeficienciaAnoAnterior.Checked = matriz.DeficienciaAnoAnterior;
                this.txtDescripcionControl.Text = matriz.Descripcion;
                this.listEstados.SelectedValue = matriz.Estado;
                this.listEvidenciaCodigoHerramientaAlmacenamiento.SelectedValue = matriz.EvidenciaCodigoHerramientaAlmacenamiento;
                this.listEvidenciaCodigoTiempoPermanencia.SelectedValue = matriz.EvidenciaCodigoTiempoPermanencia;
                this.txtEvidenciaDescripcionRestricciones.Text = matriz.EvidenciaDescripcionRestricciones;
                this.txtEvidenciaDescripcionRevision.Text = matriz.EvidenciaDescripcionRevision;
                this.txtEvidenciasArchivos.Text = matriz.EvidenciaRutaArchivos;
                this.listEvidencias.Visible = false;
                this.txtDescripcionActividadesTercero.Text = matriz.DescripcionActividadesTercero;
                CheckBoxListSeleccionados(matriz.ResponsableControl, this.listResponsableControl);
                //Inactivación de campos
                this.listCodigoPuntoDeControl.Enabled = false;
                this.listCodigoActividadControl.Enabled = false;
                this.btnActualizar.Text = "Actualizar";

                if (this.TipoDatosAMostrar == TipoMatriz.Aprobacion)
                {
                    matrizNueva = Servicio.ObtenerMatrizControlPorAprobar(codigo);
                    matrizAnterior = Servicio.ObtenerMatrizControl(codigo);
                    MarcarDatosModificados(matrizNueva, matrizAnterior);
                }
            }
        }

        private void MarcarDatosModificados(MatrizControlesPorAprobar matriz, ConexionSOXService.MatrizControles matrizAnterior)
        {
            Color colorResaltado = Color.LightGreen;
            if (matriz.CalidadEvidenciaCodigoAplicacion != matrizAnterior.CalidadEvidenciaCodigoAplicacion)
                this.listCalidadEvidenciaCodigoAplicacion.BackColor = colorResaltado;
            if(matriz.CalidadEvidenciaCodigoImportanciaReporte != matrizAnterior.CalidadEvidenciaCodigoImportanciaReporte)
                this.listCalidadEvidenciaCodigoImportanciaReporte.BackColor = colorResaltado;
            
            if (matriz.CalidadEvidenciaCodigoTipoReporte != matrizAnterior.CalidadEvidenciaCodigoTipoReporte)
                this.listCalidadEvidenciaCodigoTipoReporte.BackColor = colorResaltado;
            
            if (matriz.CalidadEvidenciaDescripcion != matrizAnterior.CalidadEvidenciaDescripcion)
                this.txtCalidadEvidenciaDescripcion.BackColor = colorResaltado;
            
            if (matriz.CalidadEvidenciaDescripcionIntegridad != matrizAnterior.CalidadEvidenciaDescripcionIntegridad)
                this.txtCalidadEvidenciaDescripcionIntegridad.BackColor = colorResaltado;
            
            if (matriz.CalidadEvidenciaDescripcionRevisionesGerencia != matrizAnterior.CalidadEvidenciaDescripcionRevisionesGerencia)
                this.txtCalidadEvidenciaDescripcionRevisionesGerencia.BackColor = colorResaltado;
            
            if (matriz.CalidadEvidenciaDescripcionTransaccion != matrizAnterior.CalidadEvidenciaDescripcionTransaccion)
                this.txtCalidadEvidenciaDescripcionTransaccion.BackColor = colorResaltado;
            
            if (matriz.Codigo != matrizAnterior.Codigo)
                this.listCodigoAplicacion.BackColor = colorResaltado;
            
            if (matriz.CodigoActividadControl!= matrizAnterior.CodigoActividadControl)
                this.listCodigoActividadControl.BackColor = colorResaltado;
            
            if (matriz.CodigoAplicacion != matrizAnterior.CodigoAplicacion)
                this.listCodigoAplicacion.BackColor = colorResaltado;

            if (matriz.CodigoDocumento != matrizAnterior.CodigoDocumento)
                this.listCodigoDocumento.BackColor = colorResaltado;

            if (matriz.CodigoFrecuenciaControl != matrizAnterior.CodigoFrecuenciaControl)
                this.listFrecuenciaControl.BackColor = colorResaltado;

            if (matriz.CodigoNaturalezaControl != matrizAnterior.CodigoNaturalezaControl)
                this.listNaturalezaControl.BackColor = colorResaltado;

            if (matriz.CodigoPuntoControl != matrizAnterior.CodigoPuntoControl)
                this.listCodigoPuntoDeControl.BackColor = colorResaltado;

            if (matriz.CodigoSOX!= matrizAnterior.CodigoSOX)
                this.listRiesgos.BackColor = colorResaltado;

            if (matriz.CodigoTiempoAplicacion != matrizAnterior.CodigoTiempoAplicacion)
                this.listCodigoTiempoAplicacion.BackColor = colorResaltado;

            if (matriz.CodigoTipoControl != matrizAnterior.CodigoTipoControl)
                this.listTipoControl.BackColor = colorResaltado;

            if (matriz.ControlCompensatorioCodigoAplicacion!= matrizAnterior.ControlCompensatorioCodigoAplicacion)
                this.listControlCompensatorioCodigoAplicacion.BackColor = colorResaltado;

            if (matriz.ControlCompensatorioDescripcion!= matrizAnterior.ControlCompensatorioDescripcion)
                this.txtControlCompensatorioDescripcion.BackColor = colorResaltado;

            if (matriz.ControlCompensatorioDescripcionEvidencia != matrizAnterior.ControlCompensatorioDescripcionEvidencia)
                this.txtControlCompensatorioDescripcionEvidencia.BackColor = colorResaltado;

            if (matriz.ControlCompensatorioFechaInicio != matrizAnterior.ControlCompensatorioFechaInicio)
                this.txtControlCompensatorioFechaInicio.BackColor = colorResaltado;

            if (matriz.CriterioControl != matrizAnterior.CriterioControl)
                this.listCriterios.BackColor = colorResaltado;

            if (matriz.DeficienciaAnoAnterior != matrizAnterior.DeficienciaAnoAnterior)
                this.txtDeficienciaAnoAnterior.BackColor = colorResaltado;

            if (matriz.Descripcion != matrizAnterior.Descripcion)
                this.txtDescripcionControl.BackColor = colorResaltado;

            if (matriz.DescripcionActividadesTercero != matrizAnterior.DescripcionActividadesTercero)
                this.txtDescripcionActividadesTercero.BackColor = colorResaltado;

            if (matriz.EvidenciaCodigoHerramientaAlmacenamiento  != matrizAnterior.EvidenciaCodigoHerramientaAlmacenamiento)
                this.listEvidenciaCodigoHerramientaAlmacenamiento.BackColor = colorResaltado;

            if (matriz.EvidenciaCodigoTiempoPermanencia != matrizAnterior.EvidenciaCodigoTiempoPermanencia)
                this.listEvidenciaCodigoTiempoPermanencia.BackColor = colorResaltado;

            if (matriz.EvidenciaDescripcionRestricciones != matrizAnterior.EvidenciaDescripcionRestricciones)
                this.txtEvidenciaDescripcionRestricciones.BackColor = colorResaltado;

            if (matriz.EvidenciaDescripcionRevision!= matrizAnterior.EvidenciaDescripcionRevision)
                this.txtEvidenciaDescripcionRevision.BackColor = colorResaltado;

            if (matriz.EvidenciaRutaArchivos != matrizAnterior.EvidenciaRutaArchivos)
                this.txtEvidenciasArchivos.BackColor = colorResaltado;

            if (matriz.ResponsableControl != matrizAnterior.ResponsableControl)
                this.listResponsableControl.BackColor = colorResaltado;
        }

        private void CheckBoxListSeleccionados(string selecciones, CheckBoxList elemento)
        {
            if (!string.IsNullOrEmpty(selecciones))
            {
                var elementosSeleccionados = selecciones.Split(',');
                foreach (ListItem item in elemento.Items)
                {
                    foreach (var seleccion in elementosSeleccionados)
                    {
                        if (seleccion == item.Value)
                            item.Selected = true;
                    }
                }
            }
        }

        private void CargarListaRiesgos()
        {
            this.listRiesgos.DataTextField = "CodigoSOX";
            this.listRiesgos.DataValueField = "CodigoSOX";
            this.listRiesgos.DataSource = Servicio.ObtenerRiesgosSOX();
            this.listRiesgos.DataBind();
        }

        private void CargarListaPuntosControl()
        {
            var puntosControl = Servicio.ObtenerPuntosControl();
            foreach (var item in puntosControl)
            {
                ListItem newItem = new ListItem(item.PuntoDeControl, item.Codigo);
                this.listCodigoPuntoDeControl.Items.Add(newItem);
            }
        }

        private void CargarListaActividadesControl()
        {
            this.listCodigoActividadControl.DataTextField = "NombreActividad";
            this.listCodigoActividadControl.DataValueField = "Codigo";
            this.listCodigoActividadControl.DataSource = Servicio.ObtenerActividadesControl();
            this.listCodigoActividadControl.DataBind();
        }

        private void CargarListaAplicaciones()
        {
            var aplicaciones = Servicio.ObtenerAplicaciones();
            foreach (var item in aplicaciones)
            {
                ListItem newItem = new ListItem(item.NombreAplicacion, item.Codigo);
                ListItem newItemB = new ListItem(item.NombreAplicacion, item.Codigo);
                ListItem newItemC = new ListItem(item.NombreAplicacion, item.Codigo);
                ListItem newItemD = new ListItem(item.NombreAplicacion, item.Codigo);
                this.listCodigoAplicacion.Items.Add(newItem);
                this.listCalidadEvidenciaCodigoAplicacion.Items.Add(newItemB);
                this.listControlCompensatorioCodigoAplicacion.Items.Add(newItemC);
                if(item.HerramientaAlmacenamiento == "True")
                    this.listEvidenciaCodigoHerramientaAlmacenamiento.Items.Add(newItemD);
            }
        }

        private void CargarListaJefatura()
        {
            var jefaturas = Servicio.ObtenerJefaturas();
            foreach (var item in jefaturas)
            {
                ListItem newItem = new ListItem(item.CodigoArea, item.Direccion);
                this.listResponsableControl.Items.Add(newItem);
            }
        }

        private void PonerSoloLecturaChildControls(System.Web.UI.Control control)
        {
            if (control.GetType() == typeof(TextBox))
            {
                ((TextBox)control).Enabled = false;
            }
            if (control.GetType() == typeof(DropDownList))
            {
                ((DropDownList)control).Enabled = false;
            }
            if (control.GetType() == typeof(CheckBoxList))
            {
                ((CheckBoxList)control).Enabled = false;
            }
            if (control.GetType() == typeof(CheckBox))
            {
                ((CheckBox)control).Enabled = false;
            }
            if (control.GetType() == typeof(FileUpload))
            {
                ((FileUpload)control).Enabled = false;
            }
        }

        private void PonerSoloLecturaControles(bool modeRead)
        {
            if (SoloLectura)
            {
                foreach (System.Web.UI.Control item in this.Controls)
                {
                    PonerSoloLecturaChildControls(item);
                }
                this.btnActualizar.Visible = false;
                if(modeRead)
                    this.btnCancelar.Visible = true;
                else
                    this.btnCancelar.Visible = false;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string respuesta = string.Empty;
            switch (_TipoDatosAMostrar)
            {
                case TipoMatriz.Nueva:
                    respuesta = CrearNuevaMatriz();
                    break;
                case TipoMatriz.Aprobacion:
                    respuesta = AprobarRechazarModificacion();
                    break;
                case TipoMatriz.Modificacion:
                    respuesta = ActualizarMatriz();
                    break;
                case TipoMatriz.Lectura:
                    respuesta = ActualizarMatriz();
                    break;
                default:
                    break;
            }
            if(!string.IsNullOrEmpty(respuesta))
                Response.Write("<script>alert('" + respuesta + "');location.href='/MatrizControles/ConsultarMatrizControles'</script>");
        }

        private string CrearNuevaMatriz()
        {
            var datosNuevaMatriz = ObtenerDatosMatrizControles();
            datosNuevaMatriz.Codigo = this.listRiesgos.SelectedValue + this.listCodigoActividadControl.SelectedValue + new Random().Next();
            return Servicio.CrearActualizarMatrizControl(datosNuevaMatriz);
        }

        private string ActualizarMatriz()
        {
            var matrizActual = Servicio.ObtenerMatrizControl(Request["Codigo"]);
            var matrizModificada = ObtenerDatosMatrizControlesPorAprobar();
            matrizModificada.Codigo = matrizActual.Codigo;
            matrizActual.Estado = "RevisionModificacion";
            Servicio.CrearActualizarMatrizControl(matrizActual);
            return Servicio.CrearActualizarMatrizControlPorAprobar(matrizModificada);
            
        }

        private string AprobarRechazarModificacion()
        {
            this.lblMessage.Text = string.Empty;
            string respuesta = string.Empty;

            if (string.IsNullOrWhiteSpace(this.listAprobarCambios.SelectedValue))
            {
                this.lblMessage.Text = "Debe seleccionar un estado para la aprobación.";
                return string.Empty;
            }
            if (string.IsNullOrWhiteSpace(this.txtObservacionesAprobacion.Text))
            {
                this.lblMessage.Text = "Debe escribir las observaciones de la aprobación/rechazo.";
                return string.Empty;
            }
            
            var matrizModificada = Servicio.ObtenerMatrizControlPorAprobar(Request["Codigo"]);
            var matrizOriginal = Servicio.ObtenerMatrizControl(Request["Codigo"]);
            
            if (this.listAprobarCambios.SelectedValue == "Si")
            {
                matrizOriginal = matrizModificada;
                matrizOriginal.Estado = "AprobacionModificacion";
                matrizOriginal.ModificacionAprobado = true;
            }
            else
            {
                matrizOriginal.ModificacionAprobado = false;
            }
            
            matrizModificada.ModificacionFechaAprobacion = DateTime.Now;
            matrizOriginal.ModificacionFechaAprobacion = DateTime.Now;
            matrizOriginal.ModificacionObservaciones = this.txtObservacionesAprobacion.Text;
            Servicio.CrearActualizarMatrizControlPorAprobar(matrizModificada);
            return Servicio.CrearActualizarMatrizControl(matrizOriginal);
            
        }

        private ConexionSOXService.MatrizControles ObtenerDatosMatrizControles()
        {
            var matriz = new ConexionSOXService.MatrizControles();
            matriz.Autor = Context.User.Identity.Name;
            matriz.CalidadEvidenciaCodigoAplicacion = this.listCalidadEvidenciaCodigoAplicacion.SelectedValue;
            matriz.CalidadEvidenciaCodigoImportanciaReporte = this.listCalidadEvidenciaCodigoImportanciaReporte.SelectedValue;
            matriz.CalidadEvidenciaCodigoTipoReporte = this.listCalidadEvidenciaCodigoTipoReporte.SelectedValue;
            matriz.CalidadEvidenciaDescripcion = this.txtCalidadEvidenciaDescripcion.Text;
            matriz.CalidadEvidenciaDescripcionIntegridad = this.txtCalidadEvidenciaDescripcionIntegridad.Text;
            matriz.CalidadEvidenciaDescripcionRevisionesGerencia = this.txtCalidadEvidenciaDescripcionRevisionesGerencia.Text;
            matriz.CalidadEvidenciaDescripcionTransaccion = this.txtCalidadEvidenciaDescripcionTransaccion.Text;
            
                
            matriz.CodigoActividadControl = this.listCodigoActividadControl.SelectedValue;
            matriz.CodigoAplicacion = ObtenerElementoSeleccionados(this.listCodigoAplicacion);
            matriz.CodigoDocumento = ObtenerElementoSeleccionados(this.listCodigoDocumento);
            matriz.CodigoFrecuenciaControl = this.listFrecuenciaControl.SelectedValue;
            matriz.CodigoNaturalezaControl = this.listNaturalezaControl.SelectedValue;
            matriz.CodigoPuntoControl = ObtenerElementoSeleccionados(this.listCodigoPuntoDeControl);
            matriz.CodigoSOX = this.listRiesgos.SelectedValue;
            matriz.CodigoTiempoAplicacion = this.listCodigoTiempoAplicacion.SelectedValue;
            matriz.CodigoTipoControl = this.listTipoControl.SelectedValue;
            matriz.ControlCompensatorioCodigoAplicacion = this.listControlCompensatorioCodigoAplicacion.SelectedValue;
            matriz.ControlCompensatorioDescripcion = this.txtControlCompensatorioDescripcion.Text;
            matriz.ControlCompensatorioDescripcionEvidencia = this.txtControlCompensatorioDescripcionEvidencia.Text;
            matriz.ControlCompensatorioFechaCreacion = DateTime.Now;
            DateTime fechaInicio = Convert.ToDateTime(null);
            DateTime.TryParse(this.txtControlCompensatorioFechaInicio.Text, out fechaInicio);
            matriz.ControlCompensatorioFechaInicio = fechaInicio;
            matriz.CriterioControl = this.listCriterios.SelectedValue;
            matriz.DeficienciaAnoAnterior = this.txtDeficienciaAnoAnterior.Checked;
            matriz.Descripcion = this.txtDescripcionControl.Text;
            matriz.Estado = this.listEstados.SelectedValue;
            matriz.EvidenciaCodigoHerramientaAlmacenamiento = this.listEvidenciaCodigoHerramientaAlmacenamiento.SelectedValue;
            matriz.EvidenciaCodigoTiempoPermanencia = this.listEvidenciaCodigoTiempoPermanencia.SelectedValue;
            matriz.EvidenciaDescripcionRestricciones = this.txtEvidenciaDescripcionRestricciones.Text;
            matriz.EvidenciaDescripcionRevision = this.txtEvidenciaDescripcionRevision.Text;
            matriz.EvidenciaRutaArchivos = GuardarEvidencias();
            matriz.DescripcionActividadesTercero = this.txtDescripcionActividadesTercero.Text;
            matriz.ResponsableControl = ObtenerElementoSeleccionados(this.listResponsableControl);
            return matriz;
        }

        private string ObtenerElementoSeleccionados(CheckBoxList elementoOrigen)
        {
            List<string> elementosSeleccionados = new List<string>();
            foreach (ListItem item in elementoOrigen.Items)
            {
                if (item.Selected)
                    elementosSeleccionados.Add(item.Value);
            }
            return String.Join(",", elementosSeleccionados);
        }

        private ConexionSOXService.MatrizControlesPorAprobar ObtenerDatosMatrizControlesPorAprobar()
        {
            var matriz = new ConexionSOXService.MatrizControlesPorAprobar();
            matriz.Autor = Context.User.Identity.Name;
            matriz.CalidadEvidenciaCodigoAplicacion = this.listCalidadEvidenciaCodigoAplicacion.SelectedValue;
            matriz.CalidadEvidenciaCodigoImportanciaReporte = this.listCalidadEvidenciaCodigoImportanciaReporte.SelectedValue;
            matriz.CalidadEvidenciaCodigoTipoReporte = this.listCalidadEvidenciaCodigoTipoReporte.SelectedValue;
            matriz.CalidadEvidenciaDescripcion = this.txtCalidadEvidenciaDescripcion.Text;
            matriz.CalidadEvidenciaDescripcionIntegridad = this.txtCalidadEvidenciaDescripcionIntegridad.Text;
            matriz.CalidadEvidenciaDescripcionRevisionesGerencia = this.txtCalidadEvidenciaDescripcionRevisionesGerencia.Text;
            matriz.CalidadEvidenciaDescripcionTransaccion = this.txtCalidadEvidenciaDescripcionTransaccion.Text;
            matriz.CodigoActividadControl = this.listCodigoActividadControl.SelectedValue;
            matriz.CodigoAplicacion = ObtenerElementoSeleccionados(this.listCodigoAplicacion);
            matriz.CodigoDocumento = ObtenerElementoSeleccionados(this.listCodigoDocumento);
            matriz.CodigoFrecuenciaControl = this.listFrecuenciaControl.SelectedValue;
            matriz.CodigoNaturalezaControl = this.listNaturalezaControl.SelectedValue;
            matriz.CodigoPuntoControl = ObtenerElementoSeleccionados(this.listCodigoPuntoDeControl);
            matriz.CodigoSOX = this.listRiesgos.SelectedValue;
            matriz.CodigoTiempoAplicacion = this.listCodigoTiempoAplicacion.SelectedValue;
            matriz.CodigoTipoControl = this.listTipoControl.SelectedValue;
            matriz.ControlCompensatorioCodigoAplicacion = this.listControlCompensatorioCodigoAplicacion.SelectedValue;
            matriz.ControlCompensatorioDescripcion = this.txtControlCompensatorioDescripcion.Text;
            matriz.ControlCompensatorioDescripcionEvidencia = this.txtControlCompensatorioDescripcionEvidencia.Text;
            matriz.ControlCompensatorioFechaCreacion = DateTime.Now;
            DateTime fechaInicio = Convert.ToDateTime(null);
            DateTime.TryParse(this.txtControlCompensatorioFechaInicio.Text, out fechaInicio);
            matriz.ControlCompensatorioFechaInicio = fechaInicio;
            matriz.CriterioControl = this.listCriterios.SelectedValue;
            matriz.DeficienciaAnoAnterior = this.txtDeficienciaAnoAnterior.Checked;
            matriz.Descripcion = this.txtDescripcionControl.Text;
            matriz.Estado = this.listEstados.SelectedValue;
            matriz.EvidenciaCodigoHerramientaAlmacenamiento = this.listEvidenciaCodigoHerramientaAlmacenamiento.SelectedValue;
            matriz.EvidenciaCodigoTiempoPermanencia = this.listEvidenciaCodigoTiempoPermanencia.SelectedValue;
            matriz.EvidenciaDescripcionRestricciones = this.txtEvidenciaDescripcionRestricciones.Text;
            matriz.EvidenciaDescripcionRevision = this.txtEvidenciaDescripcionRevision.Text;
            matriz.EvidenciaRutaArchivos = GuardarEvidencias();
            return matriz;
        }

        private string GuardarEvidencias()
        {
            List<string> archivos = new List<string>();
            if (this.listEvidencias.HasFiles)
            {
                foreach (var item in this.listEvidencias.PostedFiles)
                {
                    try
                    {
                        string path = Path.Combine(ConfigurationManager.AppSettings["RutaEvidencias"], item.FileName);
                        item.SaveAs(path);
                        archivos.Add(path);
                    }
                    catch { continue; }
                }
            }
            return String.Join(";", archivos);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/MatrizControles/ConsultarMatrizControles");
        }
    }

    public enum TipoMatriz
    {
        Nueva,
        Modificacion,
        Aprobacion,
        Lectura
    }
}