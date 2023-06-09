using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using ShuttleServiceManagementApp.Client;
using ShuttleServiceManagementApp.Client.Abstractions.Services;
using ShuttleServiceManagementApp.Client.Services;
using Smart.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddSmart();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<ITimingCategoryService, TimingCategoryService>();

await builder.Build().RunAsync();
