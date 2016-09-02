using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFCodeFirstPaoloTest.Startup))]
namespace EFCodeFirstPaoloTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
