using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estro.TinyGest.Infrastructure
{
    public interface IUnitOfWorkRepository
    {
        void PersistNewItem(IEntity item);
        void PersistUpdatedItem(IEntity item);
        void PersistDeletedItem(IEntity item);
    }
}
