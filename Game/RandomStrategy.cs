namespace BlackJack
{
   
    class RandomStrategy : IStrategy
    {
        public int PointsForRandom {get ;}

        
        public RandomStrategy()
        {
            var rand = new Random();
            PointsForRandom = rand.Next(1, 19);
        }

        public bool ConfirmNextDraw(int currentPoints)
        {
            return (currentPoints < PointsForRandom);
        }

    }
}