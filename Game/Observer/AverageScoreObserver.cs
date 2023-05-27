namespace BlackJack
{
    public class AverageScoreObserver : IObserver
    {
        private FileWriter _fileWriter;

        public AverageScoreObserver()
        {
            this._fileWriter = new FileWriter("AverageScoreLog.txt");
        }
        public void Update(string message)
        {
            _fileWriter.FileWriteLine(message);
        }
    }
}
