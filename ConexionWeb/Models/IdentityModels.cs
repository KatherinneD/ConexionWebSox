using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ConexionWeb.Models;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace ConexionWeb.Models
{
    // You can add User data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(256)]
        public string Nombre { get; set; }
        
        [StringLength(100)]
        public string Identificacion { get; set; }
        
        [StringLength(256)]
        public string Cargo { get; set; }
        
        [StringLength(256)]
        public string Jefatura { get; set; }
        
        [StringLength(256)]
        public string Area { get; set; }

        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class ApplicationRole
    {
        public const string PERFILES = "Perfiles";
        public const string RIESGOS = "Riesgos";
        public const string GOBIERNO = "Gobierno";
        public const string JEFATURA = "Jefatura";
        public const string OBJETIVOS_CONTROL = "ObjetivosControl";
        public const string PUNTOS_CONTROL = "PuntosControl";
        public const string APLICAION = "Aplicacion";
        public const string MATRIZ_CONTROLES = "MatrizControles";
        public const string ACTIVIDAD_CONTROL = "ActividadControl";
        public const string CONTROL = "Control";
    }
}

#region Helpers
namespace ConexionWeb
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }

        public static void Initialize(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(ApplicationRole.PERFILES))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.PERFILES));
            }

            if (!roleManager.RoleExists(ApplicationRole.RIESGOS))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.RIESGOS));
            }

            if (!roleManager.RoleExists(ApplicationRole.GOBIERNO))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.GOBIERNO));
            }

            if (!roleManager.RoleExists(ApplicationRole.JEFATURA))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.JEFATURA));
            }

            if (!roleManager.RoleExists(ApplicationRole.OBJETIVOS_CONTROL))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.OBJETIVOS_CONTROL));
            }

            if (!roleManager.RoleExists(ApplicationRole.PUNTOS_CONTROL))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.PUNTOS_CONTROL));
            }

            if (!roleManager.RoleExists(ApplicationRole.APLICAION))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.APLICAION));
            }

            if (!roleManager.RoleExists(ApplicationRole.MATRIZ_CONTROLES))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.MATRIZ_CONTROLES));
            }

            if (!roleManager.RoleExists(ApplicationRole.ACTIVIDAD_CONTROL))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.ACTIVIDAD_CONTROL));
            }

            if (!roleManager.RoleExists(ApplicationRole.CONTROL))
            {
                var roleresult = roleManager.Create(new IdentityRole(ApplicationRole.CONTROL));
            }

            ApplicationUser user = new ApplicationUser() { UserName = "administrador@sistema.com", Email = "administrador@sistema.com", EmailConfirmed = true };
            if (userManager.FindByEmail(user.Email) == null)
            {
                IdentityResult userResult = userManager.Create(user, ConfigurationManager.AppSettings["PasswordTemporal"]);
                if (userResult.Succeeded)
                {
                    string[] roles = { ApplicationRole.PERFILES, ApplicationRole.RIESGOS, ApplicationRole.GOBIERNO, 
                        ApplicationRole.JEFATURA, ApplicationRole.OBJETIVOS_CONTROL, ApplicationRole.PUNTOS_CONTROL, 
                        ApplicationRole.APLICAION, ApplicationRole.MATRIZ_CONTROLES, ApplicationRole.ACTIVIDAD_CONTROL, 
                        ApplicationRole.CONTROL };
                    var result = userManager.AddToRoles(user.Id, roles);
                }
            }
        }
    }
}
#endregion
