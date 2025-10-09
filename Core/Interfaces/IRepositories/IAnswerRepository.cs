using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces;

public interface IAnswerRepository
{
    public Answer Create(Answer Answer);
}