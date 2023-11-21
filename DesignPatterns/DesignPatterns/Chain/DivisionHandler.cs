namespace DesignPatterns.Chain
{
    public class DivisionHandler : Handler
    {
        public override void HandleRequest(double a, double b, char o)
        {
            if (o == '/')
            {
                if (b == 0)
                {
                    Error?.Invoke("ERROR");
                    return;
                }

                Result?.Invoke(a / b);

                return;
            }
        }
    }
}
