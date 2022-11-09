using Conclave.TransctionBuilderService;
using Conclave.TransctionBuilderService.Hubs;
using Conclave.TransctionBuilderService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.AddBrowserService();
builder.Services.AddSingleton<EthersJsService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<TransactionBuilderServiceHub>("/transactionBuilder");
app.UseStaticFiles();
app.Run();
