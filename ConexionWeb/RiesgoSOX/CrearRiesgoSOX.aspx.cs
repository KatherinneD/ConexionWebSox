using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.RiesgoSOX
{
    public partial class CrearRiesgoSOX : System.Web.UI.Page
    {
        private static bool EnUso { get; set; }

        private static bool Activo { get; set; }
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
                CargarRiesgosCorporativos();
                CargarUsuarios();
                if (Request["CodigoSOX"] != null)
                {
                    CargarInformacionRiesgo(Request["CodigoSOX"]);
                }
            }
        }

        private void CargarInformacionRiesgo(string codigoRiesgo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var riesgo = servicio.ObtenerRiesgoSOX(codigoRiesgo);
            if(riesgo != null)
            {
                string codigoSOX = riesgo.CodigoSOX;
                if (codigoSOX.Contains("SOX"))
                {
                    codigoSOX = codigoSOX.Replace("SOX", "");
                }
                this.listAprobadoPor.SelectedValue = riesgo.AprobadoPor;
                this.txtDescripcionSOX.Text = riesgo.DescripcionSOX;
                this.txtFechaCreacion.Text = riesgo.FechaCreacion.Year + riesgo.FechaCreacion.ToString("-MM-dd");
                this.listNivel.SelectedValue = riesgo.NivelSOX;
                this.txtRiesgoSOX.Text = codigoSOX;
                this.lstEstados.SelectedValue = riesgo.Estado;
                foreach (ListItem item in lstRiesgosCorporativos.Items)
                {
                    if (item.Value.Contains(riesgo.CodigoRiesgoCorporativo))
                    {
                        lstRiesgosCorporativos.SelectedValue = item.Value;
                        break;
                    }
                }
                this.btnActualizar.Text = "Actualizar";
                if (riesgo.Estado == "EnUso")
                    EnUso = true;
                else
                    EnUso = false;

                if (riesgo.Estado == "Activo")
                    Activo = true;
                else
                    Activo = false;
                InactivarCamposSegunEstado();
            }
        }

        private void InactivarCamposSegunEstado()
        {
            this.lstRiesgosCorporativos.Enabled = false;
            this.txtRiesgoSOX.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.lstEstados.Enabled = false;
            this.listAprobadoPor.Enabled = false;
            if (!Activo) 
            {
                this.txtDescripcionSOX.Enabled = false;
                this.listNivel.Enabled = false;
            }
        }

        private void CargarUsuarios()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            foreach (var user in manager.Users)
            {
                ListItem inactivadoPor = new ListItem(user.UserName, user.UserName);
                ListItem aprobadoPor = new ListItem(user.UserName, user.UserName);
                this.listAprobadoPor.Items.Add(aprobadoPor);
            }
        }
        private void CargarRiesgosCorporativos()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var riesgos = servicio.ObtenerRiesgosCorporativos();
            foreach (var riesgo in riesgos)
            {
                ListItem nuevoRiesgoCorporativo = new ListItem(riesgo.Codigo, riesgo.Codigo + "-" + riesgo.Tipo);
                this.lstRiesgosCorporativos.Items.Add(nuevoRiesgoCorporativo);
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(listNivel.SelectedValue))
                errores.AppendLine("El campo nivel de riesgo es obligatorio.");
            if (string.IsNullOrEmpty(txtDescripcionSOX.Text))
                errores.AppendLine("El campo descripción de riesgo es obligatorio.");
            if (string.IsNullOrEmpty(txtFechaCreacion.Text))
                errores.AppendLine("El campo fecha de creación de riesgo es obligatorio.");
            if (string.IsNullOrEmpty(txtRiesgoSOX.Text))
                errores.AppendLine("El campo código de riesgo es obligatorio.");
            if(lstEstados.SelectedValue == "")
                errores.AppendLine("El estado del riesgo es obligatorio.");
            if (lstRiesgosCorporativos.SelectedValue == "")
                errores.AppendLine("El código del riesgo corporativo es obligatorio.");

            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarRiesgo();
        }

        private void CrearActualizarRiesgo()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var inactivadoPor = string.Empty;
            string codigoRiesgoSeleccionado = string.Empty;
            string tipoRiesgoSeleccionado = string.Empty;
            if (this.lstRiesgosCorporativos.SelectedValue.Contains('-'))
            {
                codigoRiesgoSeleccionado = this.lstRiesgosCorporativos.SelectedValue.Split('-')[0]; 
                tipoRiesgoSeleccionado = this.lstRiesgosCorporativos.SelectedValue.Split('-')[1];
            }
            if (lstEstados.SelectedValue == "Inactivo")
            {
                inactivadoPor = User.Identity.Name;
            }
            if (EnUso)
            {
                try
                {
                    SmtpClient SmtpServer = new SmtpClient();
                    MailMessage mail = new MailMessage(new MailAddress(ConfigurationManager.AppSettings["MailFrom"]), new MailAddress(ConfigurationManager.AppSettings["MailTo"]));
                    mail.Subject = "Alerta de modificación riesgo SOX";
                    mail.Body = "Se ha modificado el riesgo " + this.txtRiesgoSOX.Text + " que se encontraba en uso. Usuario que inactivó: " + User.Identity.Name;
                    SmtpServer.Send(mail);
                }
                catch(Exception ex) { }
            }
            
            string codigoSOX = this.txtRiesgoSOX.Text;
            
            if(codigoSOX.StartsWith(tipoRiesgoSeleccionado.Substring(0, 1)))
            {
                codigoSOX = codigoSOX.Replace(tipoRiesgoSeleccionado.Substring(0, 1), "");
            }
            if (!codigoSOX.Contains("SOX"))
            {
                codigoSOX = "SOX" + tipoRiesgoSeleccionado.Substring(0, 1) + codigoSOX;
            }
            
            var nuevoRiesgo = new ConexionSOXService.RiesgoSOX()
            {
                AprobadoPor = this.listAprobadoPor.SelectedValue,
                CodigoRiesgoCorporativo = codigoRiesgoSeleccionado,
                CodigoSOX = codigoSOX,
                DescripcionSOX = this.txtRiesgoSOX.Text,
                Estado = this.lstEstados.SelectedValue,
                FechaCreacion = DateTime.Parse(this.txtFechaCreacion.Text),
                NivelSOX = this.listNivel.SelectedValue,
                InactivadoPor = inactivadoPor
            };
            var respuesta = servicio.CrearActualizarRiesgoSOX(nuevoRiesgo);
            Response.Write("<script>alert('"+ respuesta + "');location.href='/RiesgoSOX/ConsultarRiesgosSOX'</script>");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/RiesgoSOX/ConsultarRiesgosSOX");
        }

        protected void lstRiesgosCorporativos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string numero = lstRiesgosCorporativos.SelectedItem.Text;
            spanCodigo.InnerText = "SOX-T-" + numero;
        }
    }
}