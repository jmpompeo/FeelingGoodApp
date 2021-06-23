using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FeelingGoodApp.Areas.Identity.IdentityHostingStartup))]
namespace FeelingGoodApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}