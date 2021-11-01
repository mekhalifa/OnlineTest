using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Core.Models
{
    public  class ExamQuestion
    {
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public  int QuestionId { get; set; }
        public virtual Question Question { get; set; }
       
    }
}
