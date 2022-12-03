using IceCreamVendor.Core.Logic;
using IceCreamVendor.Core.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => services
        .AddTransient<IIceCreamService, IceCreamService>()
        .AddTransient<IceCreamBusiness>()
        )
    .Build();

RunBusiness(host.Services);

await host.RunAsync();

static void RunBusiness(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    IceCreamBusiness business = provider.GetService<IceCreamBusiness>();
    business.OpenBusiness();
}