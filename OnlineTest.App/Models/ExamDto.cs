using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineTest.App.Models
{
    public class ExamDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<QuestionDto> Questions { get; set; }
    }
}
