using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    internal class Subject
    {
        private List<IEventListener> _subscribers = new List<IEventListener>();

        public void Subscribe(IEventListener subscriber)
        {
            _subscribers.Add(subscriber);
        }
        public void Unsubscribe(IEventListener subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify(int arg)
        {
            foreach (IEventListener subscriber in _subscribers)
            {
                subscriber.Update(arg);
            }
        }
    }
}
