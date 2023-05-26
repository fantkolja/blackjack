namespace BlackJack
{
    //зупиняється коли має 13 очок
    class CarefulStrategy : IStrategy
    {
        public static int PointsForCareful = 13;

        public bool ConfirmNextDraw(int currentPoints){
            return (currentPoints < PointsForCareful);
        }
    }
}