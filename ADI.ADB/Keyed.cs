using System.ComponentModel.DataAnnotations;

namespace ADI.ADB;

public abstract class Keyed
{
    [Key]
    [Required]
    public Guid Id { get; set; }
}
