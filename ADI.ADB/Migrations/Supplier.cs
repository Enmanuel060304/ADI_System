using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Supplier")]
[Index("Name", "LastName", "Phone", "Email", Name = "IX_Supplier_name", IsUnique = true)]
public partial class Supplier
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string Phone { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string Address { get; set; } = null!;

    [InverseProperty("Supplier")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
