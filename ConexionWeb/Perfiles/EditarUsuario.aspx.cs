using ConexionWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Perfiles
{
    public partial class EditarUsuario : System.Web.UI.Page
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
            if (!this.IsPostBack && !string.IsNullOrEmpty(Request["User"]))
            {
                CargarInformacionRol();
            }
        }

        private void CargarInformacionRol()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(Request["User"]);
            if (user != null)
            {
                IdUser.Value = user.Id;
                Nombre.Text = user.Nombre;
                Identificacion.Text = user.Identificacion;
                Cargo.Text = user.Cargo;
                Jefatura.Text = user.Jefatura;
                Area.Text = user.Area;
                Email.Text = user.Email;

                var roleStore = new RoleStore<IdentityRole>();
                var roleMngr = new RoleManager<IdentityRole>(roleStore);
                listRoles.DataSource = roleMngr.Roles.ToList();
                listRoles.DataBind();

                List<string> usuario_roles = manager.GetRoles(user.Id).ToList();
                for (int i = 0; i < listRoles.Items.Count; i++)
                {
                    if (usuario_roles.Contains(listRoles.Items[i].Text))
                        listRoles.Items[i].Selected = true;
                }
            }
            else
            {
                Response.Redirect("/Perfiles/AdministrarPerfiles.aspx");
            }
        }

        protected void EditUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var user = manager.FindById(IdUser.Value);
            if (user == null)
            {
                lblMessage.Text = "No se ha encontrado el usuario";
                return;
            }

            for (int i = 0; i < listRoles.Items.Count; i++)
            {
                if (manager.IsInRole(user.Id, listRoles.Items[i].Text) && !listRoles.Items[i].Selected)
                {
                    manager.RemoveFromRole(user.Id, listRoles.Items[i].Text);
                }

                if (!manager.IsInRole(user.Id, listRoles.Items[i].Text) && listRoles.Items[i].Selected)
                {
                    manager.AddToRole(user.Id, listRoles.Items[i].Text);
                }
            }

            lblConfirmacion.Text = "Se ha actualizado el usuario correctamente.";            
            if (Password.Text.Trim() == string.Empty)
                return;

            var code = manager.GeneratePasswordResetToken(user.Id);
            var result = manager.ResetPassword(user.Id, code, Password.Text);
            if (result.Succeeded)
            {
                return;
            }
            lblMessage.Text = result.Errors.FirstOrDefault();
        }
    }
}