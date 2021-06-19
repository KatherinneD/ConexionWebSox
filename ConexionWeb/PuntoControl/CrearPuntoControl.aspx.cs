using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.PuntoControl
{
    public partial class CrearPuntoControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("PuntosControl"))
            {
                Response.Redirect("/Account/AccessDenied.aspx");
            }
            if (!this.IsPostBack)
            {
                if (Request["Codigo"] != null)
                {
                    CargarInformacionPuntosControl(Request["Codigo"]);
                }
                else
                {
                    CargarConsecutivoCodigo();
                }
            }
        }

        private void CargarConsecutivoCodigo()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            txtCodigo.Text = servicio.ObtenerConsecutivoPuntoControl().ToString();
        }

        private void CargarInformacionPuntosControl(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var PuntoControl = servicio.ObtenerPuntoControl(int.Parse(codigo));

            if (PuntoControl != null)
            {
                this.txtCodigo.Text = PuntoControl.Codigo.ToString();
                this.txtPuntoControl.Text = PuntoControl.PuntoDeControl;
                this.lstEstados.SelectedValue = PuntoControl.Estado;
                this.btnActualizar.Text = "Actualizar";
            }

            if (PuntoControl.Estado == "Uso")
            {
                this.txtCodigo.Enabled = false;
                this.txtPuntoControl.Enabled = false;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo código es obligatorio.");
            if (string.IsNullOrEmpty(txtPuntoControl.Text))
                errores.AppendLine("El campo Punto de control es obligatorio.");
            if (string.IsNullOrEmpty(lstEstados.SelectedValue))
                errores.AppendLine("El campo estado es obligatorio.");
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarPuntosControl();
        }

        private void CrearActualizarPuntosControl()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var inactivadoPor = string.Empty;
            if (lstEstados.SelectedValue == "Inactivo")
            {
                inactivadoPor = User.Identity.Name;
            }
            var respuesta = servicio.CrearActualizarPuntosControl(new ConexionSOXService.PuntoControl()
            {
                Autor = User.Identity.Name,
                Codigo = int.Parse(this.txtCodigo.Text),
                PuntoDeControl = this.txtPuntoControl.Text,
                InactivadoPor = inactivadoPor,
                Estado = this.lstEstados.SelectedValue
            });
            Response.Write("<script>alert('" + respuesta + "');location.href='/PuntoControl/ConsultarPuntosControl'</script>");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PuntoControl/ConsultarPuntosControl");
        }
    }
}