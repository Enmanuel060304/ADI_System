    
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ADI.ADB.Migrations;

//[Bind(nameof(id), nameof(Name), nameof(Id_Line))]
[Table("Category")]
[Index("Name", Name = "IX_Category_Name", IsUnique = true)]
public partial class Category
{
    [Key]
    public Guid id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public Guid Id_Line { get; set; }

    [BindNever]
    [ForeignKey("Id_Line")]
    [InverseProperty("Categories")]
    public virtual Line Id_LineNavigation { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
