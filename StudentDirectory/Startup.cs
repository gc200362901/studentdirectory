using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentDirectory.Startup))]
namespace StudentDirectory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
