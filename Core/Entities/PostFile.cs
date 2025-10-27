using System.Text.Json.Serialization;

namespace stack_overflow.Core.Entities;

public class PostFile
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string FilePath { get; set; }
    public string OriginalFileName { get; set; }
    
    public int PostId { get; set; }
    [JsonIgnore]
    public Post? Post { get; set; }
}