namespace DesignPatterns.ObjectPooling
{
    public class CreditCard
    {
        public string CardNumber { get; private set; }
        public double Balance { get; private set; }

        public CreditCard(string cardNumber, double balance)
        {
            CardNumber = cardNumber;
            Balance = balance;
        }
    }
}
