
namespace DesignPatterns.State
{
    public class InitialState : State
    {
        public InitialState(Client client, StateHandler stateHandler) : base(client, stateHandler)
        {
        }

        public override void Handle()
        {
            base.Handle();
            client.HideCards();
            Console.WriteLine("What do you want me to do?");
            Console.WriteLine($"{(int)Inputs.Read}.Read, {(int)Inputs.Calculate}.Calculate, {(int)Inputs.CreditCard}.Show Credit Cards, 3-9.Bye");
            string? input = Console.ReadLine();
            if (input == null || input == string.Empty) 
            {
                Console.WriteLine("I don't get it...");
                return;
            }

            try
            {
                int intInput = int.Parse(input);

                if (intInput == (int)Inputs.Read)
                {
                    stateHandler.SetState(client.ReadState);
                }
                else if (intInput == (int)Inputs.Calculate)
                {
                    stateHandler.SetState(client.CalculateState);
                }
                else if (intInput == (int)Inputs.CreditCard)
                {
                    Console.WriteLine("How many?");
                    int amount = int.Parse(Console.ReadLine());
                    client.ShowCard(amount);
                }
                else 
                {
                    stateHandler.SetState(client.ByeState);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
    }
}
