using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.modelos;

[Table("Linea")]
[Index("Nombre", Name = "IX_Linea_Nombre", IsUnique = true)]
public partial class Linea
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Linea")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
