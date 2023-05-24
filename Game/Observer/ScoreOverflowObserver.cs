using blackjack.Game.FileClasses;

namespace blackjack.Game.Observer
{
    public class ScoreOverflowObserver : IObserver
    {
        private FileWriter _fileWriter;

        public ScoreOverflowObserver()
        {
            this._fileWriter = new FileWriter("score-overflow-history.txt");
        }
        public void Update(string message)
        {
            _fileWriter.WriteToFile(message);
        }
    }
}
