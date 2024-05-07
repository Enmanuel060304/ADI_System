using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Index("Nombre", Name = "IX_Categoria_Nombre", IsUnique = true)]
public partial class Categorias
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public Guid Id_Linea { get; set; }

    [ForeignKey("Id_Linea")]
    [InverseProperty("Categoria")]
    public virtual Linea Id_LineaNavigation { get; set; } = null!;

    [InverseProperty("Categoria")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
