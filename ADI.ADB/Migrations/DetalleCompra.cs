﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("DetalleCompra")]
public partial class DetalleCompra
{
    [Key]
    public Guid id { get; set; }

    public Guid Compra_id { get; set; }

    public Guid Producto_id { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Precio { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Descuento { get; set; }

    [StringLength(50)]
    public string Descripcion { get; set; } = null!;

    [ForeignKey("Compra_id")]
    [InverseProperty("DetalleCompras")]
    public virtual Compra Compra { get; set; } = null!;

    [ForeignKey("Producto_id")]
    [InverseProperty("DetalleCompras")]
    public virtual Producto Producto { get; set; } = null!;
}