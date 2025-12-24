using System;

class Program
{
    static void Main()
    {
        // Task 1
        PriceSnapshot ss = new PriceSnapshot
        {
            StockSymbol = "AAPL",
            StockPrice = 150.50
        };

        Console.WriteLine($"Stock Symbol: {ss.StockSymbol}");
        Console.WriteLine($"Stock Price: {ss.StockPrice}");

        // Task 4
        TradeRepository<EquityTrade> repo = new TradeRepository<EquityTrade>();

        // Task 3
        EquityTrade t1 = new EquityTrade
        {
            TradeId = 1,
            Symbol = "AAPL",
            Quantity = 100,
            MarketPrice = 150.50
        };

        // Task 3
        EquityTrade t2 = new EquityTrade
        {
            TradeId = 2,
            Symbol = "MSFT",
            Quantity = 50,
            MarketPrice = null
        };

        repo.AddTrade(t1);
        repo.AddTrade(t2);

        // Task 7
        foreach (var trade in repo.GetTrades())
        {
            TradeProcessor.ProcessTrade(trade);

            // Task 6
            double value = trade.CalculateTradeValue();
            double brokerage = value.Brokerage();
            double gst = brokerage.GST();

            // Task 2
            Console.WriteLine($"Trade Value: {value}");
            Console.WriteLine($"Brokerage: {brokerage}");
            Console.WriteLine($"GST: {gst}");
            Console.WriteLine(trade);
            Console.WriteLine();
        }

        // Task 8
        object boxedCount = TradeAnalytics.TotalTrades;
        int unboxedCount = (int)boxedCount;

        Console.WriteLine($"Boxed Trade Count: {boxedCount}");
        Console.WriteLine($"Unboxed Trade Count: {unboxedCount}");

        // Task 5
        TradeAnalytics.DisplayAnalytics();
    }
}
