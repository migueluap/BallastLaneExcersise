using BallastLane.Infra.CrossCutting.Identity.Models;
using BallastLane.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BallastLane.Services.Api.Configurations;

public static class DatabaseSetup
{
    public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<BallastLaneContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDbContext<EventStoreSqlContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}