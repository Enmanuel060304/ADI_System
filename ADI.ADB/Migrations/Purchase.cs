using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Purchase")]
public partial class Purchase
{
    [Key]
    public Guid id { get; set; }

    public DateTimeOffset Date { get; set; }

    public Guid Supplier_id { get; set; }

    public Guid Employee_id { get; set; }

    [ForeignKey("Employee_id")]
    [InverseProperty("Purchases")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("Supplier_id")]
    [InverseProperty("Purchases")]
    public virtual Supplier Supplier { get; set; } = null!;
}
