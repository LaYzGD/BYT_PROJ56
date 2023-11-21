
using DesignPatterns.ObjectPooling;

namespace DesignPatterns.State
{
    public class Client
    {
        public ReadState ReadState { get; private set; }
        public InitialState InitialState { get; private set; }
        public CalculateState CalculateState { get; private set; }
        public ByeState ByeState { get; private set; }
        public StateHandler StateHandler { get; private set; }

        private CardHolder _cardHolder;
        private List<CreditCard> _showedCards;

        public Client() 
        {
            StateHandler = new StateHandler();
            ReadState = new ReadState(this, StateHandler, string.Empty);
            InitialState = new InitialState(this, StateHandler);
            CalculateState = new CalculateState(this, StateHandler);
            ByeState = new ByeState(this, StateHandler);
            _cardHolder = CardHolder.Instance;
            _showedCards = new List<CreditCard>(5);
            StateHandler.Initialize(InitialState);
        }

        public void Update()
        {
            StateHandler.UpdateState();
        }

        public void ShowCard(int amount)
        {
            if (amount == 0)
            {
                return;
            }

            if (amount > _cardHolder.MaxSize)
            {
                amount = _cardHolder.MaxSize;
            }

            for (int i = 0; i < amount; i++)
            {
                var card = _cardHolder.Get();
                Console.WriteLine($"Card: {card.CardNumber} Balance: {card.Balance}");
                _showedCards.Add(card);
            }
        }

        public void HideCards()
        {
            if (_showedCards.Count == 0)
            {
                return;
            }

            foreach (var card in _showedCards)
            {
                _cardHolder.ReturnToPool(card);
            }
            _showedCards.Clear();
        }
    }
}
