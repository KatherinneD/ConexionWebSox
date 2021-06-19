using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Aplicaciones
{
    public partial class ConsultarAplicaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("Aplicacion"))
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
            var registros = servicio.ObtenerAplicaciones();
            this.gvAplicacion.DataSource = registros;
            this.gvAplicacion.DataBind();
        }

        protected void btnCargarAplicacion_Click(object sender, EventArgs e)
        {
            if (this.cargarAplicacion.FileName == null)
            {
                this.lblMessage.Text = "Debe seleccionar un archivo para iniciar el proceso.";
                return;
            }
            if (!this.cargarAplicacion.FileName.ToLower().Contains("csv"))
            {
                this.lblMessage.Text = "El archivo a cargar debe ser de extensión CSV.";
                return;
            }

            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.lblConfirmacion.Text = servicio.ProcesarArchivoAplicaciones(this.cargarAplicacion.FileName, this.cargarAplicacion.FileBytes);
            CargarInformacion();
        }

        protected void gvAplicacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow fila = e.Row;
                ImageButton imageControl = fila.FindControl("editButton") as ImageButton;
                if (imageControl != null)
                    imageControl.PostBackUrl = "/Aplicaciones/CrearAplicacion?Codigo=" + fila.Cells[0].Text;
            }
        }
    }
}