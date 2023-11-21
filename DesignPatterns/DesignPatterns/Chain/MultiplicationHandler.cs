namespace DesignPatterns.Chain
{
    public class MultiplicationHandler : Handler
    {
        public override void HandleRequest(double a, double b, char o)
        {
            if (o == '*')
            {
                Result?.Invoke(a * b);
                return;
            }

            successor.HandleRequest(a, b, o);
        }
    }
}
