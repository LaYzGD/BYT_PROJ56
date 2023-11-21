namespace DesignPatterns.State
{
    public class State
    {
        protected StateHandler stateHandler { get; private set; }
        protected Client client { get; private set; }
        public State(Client client,StateHandler stateHandler) 
        {
            this.client = client;
            this.stateHandler = stateHandler;
        }

        public virtual void Enter()
        {
            Console.WriteLine($"Enter {GetType()} state");
        }
        public virtual void Handle() 
        {
            Console.WriteLine($"Handle {GetType()} state");
        }
        public virtual void Exit() 
        {
            Console.WriteLine($"Exit {GetType()} state");
        }
    }
}
