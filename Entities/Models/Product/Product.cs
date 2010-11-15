using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estro.TinyGest.Infrastructure;

    namespace Estro.TinyGest.Entities
    {
        public partial class Product : EntityBase
        {
            public override object Key
            {
                get
                {
                    return ProductId;
                }                
            }

            
            public override string ToString(string format, IFormatProvider formatProvider)
            {
                throw new NotImplementedException();
            }
        }
    }

