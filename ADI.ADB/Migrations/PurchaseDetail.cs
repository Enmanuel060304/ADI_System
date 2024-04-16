using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Keyless]
[Table("PurchaseDetail")]
public partial class PurchaseDetail
{
    public Guid Id_Purchase { get; set; }

    public Guid Id_Product { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [StringLength(50)]
    public string Description { get; set; } = null!;

    [ForeignKey("Id_Product")]
    public virtual Product Id_ProductNavigation { get; set; } = null!;

    [ForeignKey("Id_Purchase")]
    public virtual Purchase Id_PurchaseNavigation { get; set; } = null!;
}
