using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.ObjetivoControl
{
    public partial class CrearObjetivoControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("ObjetivosControl"))
            {
                Response.Redirect("/Account/AccessDenied.aspx");
            }
            if (!this.IsPostBack)
            {
                if (Request["Codigo"] != null)
                {
                    CargarInformacionObjetivosControl(Request["Codigo"]);
                }
            }
        }

        private void CargarInformacionObjetivosControl(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var objetivoControl = servicio.ObtenerObjetivoControl(codigo);
            
            if (objetivoControl != null)
            {
                this.txtCodigo.Text = objetivoControl.Codigo;
                this.txtObjetivoControl.Text = objetivoControl.ObjetivoDeControl;
                this.lstEstados.SelectedValue = objetivoControl.Estado;
                this.btnActualizar.Text = "Actualizar";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo código es obligatorio.");
            if (string.IsNullOrEmpty(txtObjetivoControl.Text))
                errores.AppendLine("El campo objetivo de control es obligatorio.");
            if (string.IsNullOrEmpty(lstEstados.SelectedValue))
                errores.AppendLine("El campo estado es obligatorio.");
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarObjetivosControl();
        }

        private void CrearActualizarObjetivosControl()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var inactivadoPor = string.Empty;
            if(lstEstados.SelectedValue == "Inactivo")
            {
                inactivadoPor = User.Identity.Name;
            }
            var respuesta = servicio.CrearActualizarObjetivosControl(new ConexionSOXService.ObjetivoControl()
            {
                Autor = User.Identity.Name,
                Codigo = this.txtCodigo.Text,
                ObjetivoDeControl = this.txtObjetivoControl.Text,
                InactivadoPor = inactivadoPor,
                Estado = this.lstEstados.SelectedValue
            }) ; 
            Response.Write("<script>alert('" + respuesta + "');location.href='/ObjetivoControl/ConsultarObjetivosControl'</script>");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ObjetivoControl/ConsultarObjetivosControl");
        }
        
    }
}