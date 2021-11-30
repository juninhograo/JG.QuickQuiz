using JG.Application.Interface;
using JG_Domain.Entities;
using JG_Domain.Entities.NotMapped;
using JG_Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JG.Application
{
    public class QuizApplication : IQuizApplication
    {
        IQuiz quizRepository;
        public QuizApplication(IQuiz _quizRepository)
        {
            quizRepository = _quizRepository;
        }

        public Task<(bool IsSuccess, IEnumerable<Quiz> QuizList, string ErrorMessage)> ListAsync(GenericFilter filter)
        {
            return quizRepository.ListAsync(filter);
        }
    }
}