using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrestamosCompactoWEB_Cs.Startup))]
namespace PrestamosCompactoWEB_Cs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
