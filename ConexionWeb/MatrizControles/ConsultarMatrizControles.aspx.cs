using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.MatrizControles
{
    public partial class ConsultarMatrizControles : System.Web.UI.Page
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
                CargarInformacion();
        }

        private void CargarInformacion()
        {
            this.lblMessage.Text = string.Empty;
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var registros = servicio.ObtenerMatricesControl();
            this.gvMatrizControles.DataSource = registros;
            this.gvMatrizControles.DataBind();
        }

        protected void gvMatrizControles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow fila = e.Row;
                ImageButton imageControl = fila.FindControl("editButton") as ImageButton;
                if (imageControl != null)
                    imageControl.PostBackUrl = "/MatrizControles/CrearMatrizControles.aspx?Codigo=" + fila.Cells[0].Text + "&Mode=Edit";

                ImageButton showButtonControl = fila.FindControl("showButton") as ImageButton;
                if (showButtonControl != null)
                    showButtonControl.PostBackUrl = "/MatrizControles/CrearMatrizControles.aspx?Codigo=" + fila.Cells[0].Text;

                ImageButton approveControl = fila.FindControl("approveButton") as ImageButton;
                if (approveControl != null)
                    approveControl.PostBackUrl = "/MatrizControles/CrearMatrizControles.aspx?Codigo=" + fila.Cells[0].Text + "&Approve=true";
                if (e.Row.Cells[3].Text != "RevisionModificacion")
                    approveControl.Visible = false;
            }
        }
    }
}