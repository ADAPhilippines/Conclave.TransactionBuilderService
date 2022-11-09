using Conclave.TransctionBuilderService.Services;
using Microsoft.AspNetCore.Hosting.Server;

namespace Conclave.TransctionBuilderService;

public static class BrowseServiceExtension
{
    public static IServiceCollection AddBrowserService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<BrowserService>((serviceProvider) =>
        {
            IServer? server = serviceProvider.GetService<IServer>();
            HttpClient? httpClient = serviceProvider.GetService<HttpClient>();
            ILogger<BrowserService>? logger = serviceProvider.GetService<ILogger<BrowserService>>();
            BrowserService browserService;
            if (server is not null && httpClient is not null && logger is not null)
            {
                browserService = new BrowserService(server, httpClient, logger);
                browserService.InitializeAsync().Wait();
            }
            else
            {
                throw new NullReferenceException("The IServer required by BrowserService is null.");
            }
            return browserService;
        });
        return serviceCollection;
    }
}