using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TiTSproj.Startup))]
namespace TiTSproj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
