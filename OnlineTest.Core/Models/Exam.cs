using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Core.Models
{
    public class Exam:ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
