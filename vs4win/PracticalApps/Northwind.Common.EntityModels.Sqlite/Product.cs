using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Packt.Shared
{
  [Index("CategoryId", Name = "CategoriesProducts")]
  [Index("CategoryId", Name = "CategoryId")]
  [Index("ProductName", Name = "ProductName")]
  [Index("SupplierId", Name = "SupplierId")]
  [Index("SupplierId", Name = "SuppliersProducts")]
  public partial class Product
  {
    public Product()
    {
      OrderDetails = new HashSet<OrderDetail>();
    }

    [Key]
    public int ProductId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar (40)")]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "int")]
    public int? SupplierId { get; set; }

    [Column(TypeName = "int")]
    public int? CategoryId { get; set; }

    [Column(TypeName = "nvarchar (20)")]
    [StringLength(20)]
    public string? QuantityPerUnit { get; set; }

    [Column(TypeName = "money")]
    public decimal? UnitPrice { get; set; }

    [Column(TypeName = "smallint")]
    public short? UnitsInStock { get; set; }
    [Column(TypeName = "smallint")]
    public short? UnitsOnOrder { get; set; }
    [Column(TypeName = "smallint")]
    public short? ReorderLevel { get; set; }

    [Column(TypeName = "bit")]
    public bool Discontinued { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category? Category { get; set; }
    [ForeignKey("SupplierId")]
    [InverseProperty("Products")]
    public virtual Supplier? Supplier { get; set; }
    [InverseProperty("Product")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
  }
}
