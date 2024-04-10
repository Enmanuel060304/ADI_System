using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Keyless]
[Table("DETALLE_COMPRA")]
public partial class DETALLE_COMPRA
{
    public int ID_COMPRA { get; set; }

    public int ID_PRODUCTO { get; set; }

    public int CANTIDAD { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PRECIO { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string DESCRIPCION { get; set; } = null!;

    [ForeignKey("ID_COMPRA")]
    public virtual COMPRA ID_COMPRANavigation { get; set; } = null!;

    [ForeignKey("ID_PRODUCTO")]
    public virtual PRODUCTO ID_PRODUCTONavigation { get; set; } = null!;
}
