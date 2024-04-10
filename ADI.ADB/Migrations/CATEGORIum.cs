using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("CATEGORIA")]
public partial class CATEGORIum
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    public int ID_LINEA { get; set; }

    [ForeignKey("ID_LINEA")]
    [InverseProperty("CATEGORIa")]
    public virtual LINEA ID_LINEANavigation { get; set; } = null!;

    [InverseProperty("ID_CATEGORIANavigation")]
    public virtual ICollection<PRODUCTO> PRODUCTOs { get; set; } = new List<PRODUCTO>();
}
