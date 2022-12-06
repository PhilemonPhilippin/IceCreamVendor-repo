using IceCreamVendor.Core.Data;
using IceCreamVendor.Core.Logic;
using IceCreamVendor.Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IConfigurationBuilder builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false);

IConfiguration config = builder.Build();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => services
        .AddTransient<IIceCreamService, IceCreamService>()
        .AddTransient<ILogService, LogService>()
        .AddTransient<ISellService, SellService>()
        .AddDbContext<IceCreamContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")))
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
    business?.RunBusiness();
}