using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CredMgr.Startup))]
namespace CredMgr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
