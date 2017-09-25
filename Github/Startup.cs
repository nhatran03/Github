using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Github.Startup))]
namespace Github
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
