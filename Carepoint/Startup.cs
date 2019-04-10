using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Carepoint.Startup))]
namespace Carepoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
