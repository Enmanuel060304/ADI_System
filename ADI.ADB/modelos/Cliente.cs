using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.modelos;

[Table("Cliente")]
[Index("Nombre", "Apellido", "Telefono", "Email", Name = "IX_Cliente_Nombre", IsUnique = true)]
public partial class Cliente
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string? Nombre { get; set; }

    [StringLength(50)]
    public string? Apellido { get; set; }

    [StringLength(50)]
    public string? Telefono { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [InverseProperty("Cliente")]
    public virtual ICollection<venta> venta { get; set; } = new List<venta>();
}
