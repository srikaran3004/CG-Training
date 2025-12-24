using System;
using System.Collections.Generic;

public struct PriceSnapshot
{
    public string StockSymbol;
    public double StockPrice;
}

public abstract class Trade
{
    public int TradeId { get; set; }
    public string Symbol { get; set; }
    public int Quantity { get; set; }

    public abstract double CalculateTradeValue();

    public override string ToString()
    {
        return $"TradeId: {TradeId}, Symbol: {Symbol}, Qty: {Quantity}";
    }
}

public class EquityTrade : Trade
{
    public double? MarketPrice { get; set; }

    public override double CalculateTradeValue()
    {
        return Quantity * (MarketPrice ?? 0);
    }
}

public class TradeRepository<T> where T : Trade
{
    private List<T> trades = new List<T>();

    public void AddTrade(T trade)
    {
        trades.Add(trade);
        TradeAnalytics.TotalTrades++;
        Console.WriteLine("Trade added successfully");
    }

    public IEnumerable<T> GetTrades()
    {
        return trades;
    }
}

public static class TradeAnalytics
{
    public static int TotalTrades;

    public static void DisplayAnalytics()
    {
        Console.WriteLine($"Total Trades Executed: {TotalTrades}");
    }
}

public static class FinancialExtensions
{
    public static double Brokerage(this double amount)
    {
        return amount * 0.001;
    }

    public static double GST(this double amount)
    {
        return amount * 0.18;
    }
}

public static class TradeProcessor
{
    public static void ProcessTrade(Trade trade)
    {
        if (trade is EquityTrade)
        {
            Console.WriteLine("Processing Equity Trade");
        }
    }
}
