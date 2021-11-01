using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineTest.App.Models
{
    public class AnswerDto 
    {
        public int Id { get; set; }

        [Display(Name = "Answer")]
        [Required]
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public QuestionDto Question { get; set; }
    }


    public class AnswerListAdminDto
    {
        public int Id { get; set; }

        [Display(Name = "Answer")]
        [Required]
        public string AnswerText { get; set; }
        [Display(Name = "Is Corrct")]
    
        public bool IsCorrect { get; set; }

    }

    public class AnswerListUserDto
    {
        public int Id { get; set; }

        [Display(Name = "Answer")]
        [Required]
        public string AnswerText { get; set; }
      

    }
}
