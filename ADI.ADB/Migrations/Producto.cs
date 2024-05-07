using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Producto")]
[Index("Nombre", Name = "IX_Producto_Nombre", IsUnique = true)]
public partial class Producto
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrecioCompra { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrecioVenta { get; set; }

    public int Stock { get; set; }

    public Guid Categoria_id { get; set; }

    [ForeignKey("Categoria_id")]
    [InverseProperty("Productos")]
    public virtual Categorias Categoria { get; set; } = null!;

    [InverseProperty("Producto")]
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    [InverseProperty("Producto")]
    public virtual ICollection<DetalleVentas> DetalleVenta { get; set; } = new List<DetalleVentas>();
}
