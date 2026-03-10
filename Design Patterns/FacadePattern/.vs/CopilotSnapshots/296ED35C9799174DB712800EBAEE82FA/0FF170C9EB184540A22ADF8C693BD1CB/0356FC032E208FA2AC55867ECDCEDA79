using FacadePattern;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Child: Mum, I want an ice cream!");

        IceCreamFacade mother = new IceCreamFacade();

        string iceCream = mother.GetIceCream();

        Console.WriteLine("Mother gives: " + iceCream);

        Console.ReadLine();
    }
}