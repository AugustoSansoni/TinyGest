using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Estro.TinyGest.Infrastructure
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate);
        void SetUnitOfWork(IUnitOfWork unitOfWork);
        T this[object key] { get; set; }
        T FindBy(object key);
        void Add(T newEntity);
        void Remove(T entity);
    }
   

}
