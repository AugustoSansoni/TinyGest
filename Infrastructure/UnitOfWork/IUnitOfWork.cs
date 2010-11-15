using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estro.TinyGest.Infrastructure
{
    public interface IUnitOfWork
    {
        void RegisterAdded(IEntity entity, IUnitOfWorkRepository repository);
        void RegisterChanged(IEntity entity, IUnitOfWorkRepository repository);
        void RegisterRemoved(IEntity entity, IUnitOfWorkRepository repository);
        void Commit();
        object Key { get; }
        //IClientTransactionRepository ClientTransactionRepository { get; }
    }
}
