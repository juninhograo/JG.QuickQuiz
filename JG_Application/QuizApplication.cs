using JG_Application.Interface;
using JG_Domain.Entities;
using JG_Domain.Entities.NotMapped;
using JG_Domain.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JG_Application
{
    public class QuizApplication : IQuizApplication
    {
        IQuizProvider quizRepository;
        public QuizApplication(IQuizProvider _quizRepository)
        {
            quizRepository = _quizRepository;
        }
        public Task<(bool IsSuccess, IEnumerable<Quiz> QuizList, string ErrorMessage)> ListAsync(GenericFilter filter)
        {
            return quizRepository.ListAsync(filter);
        }
        public Task<(bool IsSuccess, Quiz Quiz, string ErrorMessage)> GetAsync(string id)
        {
            return quizRepository.GetAsync(id);
        }
    }
}
