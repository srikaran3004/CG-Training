using System;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the String: ");
        string s = Console.ReadLine().ToLower();
        StringBuilder sb = new StringBuilder(s);

        for (int i = 1; i < sb.Length; i++)
        {
            if (sb[i] == sb[i - 1])
            {
                sb.Remove(i, 1);
                i--;
            }
        }

        for (int i = 1; i < sb.Length; i++)
        {
            if (sb[i] == ' ' && sb[i - 1] == ' ')
            {
                sb.Remove(i, 1);
                i--;
            }
        }
        if (sb.Length > 0 && sb[0] == ' ')
            sb.Remove(0, 1);
        if (sb.Length > 0 && sb[sb.Length - 1] == ' ')
            sb.Remove(sb.Length - 1, 1);
        if (sb.Length > 0)
        {
            sb[0] = char.ToUpper(sb[0]);
            for (int i = 1; i < sb.Length; i++)
            {
                if (sb[i - 1] == ' ')
                    sb[i] = char.ToUpper(sb[i]);
                else
                    sb[i] = char.ToLower(sb[i]);
            }
        }

        Console.WriteLine(sb.ToString());
    }
}
