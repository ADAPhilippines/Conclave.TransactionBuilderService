using Microsoft.AspNetCore.SignalR.Client;

HubConnection hubConnection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5039/transactionBuilder")
    .Build();

hubConnection.On<string>("ReceiveMessage", (message) =>
{
    Console.WriteLine(message);
});

await hubConnection.StartAsync();
await hubConnection.SendAsync("SendMessage", "Hello World");

while (true) Console.ReadLine();