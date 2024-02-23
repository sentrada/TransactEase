using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransactEase.Infrastructure.Persistence;

namespace TransactEase.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<TransactEaseDbContext>(options =>
            options.UseSqlServer(connectionString));


        return services;
    }
}