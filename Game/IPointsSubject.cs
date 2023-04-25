using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public interface IPointsSubject
    {
        void RegisterObserver(IPointsObserver observer);
        void RemoveObserver(IPointsObserver observer);
        void NotifyObservers(int points);
    }
}
