using JG_Domain.Entities;
using JG_Domain.Entities.NotMapped;
using JG_Domain.Interface;
using JG_Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG_Infra.Repository
{
    public class QuizRepository : IQuiz
    {
        private readonly IMongoCollection<Quiz> _quizList;
        static IConfiguration _configuration;
        readonly DbContextOptionsBuilder<ContextBaseMongoDB> _optionsBuider;
        public QuizRepository(IConfiguration configuration)
        {
            _optionsBuider = new DbContextOptionsBuilder<ContextBaseMongoDB>();
            _configuration = configuration;
        }
        public async Task<(bool IsSuccess, IEnumerable<Quiz> quizList, string ErrorMessage)> ListAsync(GenericFilter filter)
        {
            try
            {
                ContextBaseMongoDB db = new ContextBaseMongoDB(_optionsBuider.Options, _configuration);
                var result = await db.Quizs.ToListAsync();
                if (result.Count == 0)
                    return (false, null, "No records found!");
                return (true, result, string.Empty);
            }
            catch (System.Exception ex)
            {
                return new(false, null, ex.Message);
            }
        }
    }
}
