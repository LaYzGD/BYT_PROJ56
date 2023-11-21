namespace DesignPatterns.Chain
{
    public abstract class Handler
    {
        protected Handler successor;
        public static Action<double> Result { get; set; }
        public static Action<string> Error { get; set; }

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(double a, double b, char _operator);
    }
}
