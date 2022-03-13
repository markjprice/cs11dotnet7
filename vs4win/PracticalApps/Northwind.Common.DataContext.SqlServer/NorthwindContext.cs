using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Packt.Shared
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997s { get; set; } = null!;
        public virtual DbSet<CurrentProductList> CurrentProductLists { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; } = null!;
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; } = null!;
        public virtual DbSet<OrderSubtotal> OrderSubtotals { get; set; } = null!;
        public virtual DbSet<OrdersQry> OrdersQries { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997s { get; set; } = null!;
        public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; } = null!;
        public virtual DbSet<ProductsByCategory> ProductsByCategories { get; set; } = null!;
        public virtual DbSet<QuarterlyOrder> QuarterlyOrders { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<SalesByCategory> SalesByCategories { get; set; } = null!;
        public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;
        public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; } = null!;
        public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Territory> Territories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Northwind;Integrated Security=true;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
            {
                entity.ToView("Alphabetical list of products");
            });

            modelBuilder.Entity<CategorySalesFor1997>(entity =>
            {
                entity.ToView("Category Sales for 1997");
            });

            modelBuilder.Entity<CurrentProductList>(entity =>
            {
                entity.ToView("Current Product List");

                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).IsFixedLength();

                entity.HasMany(d => d.CustomerTypes)
                    .WithMany(p => p.Customers)
                    .UsingEntity<Dictionary<string, object>>(
                        "CustomerCustomerDemo",
                        l => l.HasOne<CustomerDemographic>().WithMany().HasForeignKey("CustomerTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo"),
                        r => r.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                        j =>
                        {
                            j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);

                            j.ToTable("CustomerCustomerDemo");

                            j.IndexerProperty<string>("CustomerId").HasMaxLength(5).HasColumnName("CustomerID").IsFixedLength();

                            j.IndexerProperty<string>("CustomerTypeId").HasMaxLength(10).HasColumnName("CustomerTypeID").IsFixedLength();
                        });
            });

            modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
            {
                entity.ToView("Customer and Suppliers by City");
            });

            modelBuilder.Entity<CustomerDemographic>(entity =>
            {
                entity.HasKey(e => e.CustomerTypeId)
                    .IsClustered(false);

                entity.Property(e => e.CustomerTypeId).IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_Employees_Employees");

                entity.HasMany(d => d.Territories)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeTerritory",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey("TerritoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Territories"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Employees"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "TerritoryId").IsClustered(false);

                            j.ToTable("EmployeeTerritories");

                            j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");

                            j.IndexerProperty<string>("TerritoryId").HasMaxLength(20).HasColumnName("TerritoryID");
                        });
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToView("Invoices");

                entity.Property(e => e.CustomerId).IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerId).IsFixedLength();

                entity.Property(e => e.Freight).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_Order_Details");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Products");
            });

            modelBuilder.Entity<OrderDetailsExtended>(entity =>
            {
                entity.ToView("Order Details Extended");
            });

            modelBuilder.Entity<OrderSubtotal>(entity =>
            {
                entity.ToView("Order Subtotals");
            });

            modelBuilder.Entity<OrdersQry>(entity =>
            {
                entity.ToView("Orders Qry");

                entity.Property(e => e.CustomerId).IsFixedLength();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            modelBuilder.Entity<ProductSalesFor1997>(entity =>
            {
                entity.ToView("Product Sales for 1997");
            });

            modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
            {
                entity.ToView("Products Above Average Price");
            });

            modelBuilder.Entity<ProductsByCategory>(entity =>
            {
                entity.ToView("Products by Category");
            });

            modelBuilder.Entity<QuarterlyOrder>(entity =>
            {
                entity.ToView("Quarterly Orders");

                entity.Property(e => e.CustomerId).IsFixedLength();
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionId)
                    .IsClustered(false);

                entity.Property(e => e.RegionId).ValueGeneratedNever();

                entity.Property(e => e.RegionDescription).IsFixedLength();
            });

            modelBuilder.Entity<SalesByCategory>(entity =>
            {
                entity.ToView("Sales by Category");
            });

            modelBuilder.Entity<SalesTotalsByAmount>(entity =>
            {
                entity.ToView("Sales Totals by Amount");
            });

            modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
            {
                entity.ToView("Summary of Sales by Quarter");
            });

            modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
            {
                entity.ToView("Summary of Sales by Year");
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.HasKey(e => e.TerritoryId)
                    .IsClustered(false);

                entity.Property(e => e.TerritoryDescription).IsFixedLength();

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Territories_Region");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
