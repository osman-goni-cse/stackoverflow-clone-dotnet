using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace stack_overflow.Core.Entities;

public class Tag
{
    public int ID {get; set;}
    
    [Required]
    public string Name {get; set;}
    
    [Required]
    public string Description {get; set;}
    
    [JsonIgnore]
    public List<Post> Posts { get; set; } = new List<Post>();
}