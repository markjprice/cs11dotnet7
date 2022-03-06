using Microsoft.EntityFrameworkCore; // DbContext, DbSet<T>

namespace Packt.Shared;

public class Northwind : DbContext
{
  public DbSet<Customer> Customers { get; set; } = null!;

  protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
  {
    string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");
    string connection = $"Filename={path}";
    optionsBuilder.UseSqlite(connection);
  }
}
