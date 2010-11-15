using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estro.TinyGest.Infrastructure;

namespace Estro.TinyGest.Entities
{
    public partial class Invoice : EntityBase
    {

        public override object Key
        {
            get
            {
                return InvoiceId;
            }
            
        }


        public override string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}