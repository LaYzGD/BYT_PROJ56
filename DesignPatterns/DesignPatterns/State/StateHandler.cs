namespace DesignPatterns.State
{
    public class StateHandler
    {
        public State CurrentState { get; private set; }

        public void Initialize(State initialState)
        {
            CurrentState = initialState;
            CurrentState.Enter();
        }

        public void UpdateState()
        {
            CurrentState.Handle();
        }

        public void SetState(State newState)
        {
            if (newState == CurrentState)
            {
                return;
            }

            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
        
    }
}
