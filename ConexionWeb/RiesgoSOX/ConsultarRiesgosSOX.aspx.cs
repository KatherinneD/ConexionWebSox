using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.RiesgoSOX
{
    public partial class ConsultarRiesgosSOX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("Riesgos"))
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
            var riesgos = servicio.ObtenerRiesgosSOX();
            this.gvRiesgos.DataSource = riesgos;
            this.gvRiesgos.DataBind();
        }

        protected void gvRiesgos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow fila = e.Row;
                ImageButton imageControl = fila.FindControl("editButton") as ImageButton;
                imageControl.Visible = false;
                if (imageControl != null)
                    imageControl.PostBackUrl = "/RiesgoSOX/CrearRiesgoSOX.aspx?CodigoSOX=" + fila.Cells[1].Text;
                if (fila.Cells[5].Text.Contains("Activo") || fila.Cells[5].Text.Contains("EnUso"))
                    imageControl.Visible = true;
            }
        }
    }
}