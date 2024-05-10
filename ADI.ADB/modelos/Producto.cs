using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.modelos;

[Table("Producto")]
[Index("Nombre", Name = "IX_Producto_Nombre", IsUnique = true)]
public partial class Producto
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "Debes agrear un nombre al producto.")]
    public string Nombre { get; set; } = null!;
    
    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrecioCompra { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal PrecioVenta { get; set; }

    public int Stock { get; set; }

    public Guid Linea_id { get; set; }
    
    [NotMapped]
    public string CategoriaNombre { get; set; } 
    
    [NotMapped]
    public string LineaNombre { get; set; } 
    
    public Guid Categoria_id { get; set; }

    [ForeignKey("Categoria_id")]
    [InverseProperty("Productos")]
    public virtual Categoria Categoria { get; set; } = null!;

    [InverseProperty("Producto")]
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    [InverseProperty("Producto")]
    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    [ForeignKey("Linea_id")]
    [InverseProperty("Productos")]  
    public virtual Linea Linea { get; set; } = null!;
}
