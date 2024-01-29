using BallastLane.Infra.CrossCutting.Identity.Authorization;
using BallastLane.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace BallastLane.UI.Web.Extensions;

public static class IdentitySetup
{
    public static void AddIdentitySetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static void AddAuthSetup(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanWriteCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Write")));
            options.AddPolicy("CanRemoveCustomerData", policy => policy.Requirements.Add(new ClaimRequirement("Customers", "Remove")));
        });
    }
}