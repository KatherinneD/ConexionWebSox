using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Jefatura
{
    public partial class ConsultarJefaturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("Jefatura"))
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
            var registros = servicio.ObtenerJefaturas();
            this.gvJefatura.DataSource = registros;
            this.gvJefatura.DataBind();
        }

        protected void btnCargarJefatura_Click(object sender, EventArgs e)
        {
            if (this.cargarJefatura.FileName == null)
            {
                this.lblMessage.Text = "Debe seleccionar un archivo para iniciar el proceso.";
                return;
            }
            if (!this.cargarJefatura.FileName.ToLower().Contains("csv"))
            {
                this.lblMessage.Text = "El archivo a cargar debe ser de extensión CSV.";
                return;
            }

            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.lblConfirmacion.Text = servicio.ProcesarArchivoJefaturas(this.cargarJefatura.FileName, this.cargarJefatura.FileBytes);
            CargarInformacion();
        }

        protected void gvJefatura_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow fila = e.Row;
                ImageButton imageControl = fila.FindControl("editButton") as ImageButton;
                if (imageControl != null)
                    imageControl.PostBackUrl = "/Jefatura/CrearJefatura.aspx?Codigo=" + fila.Cells[0].Text;
            }
        }
    }
}