﻿using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SirnalRUserId.Startup))]
namespace SirnalRUserId
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {                        
            ConfigureAuth(app);

            app.MapSignalR();
            GlobalHost.HubPipeline.RequireAuthentication();
        }
    }
}
