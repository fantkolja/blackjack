namespace BlackJack
{
    
    class PersonStrategy : IStrategy
    {
        public bool ConfirmNextDraw(int currentPoints){
            return InputHandler.Confirm("Do you want to draw next card?");       
        }
    }
}