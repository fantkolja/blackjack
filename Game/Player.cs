namespace BlackJack
{
    class Player
    {
        public string Name { get; }

        public List<Card> DrawnCards { get; } = new List<Card>();

        public IStrategy strategy;

        public Player(string name, IStrategy strategy)
        {
            this.Name = name;
            this.strategy = strategy;
        }
        public bool ConfirmNextDraw(int currentPoints)
        {
            return strategy.ConfirmNextDraw(currentPoints);
        }
        
        
        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw(); //верхня карта з колоди
            this.DrawnCards.Add(card);  //верхня карта в колоді - у список витягнутих карт

            //показує карту і її кількість балів:передається карта і її кількість балів)
            Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards)); //

            return card;
        }
    }
}