using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Roles
{
    public partial class CrearRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx?ReturnUrl=" + Request.Url);
            }
            if (!User.IsInRole("Perfiles"))
            {
                Response.Redirect("/Account/AccessDenied.aspx");
            }
            if (!this.IsPostBack)
            {
                CargarUsuarios();
                if (Request["Codigo"] != null)
                {
                    CargarInformacionRol(Request["Codigo"]);
                }
            }
        }

        private void CargarUsuarios()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            foreach (var user in manager.Users)
            {
                ListItem po = new ListItem(user.UserName, user.UserName);
                ListItem sm = new ListItem(user.UserName, user.UserName);
                this.listReponsableDelegado.Items.Add(po);
                this.listResponsable.Items.Add(po);
            }
        }
        private void CargarInformacionRol(string codigo)
        {
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var rol = servicio.ObtenerRol(codigo);
            if (rol != null)
            {
                this.txtCodigo.Text = rol.IdRol;
                this.listNombreRol.SelectedValue = rol.NombreRol;
                this.listEstados.SelectedValue = rol.Estado;
                AsignarRolSeleccionado(rol.NombreRol, rol.Permisos);
                this.listReponsableDelegado.SelectedValue = rol.ResponsableDelegado;
                this.listResponsable.SelectedValue = rol.Responsable;
                this.btnActualizar.Text = "Actualizar";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            StringBuilder errores = new StringBuilder();
            if (string.IsNullOrEmpty(txtCodigo.Text))
                errores.AppendLine("El campo ID del rol es obligatorio.");
            if (string.IsNullOrEmpty(listNombreRol.Text))
                errores.AppendLine("El campo nombre del rol es obligatorio.");
            if (string.IsNullOrEmpty(this.listEstados.SelectedValue))
                errores.AppendLine("El campo estado es obligatorio.");
            if (string.IsNullOrEmpty(this.listReponsableDelegado.SelectedValue))
                errores.AppendLine("El campo responsable delegado es obligatorio.");
            if (string.IsNullOrEmpty(this.listResponsable.SelectedValue))
                errores.AppendLine("El campo responsable es obligatorio.");
            if (!string.IsNullOrEmpty(errores.ToString()))
            {
                this.lblMessage.Text = errores.ToString();
                return;
            }
            CrearActualizarRol();
        }

        private string ObtenerRolSeleccionado()
        {
            string valorSeleccionado = this.listNombreRol.SelectedValue;
            string rolSeleccionado = string.Empty;
            if (this.listNombreRol.SelectedValue == "Aplicaciones")
                rolSeleccionado = this.listPermisoAplicaciones.SelectedValue;
            if (this.listNombreRol.SelectedValue == "Auditoria")
                rolSeleccionado = this.listPermisoAuditoria.SelectedValue;
            if (this.listNombreRol.SelectedValue == "Jefaturas")
                rolSeleccionado = this.listPermisoJefaturas.SelectedValue;
            if (this.listNombreRol.SelectedValue == "MatrizControles")
                rolSeleccionado = this.listPermisoMatrizControles.SelectedValue;
            if (this.listNombreRol.SelectedValue == "ObjetivosControl")
                rolSeleccionado = this.listPermisoObjetivosControl.SelectedValue;
            if (this.listNombreRol.SelectedValue == "PlanAccion")
                rolSeleccionado = this.listPermisoPlanAccion.SelectedValue;
            if (this.listNombreRol.SelectedValue == "PuntoControl")
                rolSeleccionado = this.listPermisoPuntoControl.SelectedValue;
            if (this.listNombreRol.SelectedValue == "Roles")
                rolSeleccionado = this.listPermisoRoles.SelectedValue;
            if (this.listNombreRol.SelectedValue == "SegPlanAccion")
                rolSeleccionado = this.listPermisoSegPlanAccion.SelectedValue;
            if (this.listNombreRol.SelectedValue == "Gobierno")
                rolSeleccionado = this.listPermisosGobierno.SelectedValue;
            if (this.listNombreRol.SelectedValue == "Riesgo")
                rolSeleccionado = this.listPermisosRiesgo.SelectedValue;
            if (this.listNombreRol.SelectedValue == "Soporte")
                rolSeleccionado = this.listPermisoSoporte.SelectedValue;
            return rolSeleccionado;
        }

        private void AsignarRolSeleccionado(string nombreRol, string rolASeleccionar)
        {
            if (nombreRol == "Aplicaciones")
                this.listPermisoAplicaciones.SelectedValue = rolASeleccionar;
            if (nombreRol == "Auditoria")
                this.listPermisoAuditoria.SelectedValue = rolASeleccionar;
            if (nombreRol == "Jefaturas")
                this.listPermisoJefaturas.SelectedValue = rolASeleccionar;
            if (nombreRol == "MatrizControles")
                this.listPermisoMatrizControles.SelectedValue = rolASeleccionar;
            if (nombreRol == "ObjetivosControl")
                this.listPermisoObjetivosControl.SelectedValue = rolASeleccionar;
            if (nombreRol == "PlanAccion")
                this.listPermisoPlanAccion.SelectedValue = rolASeleccionar;
            if (nombreRol == "PuntoControl")
                this.listPermisoPuntoControl.SelectedValue = rolASeleccionar;
            if (nombreRol == "Roles")
                this.listPermisoRoles.SelectedValue = rolASeleccionar;
            if (nombreRol == "SegPlanAccion")
                this.listPermisoSegPlanAccion.SelectedValue = rolASeleccionar;
            if (nombreRol == "Gobierno")
                this.listPermisosGobierno.SelectedValue = rolASeleccionar;
            if (nombreRol == "Riesgo")
                this.listPermisosRiesgo.SelectedValue = rolASeleccionar;
            if (nombreRol == "Soporte")
                this.listPermisoSoporte.SelectedValue = rolASeleccionar;
        }

        private void CrearActualizarRol()
        {
            var roleStore = new RoleStore<IdentityRole>();
            var roleMngr = new RoleManager<IdentityRole>(roleStore);
            roleMngr.Create(new IdentityRole(this.txtCodigo.Text.Trim()));
            var servicio = new ConexionSOXService.ConexionSOXServiceClient();
            var respuesta = servicio.CrearActualizarRol(new ConexionSOXService.Roles()
            {
                Estado = this.listEstados.SelectedValue,
                IdRol = this.txtCodigo.Text.Trim(),
                NombreRol = this.listNombreRol.SelectedValue,
                Permisos = ObtenerRolSeleccionado(),
                Responsable = this.listResponsable.Text,
                ResponsableDelegado = this.listReponsableDelegado.SelectedValue
            }); ;
            Response.Write("<script>alert('" + respuesta + "');location.href='/Roles/ConsultarRoles'</script>");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Roles/ConsultarRoles");
        }
    }
}