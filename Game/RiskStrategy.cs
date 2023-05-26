namespace BlackJack
{
    //зупиняється коли має 19 очок
    class RiskStrategy : IStrategy
    {
        public static int PointsForRisk = 19;

        public bool ConfirmNextDraw(int currentPoints){
            return (currentPoints < PointsForRisk);
        
        }
    }
}