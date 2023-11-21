using DesignPatterns.Chain;

namespace DesignPatterns.State
{
    public class CalculateState : State
    {
        private Calculator _calculator;
        public CalculateState(Client client, StateHandler stateHandler) : base(client, stateHandler)
        {
            _calculator = new Calculator();
        }

        public override void Enter()
        {
            base.Enter();
            Handler.Result += PrintResult;
            Handler.Error += PrintError;
            Console.WriteLine("Operators: + - * /");
        }

        private void PrintResult(double result)
        {
            Console.WriteLine(result);
            stateHandler.SetState(client.InitialState);
        }

        private void PrintError(string error)
        {
            Console.WriteLine(error);
            stateHandler.SetState(client.InitialState);
        }

        public override void Handle()
        {
            base.Handle();
            Console.WriteLine("What do I need to calculate?");

            try
            {
                Console.WriteLine("a: ");
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine("b: ");
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine("operator: ");
                char o = char.Parse(Console.ReadLine());

                _calculator.Calculate(a, b, o);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("ERROR");   
            }
        }

        public override void Exit()
        {
            base.Exit();
            Handler.Result -= PrintResult;
            Handler.Error -= PrintError;
        }
    }
}
