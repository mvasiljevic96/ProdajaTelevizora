using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProdajaTelevizora.Startup))]
namespace ProdajaTelevizora
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
