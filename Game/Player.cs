namespace BlackJack
{
    class Player
    {
        public string Name { get; }
        public List<Card> DrawnCards { get; } = new List<Card>();
        public int Money { get; private set; }

        public Player(string name, int initialMoney)
        {
            this.Name = name;
            this.Money = initialMoney;
        }

        public bool ConfirmNextDraw()
        {
            return InputHandler.Confirm("Do you want to draw next card?");
        }

        public Card DrawCard(CardsDeck cardsDeck)
        {
            Card card = cardsDeck.Draw();
            this.DrawnCards.Add(card);
            Logger.ShowDrawnCard(card, PointsCounter.CountSum(this.DrawnCards));
            return card;
        }

        public void PlaceBet(int amount)
        {
            if (amount > this.Money)
            {
                throw new Exception("Cannot place a bet higher than available money");
            }
            this.Money -= amount;
        }

        public void WinBet(int amount)
        {
            this.Money += amount;
        }
    }
}