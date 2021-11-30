using JG_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace JG_Infra.Config
{
    public class ContextBaseMongoDB : DbContext
    {
        public IConfiguration Configuration;
        public ContextBaseMongoDB(DbContextOptions<ContextBaseMongoDB> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(StrincConectionConfig(Configuration));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Answer>();
            modelBuilder.Entity<Question>();
            modelBuilder.Entity<Quiz>();
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public static string StrincConectionConfig(IConfiguration configuration)
        {
            string strCon = configuration["QuizDatabaseSettings:Connection"];
            return strCon;
        }
    }
}
