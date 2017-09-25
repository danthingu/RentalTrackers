using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentalTrackers.Startup))]
namespace RentalTrackers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
