using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDaemonMain.apps.FoxEss.FoxApiClient.Models;

namespace NetDaemonMain.apps.FoxEss.FoxApiClient;

/// <summary>
/// FoxESS API Builder
/// </summary>
public static class FoxApiClientBuilder
{
    /// <summary>
    /// Create the services for the Fox API Client
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
