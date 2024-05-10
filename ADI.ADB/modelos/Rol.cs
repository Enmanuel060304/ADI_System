using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.modelos;

[Table("Rol")]
[Index("Nombre", Name = "IX_Rol_Nombre", IsUnique = true)]
public partial class Rol
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("rol")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
