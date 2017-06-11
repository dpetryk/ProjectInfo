using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectInfo.Startup))]
namespace ProjectInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
