using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        public T GetBy(Expression<Func<T, bool>> expression);
        public T GetByID(int id);
        public void Add(T entity);
        public void Delete(T entity);
        public void DeleteAll(IQueryable<T> entity);
        public void Update(T entity);
        public void Update(T entity, params Expression<Func<T, object>>[] expressions);
    }
}
