using Microsoft.EntityFrameworkCore; // UseSqlite
using Microsoft.Extensions.DependencyInjection; // IServiceCollection

namespace Packt.Shared;

public static class NorthwindContextExtensions
{
  /// <summary>
  /// Adds NorthwindContext to the specified IServiceCollection. Uses the Sqlite database provider.
  /// </summary>
  /// <param name="services"></param>
  /// <param name="relativePath">Set to override the default of ".."</param>
  /// <param name="databaseFilename">Set to override the default of "Northwind.db"</param>
  /// <returns>An IServiceCollection that can be used to add more services.</returns>
  public static IServiceCollection AddNorthwindContext(
    this IServiceCollection services, string relativePath = "..",
    string databaseFilename = "Northwind.db")
  {
    string databasePath = Path.Combine(relativePath, databaseFilename);

    services.AddDbContext<NorthwindContext>(options =>
    {
      options.UseSqlite($"Data Source={databasePath}");

      options.LogTo(WriteLine, // Console
        new[] { Microsoft.EntityFrameworkCore
          .Diagnostics.RelationalEventId.CommandExecuting });
    }, 
    // Register with a transient lifetime to avoid concurrency issues with Blazor Server projects.
    contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

    return services;
  }
}
