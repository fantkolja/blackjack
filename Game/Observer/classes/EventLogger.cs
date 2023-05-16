using BlackJack.Interfaces;

namespace BlackJack.Classes
{
    public class EventLogger : IObserver
    {
        private readonly string _filePath;

        public EventLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void Update(string message)
        {
            using (var writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
