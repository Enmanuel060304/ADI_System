using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Product")]
[Index("Name", Name = "IX_Product_Name", IsUnique = true)]
public partial class Product
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }

    public Guid Category_id { get; set; }

    [ForeignKey("Category_id")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("id_ProductNavigation")]
    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
