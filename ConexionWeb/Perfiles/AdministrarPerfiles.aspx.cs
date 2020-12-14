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
using FileHelpers;
using System.IO;
using System.Configuration;
using System.Text;

namespace ConexionWeb.Perfiles
{
    public partial class AdministrarPerfiles : System.Web.UI.Page
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
                CargarPerfiles();
            }
        }

        private void CargarPerfiles()
        {
            
            var roleStore = new RoleStore<IdentityRole>();
            var roleMngr = new RoleManager<IdentityRole>(roleStore);
            this.gvRoles.DataSource = roleMngr.Roles.ToList();
            this.gvRoles.DataBind();
        }

        protected void gvRoles_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow fila = e.Row;
                ImageButton imageControl = fila.FindControl("editButton") as ImageButton;
                if (imageControl != null)
                    imageControl.PostBackUrl = "/Perfiles/EditarPerfil.aspx?Rol=" + fila.Cells[0].Text;
                ListBox vista = fila.FindControl("listUsuarios") as ListBox;
                IdentityRole rol = e.Row.DataItem as IdentityRole;
                List<string> usuariosEnRol = new List<string>();
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                foreach (var usuario in rol.Users)
                {
                    usuariosEnRol.Add(manager.GetEmail(usuario.UserId));
                }
                if(rol != null && vista != null)
                {
                    vista.DataSource = usuariosEnRol;
                    vista.DataBind();
                }
            }
        }

        protected void btnCargarUsuarios_Click(object sender, EventArgs e)
        {
            if (this.cargarUsuarios.FileName == null)
            {
                this.lblMessage.Text = "Debe seleccionar un archivo para iniciar el proceso.";
                return;
            }
            if (!this.cargarUsuarios.FileName.ToLower().Contains("csv"))
            {
                this.lblMessage.Text = "El archivo a cargar debe ser de extensión CSV.";
                return;
            }

            var engine = new FileHelperEngine<UsuarioCSV>(Encoding.UTF8);
            var path = GuardarArchivoLocal(this.cargarUsuarios.FileName, this.cargarUsuarios.FileBytes);
            var records = engine.ReadFile(path);
            foreach (var item in records)
            {
                var user = new ApplicationUser() { 
                    UserName = item.Usuario, 
                    Email = item.Usuario + "@movistar.com",
                    Name = item.Nombre,
                    Cargo = item.Cargo,
                    Jefatura = item.Jefatura,
                    EmailConfirmed = true
                };
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                IdentityResult result = manager.Create(user, ConfigurationManager.AppSettings["PasswordTemporal"]);
            }
        }

        private string GuardarArchivoLocal(string nombreArchivo, byte[] bytes)
        {
            string path = Path.Combine(ConfigurationManager.AppSettings["RutaArchivosLocales"], nombreArchivo);
            File.WriteAllBytes(path, bytes);
            return path;
        }
    }
}