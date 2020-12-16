using ConexionWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConexionWeb.Perfiles
{
    public partial class NuevoUsuario : System.Web.UI.Page
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
        }

        private void LimpiarCampos() {
            Email.Text = string.Empty;
            Nombre.Text = string.Empty;
            Identificacion.Text = string.Empty;
            Cargo.Text = string.Empty;
            Jefatura.Text = string.Empty;
            Area.Text = string.Empty;
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { 
                UserName = Email.Text, 
                Email = Email.Text,
                Nombre = Nombre.Text,
                Identificacion = Identificacion.Text,
                Cargo = Cargo.Text,
                Jefatura = Jefatura.Text,
                Area = Area.Text
            };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                lblConfirmacion.Text = "Se ha creado la cuenta correctamente";
                this.LimpiarCampos();
            }
            else
            {
                lblMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}