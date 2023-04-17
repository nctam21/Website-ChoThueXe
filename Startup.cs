using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBookingCar.Startup))]
namespace WebBookingCar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
