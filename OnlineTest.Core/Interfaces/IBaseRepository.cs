using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Core.Interfaces
{
    public interface IBaseRepository<T, TKey> where T : class where TKey : IEquatable<TKey>
    {
        Task<T> GetById(TKey id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
      
        T Update(T entity);
        T Delete(T entity);
        Task Save();

    }
}
