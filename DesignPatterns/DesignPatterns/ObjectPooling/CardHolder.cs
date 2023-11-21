namespace DesignPatterns.ObjectPooling
{
    public sealed class CardHolder : Pooler<CreditCard>
    {
        public int MaxSize => poolMaxSize;
        private static CardHolder _instance = null;
        public static CardHolder Instance 
        {
            get 
            {
                if(_instance == null)
                {
                    _instance = new CardHolder(5);
                }
                return _instance;
            }
        }
        public CardHolder(int poolMaxSize) : base(poolMaxSize)
        {
        }

        protected override void CreateNewObject()
        {
            try
            {
                Console.WriteLine("Enter new card number:");
                string number = Console.ReadLine();
                Console.WriteLine("Enter balance:");
                double balance = double.Parse(Console.ReadLine());
                CreditCard card = new CreditCard(number, balance);
                pool.Enqueue(card);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
