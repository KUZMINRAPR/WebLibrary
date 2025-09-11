using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebLibrary.Front;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = builder.Configuration.GetValue<string>("AllowedOrigins:docker") ??
        throw new InvalidOperationException("Base address not found in configuration.");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });


await builder.Build().RunAsync();
