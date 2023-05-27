namespace BlackJack
{
    public class ScoreLimitReachObserver : IObserver
    {
        private FileWriter _fileWriter;

        public ScoreLimitReachObserver()
        {
            this._fileWriter = new FileWriter("ScoreLimitReachLog.txt");
        }

        public void Update(string message)
        {
            _fileWriter.FileWriteLine(message);
        }
    }
}
