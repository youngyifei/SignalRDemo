using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(MVC.SignalR.Startup))]

namespace MVC.SignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var idProvider = new UserIdProvider();

            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);          

            app.MapSignalR();
        }
        ////Cors跨域配置
        //public void Configuration(IAppBuilder app)
        //{
        //    var idProvider = new UserIdProvider();

        //    GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);

        //    app.Map("/signalr", map =>
        //    {
        //        map.UseCors(CorsOptions.AllowAll);
        //        var hubConfiguration = new HubConfiguration
        //        {
        //            EnableJSONP = true
        //        };
        //        map.RunSignalR(hubConfiguration);
        //    });
        //}
    }
}
