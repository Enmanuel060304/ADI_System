using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.modelos;

public partial class DetalleVenta
{
    [Key]
    public Guid id { get; set; }

    public Guid Venta_id { get; set; }

    public Guid Producto_id { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Descuento { get; set; }

    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    [ForeignKey("Producto_id")]
    [InverseProperty("DetalleVenta")]
    public virtual Producto Producto { get; set; } = null!;

    [ForeignKey("Venta_id")]
    [InverseProperty("DetalleVenta")]
    public virtual venta Venta { get; set; } = null!;
}
