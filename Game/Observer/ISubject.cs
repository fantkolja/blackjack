using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public interface ISubject
    {
        public void Subscribe(GameEvent type, IObserver observer);
        public void Unsubscribe(GameEvent type, IObserver observer);
        public void Notify(GameEvent type, object data);
    }
}
