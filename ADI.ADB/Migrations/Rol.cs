using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Rol")]
[Index("name", Name = "IX_Rol_name", IsUnique = true)]
public partial class Rol
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string name { get; set; } = null!;

    [InverseProperty("rol")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
