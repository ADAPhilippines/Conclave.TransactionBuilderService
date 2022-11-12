using System.Text.Json;
using Microsoft.AspNetCore.SignalR.Client;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Hex.HexTypes;
using Nethereum.Signer;

var privateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
var account = new Account(privateKey, 200101);
Console.WriteLine("Account Address: {0}", account.Address);
var web3 = new Web3(account, "https://rpc-devnet-cardano-evm.c1.milkomeda.com/");

var balance = await web3.Eth.GetBalance.SendRequestAsync(account.Address);
var nonce = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(account.Address);
var gasPrice = await web3.Eth.GasPrice.SendRequestAsync();
var time = DateTimeOffset.Now.ToUnixTimeSeconds();
Console.WriteLine("Balance: {0}", Nethereum.Util.UnitConversion.Convert.FromWei(balance.Value));
Console.WriteLine("Nonce: {0}", nonce);
Console.WriteLine("Gas Price: {0}", gasPrice);
Console.WriteLine("Timestamp: {0}", time);

var contract = web3.Eth.GetContract(File.ReadAllText("abi.json"), "0xCA77372a728C09610BCf68a47C71c419888b380D");
var retrieveFunction = contract.GetFunction("retrieve");
var storeFunction = contract.GetFunction("store");
var gas = await storeFunction.EstimateGasAsync(time);
var data = storeFunction.GetData(time);

Console.WriteLine("Estimate Gas: {0}", gas);

var tx = new LegacyTransaction(
    "0xCA77372a728C09610BCf68a47C71c419888b380D",
    Nethereum.Util.UnitConversion.Convert.ToWei(0),
    nonce,
    gasPrice,
    gas,
    data);

Console.WriteLine("Test Store: {0}", data);
Console.WriteLine("Unsigned Raw Tx: {0}", $"0x{tx.GetRLPEncoded().ToHex()}");
var txReceipt = await web3.Eth.TransactionManager.SendTransactionAndWaitForReceiptAsync(new TransactionInput(
    data,
    "0xCA77372a728C09610BCf68a47C71c419888b380D",
    account.Address,
    gas, gasPrice,
    new HexBigInteger(Nethereum.Util.UnitConversion.Convert.ToWei(0))));
    
Console.WriteLine("TxHash: {0}", txReceipt.TransactionHash);
Console.WriteLine("Fee: {0}", Nethereum.Util.UnitConversion.Convert.FromWei(txReceipt.GasUsed.Value * txReceipt.EffectiveGasPrice.Value));
Console.WriteLine("Retrieve: {0}", await retrieveFunction.CallAsync<int>());


// HubConnection hubConnection = new HubConnectionBuilder()
//     .WithUrl("http://localhost:5039/transactionBuilder")
//     .Build();

// hubConnection.On<string>("SendBaseTokenResult", async (txHex) =>
// {

// });

// await hubConnection.StartAsync();
// await hubConnection.SendAsync("SendBaseToken", JsonSerializer.Serialize(new
// {
//     AmountEth = "1.0",
//     ToAddress = "0x48D51ebfd87d2ec655A77BdC7E798DbF42Eab770",
//     GasLimit = 21000,
//     GasPrice = 60,
//     Nonce = 1
// }));

while (true) Console.ReadLine();