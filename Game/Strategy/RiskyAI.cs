namespace BlackJack
{
    class RiskyAI : AI
    {
        public override bool ConfirmNextDraw()
        {
            return GetCurrentScore() < 19;
        }
    }
}
