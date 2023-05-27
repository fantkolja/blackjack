using System;

namespace blackjack.Observer
{
	public interface ISubject
	{
		public void Notify();

		public void Attach(IObserver observer);
		public void Detach(IObserver observer);
	}
}