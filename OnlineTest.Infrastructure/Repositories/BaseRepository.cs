using Microsoft.EntityFrameworkCore;
using OnlineTest.Core.Interfaces;
using OnlineTest.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Infrastructure.Repositories
{
    public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : class where TKey : IEquatable<TKey>
    {
        private readonly OnlineTestDbContext _context;

        public BaseRepository(OnlineTestDbContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Deleted;
            return entity;
        }

        public async  Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        
        public async Task< T> GetById(TKey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public T Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            return entity;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

 
    }
}
 