using JG_Application;
using JG_Application.Interface;
using JG_Domain.Interface;
using JG_Infra.Config;
using JG_Infra.Repository;
using JG_Infra.Service;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repository
//services.AddSingleton<IQuiz, QuizRepository>();

//application
services.AddSingleton<IQuizApplication, QuizApplication>();

//services
services.AddSingleton<IQuizProvider, QuizService>();

// setup the mongodb settings
services.Configure<QuizDatabaseSettings>(builder.Configuration.GetSection(nameof(QuizDatabaseSettings)));
services.AddSingleton<IQuizDatabaseSettings>(sp => sp.GetRequiredService<IOptions<QuizDatabaseSettings>>().Value);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
