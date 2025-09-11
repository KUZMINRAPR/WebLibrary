using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebLibrary.Application.Books.Handlers;
using WebLibrary.Domain.Interfaces;
using WebLibrary.Infrastructure.Persistence;
using WebLibrary.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

// Регистрация репозитория
builder.Services.AddScoped<IBookRepository, BookRepository>();

// URL из appsettings.json
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssembly(typeof(GetBookByAuthorAndTitleQuery).Assembly);
    });

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowBlasor", policyBuilder =>
        {
            policyBuilder.WithOrigins(allowedOrigins ?? Array.Empty<string>())
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    }
);
var app = builder.Build();
//app.UseCors("AllowBlasor"); не помню зачем поэтому пока что выключено

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

