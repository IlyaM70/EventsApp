using EventsApp.Application.Interfaces;
using EventsApp.Domain.Models;
using EventsApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<User>()
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        return services;
    }
}
