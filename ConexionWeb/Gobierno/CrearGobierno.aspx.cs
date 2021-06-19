using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Gobierno
{
    public partial class CrearGobierno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("Gobierno"))
            {
                Response.Redirect("/Account/AccessDenied.aspx");
            }
            if (!this.IsPostBack)
            {
                if (Request["Codigo"] != null)
                {
                    CargarInformacionGobierno(Request["Codigo"]);
                }
            }
        }
        private void CargarInformacionGobierno(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var gobierno = servicio.ObtenerRegistroGobierno(codigo);
            if (gobierno != null)
            {
                this.txtCodigo.Text = gobierno.Codigo;
                this.txtNombreProceso.Text = gobierno.NombreProceso;
                this.txtURL.Text = gobierno.URL;
                this.lstEstados.SelectedValue = gobierno.Estado;
                this.btnActualizar.Text = "Actualizar";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo código es obligatorio.");
            if (string.IsNullOrEmpty(txtNombreProceso.Text))
                errores.AppendLine("El campo nombre del proceso es obligatorio.");
            if (string.IsNullOrEmpty(txtURL.Text))
                errores.AppendLine("El campo URL es obligatorio.");
            if (string.IsNullOrEmpty(lstEstados.SelectedValue))
                errores.AppendLine("El campo estado es obligatorio.");
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarGobierno();
        }

        private void CrearActualizarGobierno()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            string inactivadoPor = string.Empty;
            try
            {
                if (lstEstados.SelectedValue == "EnUso")
                {
                    SmtpClient SmtpServer = new SmtpClient();
                    MailMessage mail = new MailMessage(new MailAddress(ConfigurationManager.AppSettings["MailFrom"]), new MailAddress(ConfigurationManager.AppSettings["MailTo"]));
                    mail.Subject = "Alerta de modificación Gobierno";
                    mail.Body = "Se ha modificado el gobierno " + this.txtCodigo.Text + " que se encontraba en uso. Usuario que modificó: " + inactivadoPor;
                    SmtpServer.Send(mail);
                
                }
                else if (lstEstados.SelectedValue == "Inactivo")
                {
                    inactivadoPor = User.Identity.Name;
                }
            }
            catch (Exception ex) { }
            var respuesta = servicio.CrearActualizarRegistroGobierno(new ConexionSOXService.Gobierno()
            {
                Codigo = this.txtCodigo.Text,
                NombreProceso = this.txtNombreProceso.Text,
                URL = this.txtURL.Text,
                Estado = this.lstEstados.SelectedValue,
                InactivadoPor = inactivadoPor
            }); ;
            Response.Write("<script>alert('" + respuesta + "');location.href='/Gobierno/ConsultarDocumentos'</script>");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Gobierno/ConsultarDocumentos");
        }
    }
}