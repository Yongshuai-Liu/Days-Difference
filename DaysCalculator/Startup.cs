using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DaysCalculator.Startup))]
namespace DaysCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
