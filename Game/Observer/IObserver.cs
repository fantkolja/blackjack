using System;

namespace blackjack.Observer
{
    public interface IObserver
    {
        public void Update(ISubject subject);
    }
}