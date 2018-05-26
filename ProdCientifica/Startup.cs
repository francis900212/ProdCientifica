using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProdCientifica.Startup))]
namespace ProdCientifica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
