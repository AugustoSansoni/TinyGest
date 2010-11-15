using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estro.TinyGest.Entities
{
    public enum InvoiceStatus
    {
        Created=0,Printed=1,WaitingForPayment=2, Payed=3, PartiallyPayed=4,Canceled=5
    }
}
