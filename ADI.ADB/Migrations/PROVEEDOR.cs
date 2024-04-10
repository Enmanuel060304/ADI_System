using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("PROVEEDOR")]
public partial class PROVEEDOR
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NOMBRE { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EMAIL { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TELEFONO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DIRECCION { get; set; }

    [InverseProperty("ID_PROVEEDORNavigation")]
    public virtual ICollection<COMPRA> COMPRAs { get; set; } = new List<COMPRA>();
}
