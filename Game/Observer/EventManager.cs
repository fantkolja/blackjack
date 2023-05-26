using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public class EventManager : ISubject
    {
        private Dictionary<GameEvent, List<IObserver>> observers = new Dictionary<GameEvent, List<IObserver>>();
        public void Notify(GameEvent e, object data)
        {
            foreach (IObserver observer in observers[e])
            {
                observer.Update(data);
            }
        }

        public void Subscribe(GameEvent e, IObserver observer)
        {
            if (observers.ContainsKey(e))
            {
                observers[e].Add(observer);
            }
            else
            {
                observers.Add(e, new List<IObserver>() { observer });
            }
        }

        public void Unsubscribe(GameEvent e, IObserver observer)
        {
            if (observers.ContainsKey(e))
            {
                observers[e].Remove(observer);
            }
        }
    }
}
