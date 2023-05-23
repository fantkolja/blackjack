using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    interface ISubject
    {
       public void Subscribe(IObserver observer);
       public void Unsubscribe(IObserver observer);
       public void Notify(object data);

    }
}
