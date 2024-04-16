using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

[Table("Line")]
[Index("Name", Name = "IX_Line_Name", IsUnique = true)]
public partial class Line
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Id_LineNavigation")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
