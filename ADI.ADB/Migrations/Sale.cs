using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Sale")]
public partial class Sale
{
    [Key]
    public Guid id { get; set; }

    public Guid Customer_id { get; set; }

    public Guid Employee_id { get; set; }

    public DateTimeOffset Date { get; set; }

    [ForeignKey("Customer_id")]
    [InverseProperty("Sales")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("Employee_id")]
    [InverseProperty("Sales")]
    public virtual Employee Employee { get; set; } = null!;
}
