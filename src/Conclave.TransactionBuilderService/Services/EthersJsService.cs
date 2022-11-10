using Conclave.TransctionBuilderService.Models;

namespace Conclave.TransctionBuilderService.Services;

public class EthersJsService
{
    private readonly BrowserService _browserService;

    public EthersJsService(BrowserService browserService)
    {
        _browserService = browserService;
    }

    public async Task<string?> TestAsync()
    {
        return await _browserService.InvokeFunctionAsync<string>("test");
    }

    public async Task<string?> SendBaseTokenAsync(SendBaseTokenTxDto sendBaseTokenParams)
    {
        return await _browserService.InvokeFunctionAsync<string>("sendBaseTokenAsync", sendBaseTokenParams);
    }
}