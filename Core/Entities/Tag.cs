using System.ComponentModel.DataAnnotations;

namespace stack_overflow.Core.Entities;

public class Tag
{
    public int ID {get; set;}
    
    [Required]
    public string Name {get; set;}
    
    [Required]
    public string Description {get; set;}
}