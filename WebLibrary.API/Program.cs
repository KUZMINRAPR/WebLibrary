using System.Reflection;
using WebLibrary.Application;
using WebLibrary.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Подключаю логгирование
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddInfrastructure(builder.Configuration); // DI для Infrastructure
builder.Services.AddApplication(); // DI для Application

// URL из appsettings.json
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowFrontend", policyBuilder =>
        {
            policyBuilder.WithOrigins(allowedOrigins ?? Array.Empty<string>())
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    }
);
var app = builder.Build();

app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

