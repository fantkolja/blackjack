namespace blackjack.Game.ObservableFiles;
public class PereborService : IObserverService
{
    private IDisposable unsubscriber;
    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(int value)
    {
        File.AppendAllText(ObservableConsts.PereborFile, $"{value.ToString()}\n");
    }
    public virtual void Subscribe(IObservable<int> provider)
    {
        if (provider != null)
            unsubscriber = provider.Subscribe(this);
    }

    public virtual void Unsubscribe()
    {
        unsubscriber.Dispose();
    }
}
