using System;
using System.Collections.Generic;
using System.Linq;

namespace JG_Domain.Entities
{
    public class User
    {
        public IEnumerable<Question> QuestionList { get; set; }
        public int GetTotalScore()
        {
            return QuestionList.Where(c => c.Answers.Any(a => a.Right)).Count();
        }
    }
}
