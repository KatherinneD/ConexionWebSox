using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.MatrizControles
{
    public partial class CrearMatrizControles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("MatrizControles"))
            {
                Response.Redirect("/Account/AccessDenied");
            }
            if (!this.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["Approve"]) && !string.IsNullOrEmpty(Request["Codigo"]))
                {
                    InicializarControlesProcesoAprobacion();
                }
                else if (!string.IsNullOrEmpty(Request["Codigo"]) && !string.IsNullOrEmpty(Request["Mode"]))
                {
                    this.matrizNuevo.IDAleatorioUI = new Random().Next();
                    this.matrizNuevo.TipoDatosAMostrar = TipoMatriz.Modificacion;
                    this.matrizNuevo.CargarDatos();
                }
                else if (!string.IsNullOrEmpty(Request["Codigo"]))
                {
                    this.matrizNuevo.IDAleatorioUI = new Random().Next();
                    this.matrizNuevo.TipoDatosAMostrar = TipoMatriz.Lectura;
                    this.matrizNuevo.CargarDatos();
                }
                else
                {
                    this.matrizNuevo.IDAleatorioUI = new Random().Next();
                    this.matrizNuevo.TipoDatosAMostrar = TipoMatriz.Nueva;
                    this.matrizNuevo.CargarDatos();
                }
            }
            
       }

        private void InicializarControlesProcesoAprobacion()
        {
            this.matrizNuevo.TipoDatosAMostrar = TipoMatriz.Modificacion;
            this.matrizNuevo.SoloLectura = true;
            this.matrizNuevo.IDAleatorioUI = new Random().Next();
            this.matrizComparativa.TipoDatosAMostrar = TipoMatriz.Aprobacion;
            this.matrizComparativa.SoloLectura = true;
            this.matrizComparativa.Visible = true;
            this.matrizNuevo.CargarDatos();
            this.matrizComparativa.IDAleatorioUI = new Random().Next();
            this.matrizComparativa.CargarDatos();
            this.tituloValoresAnteriores.Visible = true;
            this.tituloValoresNuevos.Visible = true;
        }
    }
}