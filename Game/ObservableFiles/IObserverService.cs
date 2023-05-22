namespace blackjack.Game.ObservableFiles;
public interface IObserverService : IObserver<int>
{
    void Unsubscribe();
}
