
namespace DesignPatterns.Chain
{
    public class Calculator
    {
        private AdditionHandler _additionHandler;
        private SubstractionHandler _substractionHandler;
        private MultiplicationHandler _multiplicationHandler;
        private DivisionHandler _divisionHandler;
        public Calculator() 
        {
            _additionHandler = new AdditionHandler();
            _substractionHandler = new SubstractionHandler();
            _multiplicationHandler = new MultiplicationHandler();
            _divisionHandler = new DivisionHandler();

            _additionHandler.SetSuccessor(_substractionHandler);
            _substractionHandler.SetSuccessor(_multiplicationHandler);
            _multiplicationHandler.SetSuccessor(_divisionHandler);
        }

        public void Calculate(double a, double b, char _opperator)
        {
            _additionHandler.HandleRequest(a, b, _opperator);
        }
    }
}
