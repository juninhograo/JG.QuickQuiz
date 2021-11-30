﻿using JG_Domain.Entities;
using JG_Domain.Entities.NotMapped;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JG.Application.Interface
{
    internal interface IQuizApplication {
        Task<(bool IsSuccess, IEnumerable<Quiz> QuizList, string ErrorMessage)> ListAsync(GenericFilter filter);
    }
}