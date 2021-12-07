using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgjensioniUdhetimit_ProjektiTI2.Startup))]
namespace AgjensioniUdhetimit_ProjektiTI2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
