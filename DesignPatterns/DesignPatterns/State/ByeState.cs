
namespace DesignPatterns.State
{
    public class ByeState : State
    {
        public ByeState(Client client, StateHandler stateHandler) : base(client, stateHandler)
        {
        }

        public override void Enter()
        {
            base.Enter();
            Console.WriteLine("Bye...");
        }
    }
}
