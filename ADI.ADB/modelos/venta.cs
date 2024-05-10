using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.modelos;

public partial class venta
{
    [Key]
    public Guid id { get; set; }

    public Guid Cliente_id { get; set; }

    public Guid Empleado_id { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalFacturado { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalDescuento { get; set; }

    public DateTimeOffset Fecha { get; set; }

    [ForeignKey("Cliente_id")]
    [InverseProperty("venta")]
    public virtual Cliente Cliente { get; set; } = null!;

    [InverseProperty("Venta")]
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    [ForeignKey("Empleado_id")]
    [InverseProperty("venta")]
    public virtual Empleado Empleado { get; set; } = null!;
}
