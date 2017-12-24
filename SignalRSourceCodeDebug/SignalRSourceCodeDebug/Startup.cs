using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

[assembly: OwinStartup(typeof(SignalRSourceCodeDebug.Startup))]

namespace SignalRSourceCodeDebug
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = false
            };

            var hubPipeline = hubConfiguration.Resolver.Resolve<IHubPipeline>();
            hubPipeline.AddModule(new Middleware1());


            // default path /signalr
            app.MapSignalR(hubConfiguration);

        }
    }
}
