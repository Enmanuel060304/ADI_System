using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("VENTA")]
public partial class VENTum
{
    [Key]
    public int ID { get; set; }

    public int ID_CLIENTE { get; set; }

    public int ID_EMPLEADO { get; set; }

    public DateOnly FECHA { get; set; }

    [ForeignKey("ID_CLIENTE")]
    [InverseProperty("VENTa")]
    public virtual CLIENTE ID_CLIENTENavigation { get; set; } = null!;

    [ForeignKey("ID_EMPLEADO")]
    [InverseProperty("VENTa")]
    public virtual EMPLEADO ID_EMPLEADONavigation { get; set; } = null!;
}
