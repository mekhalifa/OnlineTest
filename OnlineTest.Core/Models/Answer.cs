using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Core.Models
{
    public class Answer :ModelBase
    {
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
