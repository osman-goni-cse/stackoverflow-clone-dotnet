using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using stack_overflow.API.DTOs;
using stack_overflow.Core.Entities;
using stack_overflow.Core.Interfaces.IServices;

namespace stack_overflow.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService  _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }
    
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Answer> Create(CreateAnswerRequestDto AnswerRequestDto)
    {
        try
        {
            Answer answer = _answerService.Create(AnswerRequestDto);
            return StatusCode(StatusCodes.Status201Created, answer);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}