using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebLibrary.Domain.Interfaces;
using WebLibrary.Infrastructure.Persistence;
using WebLibrary.Infrastructure.Repositories;

namespace WebLibrary.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Подключение контекста базы данных
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
