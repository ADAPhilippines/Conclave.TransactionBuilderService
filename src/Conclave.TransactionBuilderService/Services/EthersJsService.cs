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
}