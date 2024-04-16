using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Employee")]
[Index("name", "LastName", "email", "Phone", "password", Name = "IX_Employee_name", IsUnique = true)]
public partial class Employee
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string name { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string Phone { get; set; } = null!;

    [StringLength(50)]
    public string email { get; set; } = null!;

    [StringLength(50)]
    public string password { get; set; } = null!;

    public Guid rol_id { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    [InverseProperty("Employee")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [ForeignKey("rol_id")]
    [InverseProperty("Employees")]
    public virtual Rol rol { get; set; } = null!;
}
