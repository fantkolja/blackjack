using BlackJack;

namespace blackjack.Game
{
    public class Bot : Player
    {
        private IPlayingStyle _playingStyle;

        public Bot(string name, IPlayingStyle playingStyle) : base(name)
        {
            _playingStyle = playingStyle;
        }

        public override bool ConfirmNextDraw()
        {
            return _playingStyle.ShouldDrawNextCard(this.DrawnCards);
        }
    }


}
