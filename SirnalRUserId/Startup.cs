using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SirnalRUserId.Startup))]
namespace SirnalRUserId
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
