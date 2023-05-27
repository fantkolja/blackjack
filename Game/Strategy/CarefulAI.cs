namespace BlackJack
{
    class CarefulAI : AI
    {
        public override bool ConfirmNextDraw()
        {
            return GetCurrentScore() < 13;
        }
    }
}
