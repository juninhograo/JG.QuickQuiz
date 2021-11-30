﻿using JG_Domain.Entities;
using JG_Domain.Entities.NotMapped;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JG_Domain.Interface
{
    public interface IQuizProvider {
        Task<(bool IsSuccess, IEnumerable<Quiz> QuizList, string ErrorMessage)> ListAsync(GenericFilter filter);
        Task<(bool IsSuccess, Quiz Quiz, string ErrorMessage)> GetAsync(string id);
    }
}
