using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Objects;
using System.ComponentModel;
using System.Globalization;

namespace Estro.TinyGest.Entities
{
    public partial class InvoiceEntities
    {
        public bool HasChanges
        {
            get
            {
                return ObjectStateManager.GetObjectStateEntries(EntityState.Added).Any()
                    || ObjectStateManager.GetObjectStateEntries(EntityState.Modified).Any()
                    || ObjectStateManager.GetObjectStateEntries(EntityState.Deleted).Any();
            }
        }


        private static string EntityToString(object entity)
        {
            IFormattable formattableEntity = entity as IFormattable;
            if (formattableEntity != null)
            {
                return formattableEntity.ToString(null, CultureInfo.CurrentCulture);
            }
            return entity.ToString();
        }
    }
}
