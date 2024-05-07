using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Empleado")]
[Index("Nombre", "Apellido", "Telefono", "email", Name = "IX_Empleado_Nombre", IsUnique = true)]
public  class Empleado
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "El Nombre del Empleado es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    [Required(ErrorMessage = "El Apellido del Empleado es obligatorio.")]
    public string Apellido { get; set; } = null!;

    [StringLength(50)]
    [Required(ErrorMessage = "El Telefono del Empleado es obligatorio.")]
    public string Telefono { get; set; } = null!;

    [StringLength(50)]
    [Required(ErrorMessage = "El email del Empleado es obligatorio.")]
    public string email { get; set; } = null!;

    [StringLength(50)]
    [Required(ErrorMessage = "La Contraseña del Empleado es obligatoria.")]
    public string Contraseña { get; set; } = null!;

    public Guid rol_id { get; set; }

    [InverseProperty("Empleado")]
    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    [ForeignKey("rol_id")]
    [InverseProperty("Empleados")]
    public virtual Rol rol { get; set; } = null!;

    [InverseProperty("Empleado")]
    public virtual ICollection<ventas> venta { get; set; } = new List<ventas>();
}
