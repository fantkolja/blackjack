namespace blackjack.Game.ObservableFiles;
public class Unsubscriber : IDisposable
{
    private List<IObserver<int>> _observers;
    private IObserver<int> _observer;

    public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
    {
        _observers = observers;
        _observer = observer;
    }

    public void Dispose()
    {
        if (_observer != null && _observers.Contains(_observer))
            _observers.Remove(_observer);
    }
}