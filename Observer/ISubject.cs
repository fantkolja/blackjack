using System;

namespace blackjack.Observer
{
	public interface ISubject
	{
		public void Notify();
		
		public void Subscribe(IObserver observer);
		public void UnSubdcribe(IObserver observer);
	}
}
