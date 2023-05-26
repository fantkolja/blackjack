namespace blackjack.Strategy.DrowConfirmation;
public static class RandomNumberGenerator
{
    private static Random random = new Random();

    public static int GenerateRandomNumber()
    {
        return random.Next(13, 19);
    }
}