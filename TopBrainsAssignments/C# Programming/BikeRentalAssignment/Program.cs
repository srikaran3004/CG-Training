using System;
using System.Collections.Generic;

public class Bike
{
    public string Model { get; set; }
    public int PricePerDay { get; set; }
    public string Brand { get; set; }
}

public class BikeUtility
{
    public void AddBikeDetails(string m, string b, int p)
    {
        int k = Program.bikeDetails.Count + 1;
        Bike x = new Bike();
        x.Model = m;
        x.Brand = b;
        x.PricePerDay = p;
        Program.bikeDetails.Add(k, x);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> g = new SortedDictionary<string, List<Bike>>();

        foreach (Bike x in Program.bikeDetails.Values)
        {
            if (!g.ContainsKey(x.Brand))
            {
                g[x.Brand] = new List<Bike>();
            }
            g[x.Brand].Add(x);
        }

        return g;
    }
}

public class Program
{
    public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

    public static void Main(string[] args)
    {
        BikeUtility u = new BikeUtility();

        while (true)
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice ");
            int c = int.Parse(Console.ReadLine());

            if (c == 1)
            {
                Console.WriteLine();
                Console.Write("Enter the model: ");
                string m = Console.ReadLine();
                Console.Write("Enter the brand: ");
                string b = Console.ReadLine();
                Console.Write("Enter the price per day: ");
                int p = int.Parse(Console.ReadLine());

                u.AddBikeDetails(m, b, p);
                Console.WriteLine();
                Console.WriteLine("Bike details added successfully");
                Console.WriteLine();
            }
            else if (c == 2)
            {
                Console.WriteLine();
                SortedDictionary<string, List<Bike>> g = u.GroupBikesByBrand();

                foreach (var x in g)
                {
                    foreach (var y in x.Value)
                    {
                        Console.WriteLine(x.Key + " " + y.Model);
                    }
                }
                Console.WriteLine();
            }
            else if (c == 3)
            {
                break;
            }
        }
    }
}
