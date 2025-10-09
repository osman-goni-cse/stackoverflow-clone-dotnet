using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Infrastructure.Data;

namespace stack_overflow.Infrastructure.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly ApplicationDbContext _context;
    
    public AnswerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Answer Create(Answer Answer)
    {
        Answer answer = _context.Answers.Add(Answer).Entity;
        _context.SaveChanges();
        return answer;
    }
}