using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.PuntoControl
{
    public partial class ConsultarPuntosControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("PuntosControl"))
            {
                Response.Redirect("/Account/AccessDenied");
            }
            if (!this.IsPostBack)
                CargarInformacion();
        }

        private void CargarInformacion()
        {
            this.lblMessage.Text = string.Empty;
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var registros = servicio.ObtenerPuntosControl();
            this.gvPuntosControl.DataSource = registros;
            this.gvPuntosControl.DataBind();
        }

        protected void btnCargarPuntosControl_Click(object sender, EventArgs e)
        {
            if (this.cargarPuntosControl.FileName == null)
            {
                this.lblMessage.Text = "Debe seleccionar un archivo para iniciar el proceso.";
                return;
            }
            if (!this.cargarPuntosControl.FileName.ToLower().Contains("csv"))
            {
                this.lblMessage.Text = "El archivo a cargar debe ser de extensión CSV.";
                return;
            }

            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.lblConfirmacion.Text = servicio.ProcesarArchivPuntosControl(this.cargarPuntosControl.FileName, this.cargarPuntosControl.FileBytes);
            CargarInformacion();
        }

        protected void gvPuntosControl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow fila = e.Row;
                ImageButton imageControl = fila.FindControl("editButton") as ImageButton;
                if (imageControl != null)
                    imageControl.PostBackUrl = "/PuntoControl/CrearPuntoControl.aspx?Codigo=" + fila.Cells[0].Text;
            }
        }
    }
}