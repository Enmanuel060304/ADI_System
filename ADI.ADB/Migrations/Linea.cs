using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Linea")]
[Index("Nombre", Name = "IX_Linea_Nombre", IsUnique = true)]
public partial class Linea
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("Id_LineaNavigation")]
    public virtual ICollection<Categorias> Categoria { get; set; } = new List<Categorias>();
}
