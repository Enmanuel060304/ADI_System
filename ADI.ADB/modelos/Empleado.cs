using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.modelos;

[Table("Empleado")]
[Index("Nombre", "Apellido", "Telefono", "email", Name = "IX_Empleado_Nombre", IsUnique = true)]
public partial class Empleado
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    public string Apellido { get; set; } = null!;

    [StringLength(50)]
    public string Telefono { get; set; } = null!;

    [StringLength(50)]
    public string email { get; set; } = null!;

    [StringLength(50)]
    public string Contraseña { get; set; } = null!;

    public Guid rol_id { get; set; }

    [InverseProperty("Empleado")]
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    [ForeignKey("rol_id")]
    [InverseProperty("Empleados")]
    public virtual Rol rol { get; set; } = null!;

    [InverseProperty("Empleado")]
    public virtual ICollection<venta> venta { get; set; } = new List<venta>();
}
