using Microsoft.EntityFrameworkCore.ChangeTracking; // EntityEntry<T>
using Microsoft.EntityFrameworkCore.Storage; // IDbContextTransaction
using Packt.Shared;

partial class Program
{
  static void ListProducts(int? productIdToHighlight = null)
  {
    using (Northwind db = new())
    {
      if ((db.Products is null) || (db.Products.Count() == 0))
      {
        Fail("There are no products.");
        return;
      }

      WriteLine("| {0,-3} | {1,-35} | {2,8} | {3,5} | {4} |",
        "Id", "Product Name", "Cost", "Stock", "Disc.");

      foreach (Product p in db.Products)
      {
        ConsoleColor previousColor = ForegroundColor;

        if (productIdToHighlight == p.ProductId)
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
      // get first product whose name starts with name
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

        if (products is null)
        {
          WriteLine("No products found to delete.");
          return 0;
        }
        else
        {
          db.Products.RemoveRange(products);
        }

        int affected = db.SaveChanges();
        t.Commit();
        return affected;
      }
    }
  }
}