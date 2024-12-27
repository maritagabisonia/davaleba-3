using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace dav33.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null
        );

        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    
 }
}
