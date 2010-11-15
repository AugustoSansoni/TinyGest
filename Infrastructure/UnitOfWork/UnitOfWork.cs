using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Estro.TinyGest.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Guid key;
        private Dictionary<IEntity, IUnitOfWorkRepository> addedEntities;
        private Dictionary<IEntity, IUnitOfWorkRepository> changedEntities;
        private Dictionary<IEntity, IUnitOfWorkRepository> deletedEntities;

        public UnitOfWork()
        {
            this.key = Guid.NewGuid();
            this.addedEntities = new Dictionary<IEntity,
                                     IUnitOfWorkRepository>();
            this.changedEntities = new Dictionary<IEntity,
                                       IUnitOfWorkRepository>();
            this.deletedEntities = new Dictionary<IEntity,
                                       IUnitOfWorkRepository>();
        }

        #region IUnitOfWork Members

        public void RegisterAdded(IEntity entity,
            IUnitOfWorkRepository repository)
        {
            this.addedEntities.Add(entity, repository);
        }

        public void RegisterChanged(IEntity entity,
            IUnitOfWorkRepository repository)
        {
            this.changedEntities.Add(entity, repository);
        }

        public void RegisterRemoved(IEntity entity,
            IUnitOfWorkRepository repository)
        {
            this.deletedEntities.Add(entity, repository);
        }

        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (IEntity entity in this.deletedEntities.Keys)
                {
                    this.deletedEntities[entity].PersistDeletedItem(entity);
                    //this.clientTransactionRepository.Add(
                    //    new ClientTransaction(this.key,
                    //    TransactionType.Delete, entity));
                }

                foreach (IEntity entity in this.addedEntities.Keys)
                {
                    this.addedEntities[entity].PersistNewItem(entity);
                    //this.clientTransactionRepository.Add(
                    //    new ClientTransaction(this.key,
                    //    TransactionType.Insert, entity));
                }

                foreach (IEntity entity in this.changedEntities.Keys)
                {
                    this.changedEntities[entity].PersistUpdatedItem(entity);
                    //this.clientTransactionRepository.Add(
                    //    new ClientTransaction(this.key,
                    //    TransactionType.Update, entity));
                }

                scope.Complete();
            }

            this.deletedEntities.Clear();
            this.addedEntities.Clear();
            this.changedEntities.Clear();
            this.key = Guid.NewGuid();
        }

        public object Key
        {
            get { return this.key; }
        }

        //public IClientTransactionRepository ClientTransactionRepository
        //{
        //    get { return this.clientTransactionRepository; }
        //}

        #endregion
    }
}
