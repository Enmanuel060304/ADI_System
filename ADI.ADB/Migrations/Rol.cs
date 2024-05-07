using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Rol")]
[Index("Nombre", Name = "IX_Rol_Nombre", IsUnique = true)]
public  class Rol
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "El Nombre es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [InverseProperty("rol")]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
