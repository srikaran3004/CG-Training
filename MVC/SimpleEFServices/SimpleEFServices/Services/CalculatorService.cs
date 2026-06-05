namespace SimpleEFServices.Services
{
    public class CalculatorService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Divide(int a, int b) {
             if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
}
