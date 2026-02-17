using System;

abstract class Consultant
{
    public string Id;

    public Consultant(string id)
    {
        if (id.Length != 6 || !id.StartsWith("DR") || !int.TryParse(id.Substring(2), out _))
            throw new Exception("Invalid doctor id");
        Id = id;
    }

    public abstract double Gross();

    public virtual double TDS(double g)
    {
        return g <= 5000 ? g * 0.05 : g * 0.15;
    }

    public double Net()
    {
        double g = Gross();
        return g - TDS(g);
    }
}

class InHouse : Consultant
{
    double stipend;

    public InHouse(string id, double s) : base(id)
    {
        stipend = s;
    }

    public override double Gross()
    {
        return stipend + 2000 + 1000;
    }
}

class Visiting : Consultant
{
    int visits;
    double rate;

    public Visiting(string id, int v, double r) : base(id)
    {
        visits = v;
        rate = r;
    }

    public override double Gross()
    {
        return visits * rate;
    }

    public override double TDS(double g)
    {
        return g * 0.10;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Consultant a = new InHouse("DR2001", 10000);
            Console.WriteLine(a.Gross());
            Console.WriteLine(a.Net());

            Consultant b = new Visiting("DR8005", 10, 600);
            Console.WriteLine(b.Gross());
            Console.WriteLine(b.Net());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
