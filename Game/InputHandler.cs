namespace BlackJack
{
  static class InputHandler
  {
    private static char _requestConfirm()
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
      while (userInput != 'y' && userInput != 'N');

      Logger.Log("");
      Logger.Log("");
      return (char) userInput;
    }

    public static bool Confirm(string message)
    {
      Logger.Log(message);
      Logger.Log("Please type y/N: ");
      char userInput = InputHandler._requestConfirm();
      return userInput == 'y';
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

    public static int? IntAnswer(string messsage)
    {
      Logger.Log(messsage);
      int? answer = null;
      do
      {
        answer = Convert.ToInt32(Console.ReadLine());
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