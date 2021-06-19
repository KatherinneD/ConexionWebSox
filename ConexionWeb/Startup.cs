using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConexionWeb.Startup))]
namespace ConexionWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
