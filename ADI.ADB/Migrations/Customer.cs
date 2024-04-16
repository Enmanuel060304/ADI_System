using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Customer")]
[Index("name", "LastName", "Phone", "Email", Name = "IX_Customer_name", IsUnique = true)]
public partial class Customer
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
    public string Email { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
