using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Control
{
    public partial class CrearControl : System.Web.UI.Page
    {
        private static bool EnUso { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("ActividadControl"))
            {
                Response.Redirect("/Account/AccessDenied.aspx");
            }
            if (!this.IsPostBack)
            {
                CargarObjetivosControl();
                //CargarRiesgosSOX();
                if (Request["Codigo"] != null)
                {
                    CargarInformacionControl(Request["Codigo"]);
                }
            }
        }

        private void CargarObjetivosControl()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.listObjetivosControl.DataSource = servicio.ObtenerObjetivosControl();
            this.listObjetivosControl.DataBind();
        }

        //private void CargarRiesgosSOX()
        //{
        //    var servicio = new ConexionSOXService.ConexionSOXServiceClient();
        //    this.listRiesgosSOX.DataSource = servicio.ObtenerRiesgosSOX();
        //    this.listRiesgosSOX.DataBind();
        //}


        private void CargarInformacionControl(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var control = servicio.ObtenerControl(codigo);

            if (control != null)
            {
                this.txtCodigo.Text = control.Codigo;
                this.txtNombre.Text = control.sControl;
                this.lstEstados.SelectedValue = control.Estado;
                //this.listDominios.SelectedValue = control.CodigoSubDominio;
                this.listObjetivosControl.SelectedValue = control.Objetivo;
                //this.listRiesgosSOX.SelectedValue = control.CodigoRiesgo;
                if (control.Estado == "EnUso")
                    EnUso = true;
                this.txtCodigo.Enabled = false;
                this.txtNombre.Enabled = false;
                this.btnActualizar.Text = "Actualizar";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo código es obligatorio.");
            if (string.IsNullOrEmpty(txtNombre.Text))
                errores.AppendLine("El campo nombre del control obligatorio.");
            if (string.IsNullOrEmpty(txtIniciales.Text))
                errores.AppendLine("El campo iniciales del control es obligatorio.");
            if (string.IsNullOrEmpty(lstEstados.SelectedValue))
                errores.AppendLine("El campo estado es obligatorio.");
            if (string.IsNullOrEmpty(listObjetivosControl.SelectedValue))
                errores.AppendLine("El campo objetivos de control es obligatorio.");

            if (EnUso && this.lstEstados.SelectedValue == "Inactivo")
                errores.AppendLine("No es posible inactivar un control en uso.");
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarControl();
        }

        private void CrearActualizarControl()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var respuesta = servicio.CrearActualizarControl(new ConexionSOXService.Control()
            {
                Codigo = this.txtCodigo.Text,
                InicialesControl = txtIniciales.Text,
                Objetivo = this.listObjetivosControl.SelectedValue,
                Estado = this.lstEstados.SelectedValue,
                sControl = this.txtNombre.Text,
                UsuarioModificador = User.Identity.Name
            });
            Response.Write("<script>alert('" + respuesta + "');location.href='/Control/ConsultaControl'</script>");
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Control/ConsultaControl");
        }
    }
}