using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("SalesDetail")]
public partial class SalesDetail
{
    [Key]
    public Guid id { get; set; }

    public Guid id_Product { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [StringLength(50)]
    public string Description { get; set; } = null!;

    [ForeignKey("id_Product")]
    [InverseProperty("SalesDetails")]
    public virtual Product id_ProductNavigation { get; set; } = null!;
}
