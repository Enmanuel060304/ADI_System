using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("ROLE")]
public partial class ROLE
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NAME { get; set; } = null!;

    [InverseProperty("ID_ROLENavigation")]
    public virtual ICollection<EMPLEADO> EMPLEADOs { get; set; } = new List<EMPLEADO>();
}
