using JG_Domain.Entities;
using JG_Domain.Entities.NotMapped;
using JG_Domain.Interface;
using JG_Infra.Config;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JG_Infra.Service
{
    public class QuizService : IQuizProvider
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IQuizDatabaseSettings _settings;
        private readonly IMongoCollection<Quiz> _quizList;
        private readonly ILogger<Quiz> _logger;
        public QuizService(IQuizDatabaseSettings settings, ILogger<Quiz> logger)
        {
            _settings = settings;
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);
            _quizList = _database.GetCollection<Quiz>(_settings.QuizCollectionName);
            _logger = logger;
        }
        private async Task<List<Quiz>> Get()
        {
            var quizList = await _quizList.Find(c => true).ToListAsync();
            return quizList;
        }
        private async Task<Quiz> Get(string id) => await _quizList.Find(c => c.Id == id).FirstOrDefaultAsync();
        #region TODO
        private Quiz Create(Quiz quiz)
        {
            _quizList.InsertOne(quiz);
            return quiz;
        }
        private void Update(string id, Quiz obj) =>  _quizList.ReplaceOne(q => q.Id == id, obj);
        private void Remove(string id) => _quizList.DeleteOne(q => q.Id == id);
        #endregion
        public async Task<(bool IsSuccess, IEnumerable<Quiz> QuizList, string ErrorMessage)> ListAsync(GenericFilter filter)
        {
            try
            {
                var result = await Get();
                if (result.Count == 0)
                    return (false, null, "No records found!");
                return (true, result, string.Empty);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return new(false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, Quiz Quiz, string ErrorMessage)> GetAsync(string id)
        {
            try
            {
                var result = await Get(id);
                if (result == null)
                    return (false, null, "No records found!");
                return (true, result, string.Empty);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return new(false, null, ex.Message);
            }
        }
    }
}