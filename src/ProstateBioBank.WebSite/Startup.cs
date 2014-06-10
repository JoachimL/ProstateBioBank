using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ProstateBioBank.Startup))]

namespace ProstateBioBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
