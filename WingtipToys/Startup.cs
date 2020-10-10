using Microsoft.Owin;
using Owin;
using System.Web.Hosting;

[assembly: OwinStartup(typeof(WingtipToys.Startup))]
namespace WingtipToys
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            app.UseDotVVM<DotvvmStartup>(HostingEnvironment.ApplicationPhysicalPath);
        }
    }
}
