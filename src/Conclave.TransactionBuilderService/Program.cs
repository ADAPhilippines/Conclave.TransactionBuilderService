using Conclave.TransctionBuilderService;
using Conclave.TransctionBuilderService.Hubs;
using Conclave.TransctionBuilderService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddHttpClient();
builder.Services.AddBrowserService();
builder.Services.AddSingleton<EthersJsService>();
builder.Services.AddCors(o => {
    var origins = builder.Configuration.GetSection("AllowedOrigins").Get<IEnumerable<string>>();
    if(origins is null) throw new NullReferenceException("AllowedOrigins Config is null.");
    o.AddPolicy("AllowAll", policy => {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins(origins.ToArray()).AllowCredentials();
    });
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapHub<TransactionBuilderServiceHub>("/transactionBuilder");
app.UseStaticFiles();
app.UseCors("AllowAll");
app.Run();
