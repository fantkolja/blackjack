using System;

namespace blackjack.Observer
{
	public abstract class SubjectBase : ISubject
	{
		protected List<IObserver> _subs;
		
		public SubjectBase()
		{
			_subs = new List<IObserver>();
		}

        public void Notify()
        {
            foreach(var item in _subs)
			{
				item.Update(this);
			}
        }

        public void Attach(IObserver observer)
        {
            _subs.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _subs.Remove(observer);
        }
    }
}