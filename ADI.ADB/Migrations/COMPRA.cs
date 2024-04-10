using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("COMPRA")]
public partial class COMPRA
{
    [Key]
    public int ID { get; set; }

    public DateOnly FECHA { get; set; }

    public int ID_PROVEEDOR { get; set; }

    public int Id_EMPLEADO { get; set; }

    [ForeignKey("ID_PROVEEDOR")]
    [InverseProperty("COMPRAs")]
    public virtual PROVEEDOR ID_PROVEEDORNavigation { get; set; } = null!;

    [ForeignKey("Id_EMPLEADO")]
    [InverseProperty("COMPRAs")]
    public virtual EMPLEADO Id_EMPLEADONavigation { get; set; } = null!;
}
