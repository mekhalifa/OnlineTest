using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Core.Models
{
   public class UserAnswer :ModelBase
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
