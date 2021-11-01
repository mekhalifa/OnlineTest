using Microsoft.EntityFrameworkCore;
using OnlineTest.Core.Models;
using OnlineTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Infrastructure.Repositories
{
     public class AnswerRepo :BaseRepository<Answer,int>
    {
        private readonly OnlineTestDbContext _context;

        public AnswerRepo(OnlineTestDbContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task< List<Answer>> GetAllByQuestionId(int id)
        {
          return  await _context.Answers.Where(m => m.QuestionId == id).ToListAsync();
        }

        public void OnlyOneCurrect()
        {
            List<Answer>  list=  _context.Answers.Where(m => m.IsCorrect == true).ToList();

            foreach (var item in list)
            {
                item.IsCorrect = false;
                Update(item);
            }
        }
    }
}
