namespace blackjack.Game.ObservableFiles;
public class StatService : IObserverService
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
        File.AppendAllText(ObservableConsts.StatFile, $"{value.ToString()}\n");
    }

    public void Subscribe(IObservable<int> provider)
    {
        if (provider != null)
            unsubscriber = provider.Subscribe(this);
    }

    public void Unsubscribe()
    {
        unsubscriber.Dispose();
    }
}
