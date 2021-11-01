using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineTest.App.Models
{
    public class QuestionDto 
    {
        public int Id { get; set; }
        
        [Display(Name = "Question")]
        [Required]
        public string QuestionText { get; set; }
        [Display(Name = "Point")]
        [Required]
        public double QuestionPoint { get; set; }

        public virtual ICollection<AnswerDto> Answers { get; set; }
    }

    public class QuestionListDto
    {
        public int Id { get; set; }

        [Display(Name = "Question")]
        [Required]
        public string QuestionText { get; set; }
        [Display(Name = "Point")]
        [Required]
        public double QuestionPoint { get; set; }

        public int AnswersCount { get; set; }
    }
}
