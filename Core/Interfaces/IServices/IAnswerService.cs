using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces.IServices;

public interface IAnswerService
{
    public Answer Create(CreateAnswerRequestDto AnswerRequestDto);
}