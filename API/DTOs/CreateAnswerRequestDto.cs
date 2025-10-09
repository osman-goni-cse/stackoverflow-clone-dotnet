using stack_overflow.Core.Entities;

namespace stack_overflow.API.DTOs;

public class CreateAnswerRequestDto
{
    public string Body { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
}