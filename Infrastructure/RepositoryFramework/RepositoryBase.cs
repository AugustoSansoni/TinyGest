using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estro.TinyGest.Infrastructure
{
    public abstract class RepositoryBase<T>
        : IRepository<T>, IUnitOfWorkRepository where T : IAggregateRoot
    {
        #region Private Fields

        private IUnitOfWork unitOfWork;

        #endregion

        #region Constructors

        protected RepositoryBase()
            : this(null)
        {
        }

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository<T> Members
        public IQueryable<T> FindWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public abstract T FindBy(object key);

        public abstract IQueryable<T> FindAll();

        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(T item)
        {
            if (this.unitOfWork != null)
            {
                this.unitOfWork.RegisterAdded(item, this);
            }
        }

        public void Remove(T item)
        {
            if (this.unitOfWork != null)
            {
                this.unitOfWork.RegisterRemoved(item, this);
            }
        }

        public T this[object key]
        {
            get
            {
                return this.FindBy(key);
            }
            set
            {
                if (this.FindBy(key) == null)
                {
                    this.Add(value);
                }
                else
                {
                    if (this.unitOfWork != null)
                    {
                        this.unitOfWork.RegisterChanged(value, this);
                    }
                }
            }
        }

        #endregion

        #region IUnitOfWorkRepository Members

        public virtual void PersistNewItem(IEntity item)
        {
            this.PersistNewItem((T)item);
        }

        public virtual void PersistUpdatedItem(IEntity item)
        {
            this.PersistUpdatedItem((T)item);
        }

        public virtual void PersistDeletedItem(IEntity item)
        {
            this.PersistDeletedItem((T)item);
        }

        #endregion

        #region Properties

        protected IUnitOfWork UnitOfWork
        {
            get { return this.unitOfWork; }
        }

        #endregion

        #region Methods

        protected abstract void PersistNewItem(T item);
        protected abstract void PersistUpdatedItem(T item);
        protected abstract void PersistDeletedItem(T item);

        #endregion


        
    }
}
