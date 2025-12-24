using System;
class Program
{
    public static void Main()
    {
        /**
        //For struct, the copy of variable is being created when an new obj is being created.
        StockPrice s1 = new StockPrice { StockSymbol = "TCS", Price = 1500 };
        StockPrice s2 = s1;
        s2.Price = 1700;
        Console.WriteLine(s1.Price);
        Console.WriteLine(s2.Price);
        Trade t1 = new Trade { Quantity = 100, StockSymbol = "AAPL", TradeID = 101 };
        //For class, the ref of variable is being created when an new obj is being created, which basically changes the value of original obj.
        Trade t2 = t1;
        t2.TradeID = 102;
        t2.Quantity = 200;
        t2.StockSymbol = "CG";
        Console.WriteLine(t1.TradeID);
        Console.WriteLine(t2.TradeID);
        Console.WriteLine(t1.StockSymbol);
        Console.WriteLine(t2.StockSymbol);
        Portfolio p1 = new Portfolio { Name = "Growth" };
        Portfolio p2 = new Portfolio { Name = "Growth" };
        Console.WriteLine(p1.Equals(p2)); //Equals will check for only values of two objects.
        Console.WriteLine(p1 == p2); //here == equals checks their memory reference.
        Console.WriteLine(p1.GetHashCode());
        Console.WriteLine(p2.GetHashCode());// When Equals function returns True, the Hash value is Same, vice versa.( This basically helps us to store the Value in same memory location if Hash value is same and Different if hash values are different )
        Trade t = new EquityTrade();
        Console.WriteLine(t.GetType()); //Here it will return the byreference of the Object.    
        Calculator cal = new Calculator();
        int res=cal.Calculate(10,20);
        Console.WriteLine(res);
        decimal? livePrice = null;
        livePrice = null;
        decimal finalPrice = livePrice ?? 100.50m;
        Account acc = null;
        decimal? accBalance = acc?.Balance;
        Console.WriteLine("Live Stock Price (after fallback): " + finalPrice);
        Console.WriteLine("Account Balance (safe access): " + (accBalance ?? 0m));
        **/
    }
}