using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estro.TinyGest.Entities
{
    public enum OrderStatus
    {
        Created=0,Manufacturing=1,Processing=2,Packaging=3,WaitingDelivery=4,Delivered=5,Paused=6,Canceled=7 
    }
}
