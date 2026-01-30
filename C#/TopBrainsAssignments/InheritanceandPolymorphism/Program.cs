using System;
using System.Collections.Generic;

abstract class E
{
    public abstract decimal P();
}

class H : E
{
    decimal r, h;
    public H(decimal a, decimal b) { r = a; h = b; }
    public override decimal P() { return r * h; }
}

class S : E
{
    decimal s;
    public S(decimal a) { s = a; }
    public override decimal P() { return s; }
}

class C : E
{
    decimal c, b;
    public C(decimal x, decimal y) { c = x; b = y; }
    public override decimal P() { return b + c; }
}

class Program
{
    static decimal T(string[] e)
    {
        List<E> l = new List<E>();

        foreach (string x in e)
        {
            string[] p = x.Split(' ');
            if (p[0] == "H")
                l.Add(new H(decimal.Parse(p[1]), decimal.Parse(p[2])));
            else if (p[0] == "S")
                l.Add(new S(decimal.Parse(p[1])));
            else if (p[0] == "C")
                l.Add(new C(decimal.Parse(p[1]), decimal.Parse(p[2])));
        }

        decimal t = 0;
        foreach (E i in l)
            t += i.P();

        return Math.Round(t, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] e = new string[n];
        for (int i = 0; i < n; i++)
            e[i] = Console.ReadLine();

        Console.WriteLine(T(e));
    }
}
