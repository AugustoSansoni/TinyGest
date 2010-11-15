using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Linq.Expressions;

namespace Estro.TinyGest.Infrastructure
{
    public class EFRepository<T> : IRepository<T>
                                where T : class, IEntity,IAggregateRoot
    {
        public EFRepository(ObjectContext context)
        {
            _objectSet = context.CreateObjectSet<T>();
        }
        public IQueryable<T> FindAll()
        {
            return _objectSet;
        }
        public IQueryable<T> FindWhere(
                               Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where(predicate);
        }
        public T FindBy(object key)
        {
            return _objectSet.Single(o => o.Key == key);
        }
        public void Add(T newEntity)
        {
            _objectSet.AddObject(newEntity);
        }
        public void Remove(T entity)
        {
            _objectSet.DeleteObject(entity);
        }
        protected ObjectSet<T> _objectSet;



        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }

        public T this[object key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
               
    }

}
