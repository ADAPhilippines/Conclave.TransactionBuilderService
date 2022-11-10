using System.Text.Json;
using Conclave.TransctionBuilderService.Models;
using Conclave.TransctionBuilderService.Services;
using Microsoft.AspNetCore.SignalR;

namespace Conclave.TransctionBuilderService.Hubs;

public class TransactionBuilderServiceHub : Hub
{
    private readonly ILogger<TransactionBuilderServiceHub> _logger;
    private readonly EthersJsService _ethersJsService;

    public TransactionBuilderServiceHub(ILogger<TransactionBuilderServiceHub> logger, EthersJsService ethersJsService)
    {
        _logger = logger;
        _ethersJsService = ethersJsService;
    }

    public async Task SendMessage(string message)
    {
        _logger.LogInformation($"Messaged Received: {message}");
        await Clients.All.SendAsync("ReceiveMessage", message + await _ethersJsService.TestAsync());
    }

    public async Task SendBaseToken(string sendBaseTokenParamsJson)
    {
        SendBaseTokenTxDto? sendBaseTokenParams = JsonSerializer.Deserialize<SendBaseTokenTxDto>(sendBaseTokenParamsJson);
        
        if(sendBaseTokenParams is null) {
            Context.Abort();
            return;
        }

        string? txHex = await _ethersJsService.SendBaseTokenAsync(sendBaseTokenParams);
        await Clients.Caller.SendAsync("SendBaseTokenResult", txHex);
    }

}