using LibraryFront;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5108");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add to builder HttpClient
builder.Services.AddHttpClient();

var applicationUrl = "http://backend-debug:5001"; //TODO: get from appsettings.json
builder.Services.AddScoped<HttpClient> (sp =>
{
    return new HttpClient { BaseAddress = new Uri(applicationUrl) };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

// Нужно для того, чтобы подкачивались статические файлы при dotnet watch
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
