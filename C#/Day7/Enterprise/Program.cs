using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // TASK 1 – PRODUCT PRICE ANALYSIS
        Console.WriteLine("----- PRODUCT PRICE ANALYSIS -----");
        Console.Write("Enter number of products: ");
        int n = int.Parse(Console.ReadLine());

        int[] prices = new int[n];

        for (int i = 0; i < n; i++)
        {
            int p;
            do
            {
                Console.Write($"Enter price for product {i}: ");
                p = int.Parse(Console.ReadLine());
            } while (p <= 0);

            prices[i] = p;
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
            sum += prices[i];

        double avg = sum / (double)n;

        Array.Sort(prices);

        for (int i = 0; i < prices.Length; i++)
            if (prices[i] < avg)
                prices[i] = 0;

        int oldSize = prices.Length;
        Array.Resize(ref prices, oldSize + 5);

        for (int i = oldSize; i < prices.Length; i++)
            prices[i] = (int)avg;

        Console.WriteLine("\nFinal Product Prices:");
        for (int i = 0; i < prices.Length; i++)
            Console.WriteLine($"Index {i} : {prices[i]}");

        // TASK 2 – BRANCH SALES ANALYSIS
        Console.WriteLine("\n----- BRANCH SALES ANALYSIS -----");
        Console.Write("Enter number of branches: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter number of months: ");
        int m = int.Parse(Console.ReadLine());

        int[,] sales = new int[b, m];

        for (int i = 0; i < b; i++)
        {
            Console.WriteLine($"Enter sales for Branch {i}:");
            for (int j = 0; j < m; j++)
            {
                Console.Write($"  Month {j}: ");
                sales[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int high = sales[0, 0];

        for (int i = 0; i < b; i++)
        {
            int total = 0;
            for (int j = 0; j < m; j++)
            {
                total += sales[i, j];
                if (sales[i, j] > high)
                    high = sales[i, j];
            }
            Console.WriteLine($"Total sales of Branch {i}: {total}");
        }

        Console.WriteLine($"Highest monthly sale across all branches: {high}");

        // TASK 3 – JAGGED DATA DISPLAY
        Console.WriteLine("\n----- PERFORMANCE BASED DATA -----");
        for (int i = 0; i < b; i++)
        {
            Console.Write($"Branch {i}: ");
            for (int j = 0; j < m; j++)
                if (sales[i, j] >= avg)
                    Console.Write(sales[i, j] + " ");
            Console.WriteLine();
        }

        // TASK 4 – CUSTOMER TRANSACTION CLEANING
        Console.WriteLine("\n----- CUSTOMER DATA CLEANING -----");
        Console.Write("Enter number of customer IDs: ");
        int c = int.Parse(Console.ReadLine());

        List<int> idList = new List<int>();
        for (int i = 0; i < c; i++)
        {
            Console.Write($"Enter ID {i}: ");
            idList.Add(int.Parse(Console.ReadLine()));
        }

        HashSet<int> cleanSet = new HashSet<int>(idList);

        Console.WriteLine("Cleaned Customer IDs:");
        foreach (int x in cleanSet)
            Console.WriteLine(x);

        Console.WriteLine($"Duplicates removed: {idList.Count - cleanSet.Count}");

        // TASK 5 – FINANCIAL TRANSACTION FILTERING
        Console.WriteLine("\n----- FINANCIAL TRANSACTIONS -----");
        Console.Write("Enter number of transactions: ");
        int t = int.Parse(Console.ReadLine());

        Dictionary<int, double> trans = new Dictionary<int, double>();

        for (int i = 0; i < t; i++)
        {
            Console.Write("Transaction ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Amount: ");
            double amt = double.Parse(Console.ReadLine());

            if (!trans.ContainsKey(id))
                trans.Add(id, amt);
        }

        SortedList<int, double> sl = new SortedList<int, double>();
        foreach (var x in trans)
            if (x.Value >= avg)
                sl.Add(x.Key, x.Value);

        Console.WriteLine("High Value Transactions:");
        foreach (var x in sl)
            Console.WriteLine($"{x.Key} -> {x.Value}");

        // TASK 6 – PROCESS FLOW MANAGEMENT
        Console.WriteLine("\n----- PROCESS FLOW -----");
        Console.Write("Enter number of operations: ");
        int o = int.Parse(Console.ReadLine());

        Queue<string> q = new Queue<string>();
        Stack<string> s = new Stack<string>();

        for (int i = 0; i < o; i++)
        {
            Console.Write($"Operation {i}: ");
            string op = Console.ReadLine();
            q.Enqueue(op);
            s.Push(op);
        }

        Console.WriteLine("Processed Operations:");
        while (q.Count > 0)
            Console.WriteLine(q.Dequeue());

        Console.WriteLine("Undone Operations:");
        for (int i = 0; i < 2 && s.Count > 0; i++)
            Console.WriteLine(s.Pop());

        // TASK 7 – LEGACY DATA DEMO
        Console.WriteLine("\n----- LEGACY DATA DEMO -----");
        Console.Write("Enter number of users: ");
        int u = int.Parse(Console.ReadLine());

        Hashtable ht = new Hashtable();
        ArrayList al = new ArrayList();

        for (int i = 0; i < u; i++)
        {
            Console.Write("Username: ");
            string name = Console.ReadLine();

            Console.Write("Role: ");
            string role = Console.ReadLine();

            ht[name] = role;
            al.Add(name);
            al.Add(role);
        }

        Console.WriteLine("Hashtable Data:");
        foreach (var key in ht.Keys)
            Console.WriteLine(key + " -> " + ht[key]);

        Console.WriteLine("ArrayList Data:");
        foreach (object x in al)
            Console.WriteLine(x);
    }
}
