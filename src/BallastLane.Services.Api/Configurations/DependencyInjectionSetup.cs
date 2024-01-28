using BallastLane.Infra.CrossCutting.IoC;

namespace BallastLane.Services.Api.Configurations;

public static class DependencyInjectionSetup
{
    public static void AddDependencyInjectionSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        NativeInjectorBootStrapper.RegisterServices(services);
    }
}