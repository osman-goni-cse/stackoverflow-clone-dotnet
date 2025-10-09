using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.Core.Services;

public class AnswerService : IAnswerService
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public AnswerService(IAnswerRepository answerRepository, IPostRepository postRepository,
        IUserRepository userRepository)
    {
        _answerRepository = answerRepository;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }
    
    public Answer Create(CreateAnswerRequestDto AnswerRequestDto)
    {
        Post post = _postRepository.Get(AnswerRequestDto.PostId);
        User user = _userRepository.Get(AnswerRequestDto.UserId);

        var answer = new Answer
        {
            Body = AnswerRequestDto.Body,
            User = user,
            Post = post
        };
        
        _answerRepository.Create(answer);
        return answer;
    }
}