using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("EMPLEADO")]
public partial class EMPLEADO
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string NOMBRE { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string APELLIDO { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string EMAIL { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string TELEFONO { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string DIRECCION { get; set; } = null!;

    public int ID_ROLE { get; set; }

    [InverseProperty("Id_EMPLEADONavigation")]
    public virtual ICollection<COMPRA> COMPRAs { get; set; } = new List<COMPRA>();

    [ForeignKey("ID_ROLE")]
    [InverseProperty("EMPLEADOs")]
    public virtual ROLE ID_ROLENavigation { get; set; } = null!;

    [InverseProperty("ID_EMPLEADONavigation")]
    public virtual ICollection<VENTum> VENTa { get; set; } = new List<VENTum>();
}
