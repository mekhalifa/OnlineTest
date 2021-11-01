using OnlineTest.Core.Models;
using OnlineTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineTest.Infrastructure.Repositories
{
     public class QuestionRepo :BaseRepository<Question,int>
    {
        private readonly OnlineTestDbContext _context;

        public QuestionRepo(OnlineTestDbContext context)
            :base(context)
        {
            _context = context;
        }
    }
}
