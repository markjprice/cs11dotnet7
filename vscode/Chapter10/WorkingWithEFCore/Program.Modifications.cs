using Microsoft.EntityFrameworkCore; // ExecuteUpdate, ExecuteDelete
using Microsoft.EntityFrameworkCore.ChangeTracking; // EntityEntry<T>
using Microsoft.EntityFrameworkCore.Storage; // IDbContextTransaction
using Packt.Shared; // Northwind, Product

partial class Program
{
  static void ListProducts(int[]? productIdsToHighlight = null)
  {
    using (Northwind db = new())
    {
      if ((db.Products is null) || (!db.Products.Any()))
      {
        Fail("There are no products.");
        return;
      }

      WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |",
        "Id", "Product Name", "Cost", "Stock", "Disc.");

      foreach (Product p in db.Products)
      {
        ConsoleColor previousColor = ForegroundColor;

        if ((productIdsToHighlight is not null) &&
          productIdsToHighlight.Contains(p.ProductId))
        {
          ForegroundColor = ConsoleColor.Green;
        }

        WriteLine("| {0:000} | {1,-35} | {2,8:$#,##0.00} | {3,5} | {4} |",
          p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);

        ForegroundColor = previousColor;
      }
    }
  }

  static (int affected, int productId) AddProduct(
    int categoryId, string productName, decimal? price)
  {
    using (Northwind db = new())
    {
      if (db.Products is null) return (0, 0);

      Product p = new()
      {
        CategoryId = categoryId,
        ProductName = productName,
        Cost = price,
        Stock = 72
      };

      // set product as added in change tracking
      EntityEntry<Product> entity = db.Products.Add(p);
      WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

      // save tracked change to database
      int affected = db.SaveChanges();
      WriteLine($"State: {entity.State}, ProductId: {p.ProductId}");

      return (affected, p.ProductId);
    }
  }

  static (int affected, int productId) IncreaseProductPrice(
    string productNameStartsWith, decimal amount)
  {
    using (Northwind db = new())
    {
      if (db.Products is null) return (0, 0);

      // Get the first product whose name starts with the parameter value.
      Product updateProduct = db.Products.First(
        p => p.ProductName.StartsWith(productNameStartsWith));

      updateProduct.Cost += amount;

      int affected = db.SaveChanges();

      return (affected, updateProduct.ProductId);
    }
  }

  static int DeleteProducts(string productNameStartsWith)
  {
    using (Northwind db = new())
    {
      using (IDbContextTransaction t = db.Database.BeginTransaction())
      {
        WriteLine("Transaction isolation level: {0}",
          arg0: t.GetDbTransaction().IsolationLevel);

        IQueryable<Product>? products = db.Products?.Where(
          p => p.ProductName.StartsWith(productNameStartsWith));

        if ((products is null) || (!products.Any()))
        {
          WriteLine("No products found to delete.");
          return 0;
        }
        else
        {
          if (db.Products is null) return 0;
          db.Products.RemoveRange(products);
        }

        int affected = db.SaveChanges();
        t.Commit();
        return affected;
      }
    }
  }

  static (int affected, int[]? productIds) IncreaseProductPricesBetter(
    string productNameStartsWith, decimal amount)
  {
    using (Northwind db = new())
    {
      if (db.Products is null) return (0, null);

      // Get products whose name starts with the parameter value.
      IQueryable<Product>? products = db.Products.Where(
        p => p.ProductName.StartsWith(productNameStartsWith));

      int affected = products.ExecuteUpdate(s => s.SetProperty(
        p => p.Cost, // Property selector lambda expression.
        p => p.Cost + amount)); // Value to update to lambda expression.

      int[] productIds = products.Select(p => p.ProductId).ToArray();

      return (affected, productIds);
    }
  }

  static int DeleteProductsBetter(string productNameStartsWith)
  {
    using (Northwind db = new())
    {
      int affected = 0;

      IQueryable<Product>? products = db.Products?.Where(
        p => p.ProductName.StartsWith(productNameStartsWith));

      if ((products is null) || (!products.Any()))
      {
        WriteLine("No products found to delete.");
        return 0;
      }
      else
      {
        affected = products.ExecuteDelete();
      }
      return affected;
    }
  }
}