using DesignPatterns.State;
public class Program 
{
    private static void Main(string[] args)
    {
        Client client = new Client();

        while (client.StateHandler.CurrentState != client.ByeState) 
        {
            client.Update();
        }
    }
}