using BallastLane.UI.Web.Extensions;
using MediatR;

namespace BallastLane.UI.Web;

public class Startup
{
    public IConfiguration Configuration { get; }


    public Startup(IHostEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

        if (env.IsDevelopment())
        {
            builder.AddUserSecrets<Startup>();
        }

        builder.AddEnvironmentVariables();
        Configuration = builder.Build();
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        // Setting DBContexts
        services.AddDatabaseSetup(Configuration);

        // ASP.NET Identity Settings
        services.AddIdentitySetup();

        // AutoMapper Settings
        services.AddAutoMapperSetup();

        // MVC Settings
        services.AddControllersWithViews();
        services.AddRazorPages();

        // Authentication & Authorization
        services.AddAuthSetup(Configuration);

        // Adding MediatR for Domain Events and Notifications
        services.AddMediatR(typeof(Startup));

        // ASP.NET HttpContext dependency
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // .NET Native DI Abstraction
        services.AddDependencyInjectionSetup();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
    }
}
