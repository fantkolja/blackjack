using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Observer
{
    public enum GameEvent
    {
        PointsChanged,
        GameEnd
    }
    public class EventManager : ISubject
    {
        private List<KeyValuePair<GameEvent, IObserver>> _subscriptions = new();
        public void Notify(GameEvent type, object data)
        {
            var triggered = _subscriptions.Where(pair => pair.Key == type);
            foreach (var sub in triggered)
            {
                sub.Value.Update(data);
            }
        }

        public void Subscribe(GameEvent type, IObserver observer)
        {
            _subscriptions.Add(new KeyValuePair<GameEvent, IObserver>(type, observer));
        }

        public void Unsubscribe(GameEvent type, IObserver observer)
        {
            _subscriptions.RemoveAll(pair => pair.Key == type && pair.Value == observer);
        }
    }
}
