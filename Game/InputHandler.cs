namespace BlackJack
{
  static class InputHandler
  {
    private static char _requestConfirm(char firstCondition, char secondCondition)
    {
      char? userInput = null;
      do
      {
        if (userInput != null)
        {
          Console.Write("\b");
        }
        userInput = Console.ReadKey().KeyChar;
      }
      while (userInput != firstCondition && userInput != secondCondition);

      Logger.Log("");
      Logger.Log("");
      return (char) userInput;
    }
    public static bool Confirm(string message)
    {
      Logger.Log(message);
      Logger.Log("Please type y/N: ");
      char userInput = InputHandler._requestConfirm('y','N');
      return userInput == 'y';
    }

    public static bool ConfirmPlayingWithBot()
    {
          Console.WriteLine("Choose mode:\n1.With Player\n2.With Bot");
         char userInput = InputHandler._requestConfirm('1', '2');
         return userInput == '2';
    }
    public static string RequestAnswer(string messsage)
    {
      Logger.Log(messsage);
      string? answer = null;
      do
      {
        answer = Console.ReadLine();
      } while(answer == null);
      return answer;
    }

    public static string RequestAnswer(string messsage, string defaultAnswer)
    {
      string answer = InputHandler.RequestAnswer(messsage);
      if (String.IsNullOrEmpty(answer))
      {
        answer = defaultAnswer;
        Logger.Log(defaultAnswer);
      }
      Logger.Log("");
      return answer;
    }
  }
}