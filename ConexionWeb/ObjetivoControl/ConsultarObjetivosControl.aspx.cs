using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.ObjetivoControl
{
    public partial class ConsultarObjetivosControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("ObjetivosControl"))
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
            var registros = servicio.ObtenerObjetivosControl();
            this.gvObjetivosControl.DataSource = registros;
            this.gvObjetivosControl.DataBind();
        }

        protected void btnCargarObjetivosControl_Click(object sender, EventArgs e)
        {
            if (this.cargarObjetivosControl.FileName == null)
            {
                this.lblMessage.Text = "Debe seleccionar un archivo para iniciar el proceso.";
                return;
            }
            if (!this.cargarObjetivosControl.FileName.ToLower().Contains("csv"))
            {
                this.lblMessage.Text = "El archivo a cargar debe ser de extensión CSV.";
                return;
            }

            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.lblConfirmacion.Text = servicio.ProcesarArchivoObjetivosControl(this.cargarObjetivosControl.FileName, this.cargarObjetivosControl.FileBytes);
            CargarInformacion();
        }

        protected void gvObjetivosControl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow fila = e.Row;
                ImageButton imageControl = fila.FindControl("editButton") as ImageButton;
                if (imageControl != null)
                    imageControl.PostBackUrl = "/ObjetivoControl/CrearObjetivoControl.aspx?Codigo=" + fila.Cells[0].Text;
            }
        }
    }
}