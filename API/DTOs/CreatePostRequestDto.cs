namespace stack_overflow.API.DTOs;

public class CreatePostRequestDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public List<int> TagIds { get; set; }
}