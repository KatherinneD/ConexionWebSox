using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.ActividadControl
{
    public partial class CrearActividadControl : System.Web.UI.Page
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
                CargarRiesgosSOX();
                if (Request["Codigo"] != null)
                {
                    CargarInformacionActividadControl(Request["Codigo"]);
                }
            }
        }

        private void CargarObjetivosControl()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.listObjetivosControl.DataSource = servicio.ObtenerObjetivosControl();
            this.listObjetivosControl.DataBind();
        }

        private void CargarRiesgosSOX()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            this.listRiesgosSOX.DataSource = servicio.ObtenerRiesgosSOX();
            this.listRiesgosSOX.DataBind();
        }


        private void CargarInformacionActividadControl(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var actividadControl = servicio.ObtenerActividadControl(codigo);

            if (actividadControl != null)
            {
                this.txtCodigo.Text = actividadControl.Codigo;
                this.txtNombre.Text = actividadControl.NombreActividad;
                this.lstEstados.SelectedValue = actividadControl.Estado;
                this.listDominios.SelectedValue = actividadControl.CodigoSubDominio;
                this.listObjetivosControl.SelectedValue = actividadControl.CodigoObjetivo;
                this.listRiesgosSOX.SelectedValue = actividadControl.CodigoRiesgo;
                if (actividadControl.Estado == "EnUso")
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
                errores.AppendLine("El campo nombre del área es obligatorio.");
            if (string.IsNullOrEmpty(lstEstados.SelectedValue))
                errores.AppendLine("El campo estado es obligatorio.");
            if (string.IsNullOrEmpty(listDominios.SelectedValue))
                errores.AppendLine("El campo dominio es obligatorio.");
            if (string.IsNullOrEmpty(listObjetivosControl.SelectedValue))
                errores.AppendLine("El campo objetivos de control es obligatorio.");
            if (string.IsNullOrEmpty(listRiesgosSOX.SelectedValue))
                errores.AppendLine("El campo riesgos SOX es obligatorio.");
            if (EnUso && this.lstEstados.SelectedValue == "Inactivo")
                errores.AppendLine("No es posible inactivar una actividad en uso.");
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarActividadControl();
        }

        private void CrearActualizarActividadControl()
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var respuesta = servicio.CrearActualizarActividadControl(new ConexionSOXService.ActividadControl()
            {
                Codigo = this.txtCodigo.Text,
                CodigoObjetivo = this.listObjetivosControl.SelectedValue,
                CodigoRiesgo = this.listRiesgosSOX.SelectedValue,
                CodigoSubDominio = this.listDominios.SelectedValue,
                Estado  = this.lstEstados.SelectedValue,
                NombreActividad = this.txtNombre.Text,
                UsuarioModificador = User.Identity.Name
            });
            Response.Write("<script>alert('" + respuesta + "');location.href='/ActividadControl/ConsultarActividadesControl'</script>");
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ActividadControl/ConsultarActividadesControl");
        }
    }
}