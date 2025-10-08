using System.Text.Json.Serialization;

namespace stack_overflow.Core.Entities;

public class User
{
    public int ID {get; set;}
    public string DisplayName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    
    [JsonIgnore]
    public ICollection<Post> Posts {get; } =  new List<Post>();
    
}