using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(s2.lab3.Startup))]
namespace s2.lab3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
