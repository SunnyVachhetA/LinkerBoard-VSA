using LinkerBoard.API.Data;
using LinkerBoard.API.Features.Common;
using Microsoft.EntityFrameworkCore;

namespace LinkerBoard.API.Extensions;

public static class AppConfiguration
{
    internal static void RegisterDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LinkerBoardDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetValue<string>("LinkerBoardDbConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //Turn off query tracking behavior on global context
        });
    }

    internal static void RegisterServices(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<Program>()
            .AddClasses(classes => classes.AssignableTo<IService>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
    }

    internal static void RegisterRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblyOf<Program>()
            .AddClasses(classes => classes.AssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
    }
}