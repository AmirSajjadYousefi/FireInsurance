using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FireInsurance.Repository.Base
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        Task CreateRange(List<T> entity);
        Task Remove(T entity);
        Task RemoveRange(List<T> entity);
        Task Remove(object id);
        Task Update(T entity);
        Task Update(object id);
        Task<T> GetById(object id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        Task Save();
    }
}
