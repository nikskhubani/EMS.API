using EMS.WEB.Pages;
using Microsoft.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);


var baseAddress = builder.Configuration["APIHost"];

builder.Services.AddHttpClient<BaseEMSModel>("EMS",(client) =>
{
    client.BaseAddress = new Uri(baseAddress);
});
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
