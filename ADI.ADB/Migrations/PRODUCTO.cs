using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("PRODUCTO")]
public partial class PRODUCTO
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NOMBRE { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PRECIO { get; set; }

    public int STOCK { get; set; }

    public int ID_CATEGORIA { get; set; }

    [ForeignKey("ID_CATEGORIA")]
    [InverseProperty("PRODUCTOs")]
    public virtual CATEGORIum ID_CATEGORIANavigation { get; set; } = null!;
}
