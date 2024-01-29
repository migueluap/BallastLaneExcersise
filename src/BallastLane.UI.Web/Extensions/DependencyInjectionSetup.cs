using BallastLane.Infra.CrossCutting.IoC;

namespace BallastLane.UI.Web.Extensions;

public static class DependencyInjectionSetup
{
    public static void AddDependencyInjectionSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        NativeInjectorBootStrapper.RegisterServices(services);
    }
}