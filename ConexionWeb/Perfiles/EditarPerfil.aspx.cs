using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ConexionWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.UI.WebControls;
using System.Collections.Generic;


namespace ConexionWeb.Perfiles
{
    public partial class EditarPerfil : System.Web.UI.Page
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
            if (!this.IsPostBack && !string.IsNullOrEmpty(Request["Rol"]))
            {
                CargarInformacionRol();
            }
        }

        private void CargarInformacionRol()
        {
            var rolSeleccionado = roles.Where(e => e.Name == Request["Rol"]).First();
            var roleStore = new RoleStore<IdentityRole>();
            var roleMngr = new RoleManager<IdentityRole>(roleStore);
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roles = roleMngr.Roles.ToList();

            this.txtRol.Text = Request["Rol"];
            foreach (var usuario in manager.Users)
            {
                bool isInRole = manager.IsInRole(usuario.Id, rolSeleccionado.Name);
                var newItem = new ListItem(usuario.UserName, usuario.Id);
                newItem.Selected = isInRole;
                this.listUsuariosSeleccionados.Items.Add(newItem);
            }
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            foreach (ListItem item in listUsuariosSeleccionados.Items)
            {
                if (item.Selected)
                {
                    manager.AddToRole(item.Value, Request["Rol"]);
                }
                else
                {
                    manager.RemoveFromRole(item.Value, Request["Rol"]);
                }
            }
            Response.Write("<script>alert('Permisos actualizados correctamente');location.href='/Perfiles/AdministrarPerfiles'</script>");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Perfiles/AdministrarPerfiles");
        }
    }
}