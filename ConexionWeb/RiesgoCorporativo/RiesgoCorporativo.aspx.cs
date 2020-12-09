using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.RiesgoCorporativo
{
    public partial class RiesgoCorporativo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("Riesgos"))
            {
                Response.Redirect("/Account/AccessDenied.aspx");
            }
            if (!this.IsPostBack)
            {
                
                CargarInformacion();
            }
        }

        private void CargarInformacion()
        {
            this.lblMessage.Text = string.Empty;
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var riesgos = servicio.ObtenerRiesgosCorporativos();
            this.gvRiesgos.DataSource = riesgos;
            this.gvRiesgos.DataBind();
        }


        protected void btnCargarRiesgos_Click(object sender, EventArgs e)
        {
            if( this.cargarRiesgos.FileName == null)
            {
                this.lblMessage.Text = "Debe seleccionar un archivo para iniciar el proceso.";
                return;
            }
            if (!this.cargarRiesgos.FileName.ToLower().Contains("csv"))
            {
                this.lblMessage.Text = "El archivo a cargar debe ser de extensión CSV.";
                return;
            }

            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.lblConfirmacion.Text = servicio.ProcesarRiesgosCorporativos(this.cargarRiesgos.FileName, this.cargarRiesgos.FileBytes);
            CargarInformacion();
        }
    }
}