using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Core.Models
{
    public class Question :ModelBase
    {
        public string QuestionText { get; set; }
        public double QuestionPoint { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }

    }
}
