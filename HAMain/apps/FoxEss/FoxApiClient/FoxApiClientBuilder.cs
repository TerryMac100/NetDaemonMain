using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDaemonMain.apps.FoxEss.FoxApiClient.Models;

namespace NetDaemonMain.apps.FoxEss.FoxApiClient;

public static class FoxApiClientBuilder
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hostBuilder">Builder</param>
    public static IHostBuilder AddFoxApiClientBuilder(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient<FoxEssMain>();
            services.AddTransient<FoxSettings>();
        });
        return hostBuilder;
    }
}
