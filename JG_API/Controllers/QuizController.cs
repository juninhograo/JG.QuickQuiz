using Microsoft.AspNetCore.Mvc;
using JG_Domain.Entities;
using Microsoft.Extensions.Logging;
using JG_Application.Interface;
using System.Threading.Tasks;
using JG_Domain.Entities.NotMapped;

namespace JG_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizApplication _quizApplication;

        public QuizController(ILogger<Quiz> logger, IQuizApplication quizApplication)
        {
            _quizApplication = quizApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _quizApplication.ListAsync(new GenericFilter());
            return result.IsSuccess ? Ok(result.QuizList) : NotFound();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _quizApplication.GetAsync(id);
            return result.IsSuccess ? Ok(result.Quiz) : NotFound();
        }
    }
}