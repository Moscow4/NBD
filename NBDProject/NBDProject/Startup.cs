using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NBDProject.Startup))]
namespace NBDProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
