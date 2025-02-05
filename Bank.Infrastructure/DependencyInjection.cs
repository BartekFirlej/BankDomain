using Bank.Domain.RepositoryInterfaces;
using Bank.Infrastructure.Persistence;
using Bank.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=127.0.0.1,1433;Database=Bank;User Id=sa;Password=zaq1@WSX;TrustServerCertificate=True;"));

        services.AddScoped<ApplicationDbContext>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();

        return services;
    }
}
