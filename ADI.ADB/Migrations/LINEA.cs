using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("LINEA")]
public partial class LINEA
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NOMBRE { get; set; } = null!;

    [InverseProperty("ID_LINEANavigation")]
    public virtual ICollection<CATEGORIum> CATEGORIa { get; set; } = new List<CATEGORIum>();
}
