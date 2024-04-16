using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CrudWhitRazor.Models;

[Table("Line")]
[Index("Name", Name = "IX_Line_Name", IsUnique = true)]
public partial class Line
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    [Required]
    public string Name { get; set; } = null!;
}
