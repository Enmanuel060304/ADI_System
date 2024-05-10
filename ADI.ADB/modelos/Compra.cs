using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.modelos;

[Table("Compra")]
public partial class Compra
{
    [Key]
    public Guid id { get; set; }

    public Guid Proveedor_id { get; set; }

    public Guid Empleado_id { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalFacturado { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalDescuento { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Descuento { get; set; }

    public DateTimeOffset Fecha { get; set; }

    [InverseProperty("Compra")]
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    [ForeignKey("Empleado_id")]
    [InverseProperty("Compras")]
    public virtual Empleado Empleado { get; set; } = null!;

    [ForeignKey("Proveedor_id")]
    [InverseProperty("Compras")]
    public virtual Proveedor Proveedor { get; set; } = null!;
}
