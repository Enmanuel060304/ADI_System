using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("CLIENTE")]
public partial class CLIENTE
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

    [InverseProperty("ID_CLIENTENavigation")]
    public virtual ICollection<VENTum> VENTa { get; set; } = new List<VENTum>();
}
