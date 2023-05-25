using blackjack.Game.FileClasses;

namespace blackjack.Game.Observer
{
    public class StatisticsObserver : IObserver
    {
        private FileWriter _fileWriter;

        public StatisticsObserver()
        {
            this._fileWriter = new FileWriter("statistics.txt");
        }
        public void Update(string message)
        {
            _fileWriter.WriteToFile(message);
        }
    }
}
