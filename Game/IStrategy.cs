namespace BlackJack
{
    interface IStrategy
    {
        bool ConfirmNextDraw(int currentPoints);
    }
}