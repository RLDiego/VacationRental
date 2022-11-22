using Aiia.Contracts;
using Aiia.Contracts.Entities;
using Aiia.Contracts.Interfaces;
using Aiia.FrontEnd;
using Aiia.FrontEnd.Data;
using Aiia.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();    


builder.Services.AddOptions<AiiaConfig>()
    .Configure<IConfiguration>((settings, configuration) =>
    {
        configuration.GetSection("AiiaConfig").Bind(settings);
    });
builder.Services.AddSingleton<ITokenRepository, TokenRepository>();
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<ITransactionsRepository, TransactionsRepository>();
builder.Services.AddSingleton<IHttpUtils, HttpUtils>();
builder.Services.AddSingleton<AccountsService>();
builder.Services.AddSingleton<LoginService>();
builder.Services.AddSingleton<OperationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseResponseCaching();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapFallbackToPage("/_Host");

app.MapBlazorHub();

app.Run();
