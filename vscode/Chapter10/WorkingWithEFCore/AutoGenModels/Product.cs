using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore.AutoGen
{
    [Index("CategoryId", Name = "CategoriesProducts")]
    [Index("CategoryId", Name = "CategoryId")]
    [Index("ProductName", Name = "ProductName")]
    [Index("SupplierId", Name = "SupplierId")]
    [Index("SupplierId", Name = "SuppliersProducts")]
    public partial class Product
    {
        [Key]
        public long ProductId { get; set; }
        [Column(TypeName = "nvarchar (40)")]
        public string ProductName { get; set; } = null!;
        [Column(TypeName = "int")]
        public long? SupplierId { get; set; }
        [Column(TypeName = "int")]
        public long? CategoryId { get; set; }
        [Column(TypeName = "nvarchar (20)")]
        public string? QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        public byte[]? UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        public long? UnitsInStock { get; set; }
        [Column(TypeName = "smallint")]
        public long? UnitsOnOrder { get; set; }
        [Column(TypeName = "smallint")]
        public long? ReorderLevel { get; set; }
        [Column(TypeName = "bit")]
        public byte[] Discontinued { get; set; } = null!;

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Category? Category { get; set; }
    }
}
