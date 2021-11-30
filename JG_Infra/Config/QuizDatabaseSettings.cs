namespace JG_Infra.Config
{
    public class QuizDatabaseSettings : IQuizDatabaseSettings
    {
        public string QuizCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IQuizDatabaseSettings
    {
        string QuizCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
