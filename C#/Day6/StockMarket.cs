using System;
using System.Collections.Generic;

/**
struct StockPrice
{
    public string? StockSymbol;
    public double Price;
}
class Trade
{
    public int TradeID;
    public string StockSymbol = "";
    public double Quantity;
}
class Portfolio
{
    public string? Name;

    public override bool Equals(object obj) //Here we are overriding Equals method that is present in System.Objects.
    {
        Portfolio p = obj as Portfolio;
        return p != null && p.Name == Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
class EquityTrade : Trade { }

class Calculator
{
    public T Calculate<T>(T a, T b)
    {
        return (dynamic)a+b;
    }
}
class Account
{
    public decimal? Balance{get;set;}
}
**/
