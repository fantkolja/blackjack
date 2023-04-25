using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blackjack.Game.Observer;

namespace blackjack
{
    public class PointsSubject : IPointsSubject
    {
        private List<IPointsObserver> _observers = new List<IPointsObserver>();

        public void RegisterObserver(IPointsObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IPointsObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(int points)
        {
            foreach (var observer in _observers)
            {
                observer.Update(points);
            }
        }
    }
}
