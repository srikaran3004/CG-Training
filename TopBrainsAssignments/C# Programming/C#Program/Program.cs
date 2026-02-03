using System;
using System.Text;
class Program
{
    public static void Main(String[] args)
    {
        Console.WriteLine("Enter first string1: ");
        string s1 = Console.ReadLine().ToLower();
        Console.WriteLine("Enter second string2:  ");
        string s2 = Console.ReadLine().ToLower();
        StringBuilder s = new StringBuilder(s1);
        for (int i = 0; i < s2.Length; i++)
        {
            if (s2[i] != 'a' && s2[i] != 'e' && s2[i] != 'i' && s2[i] != 'o' && s2[i] != 'u')
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (s2[i] == s[j])
                    {
                        s.Remove(j, 1);
                        j--;
                    }
                }
            }
        }
        StringBuilder res = new StringBuilder();
        if (s.Length > 0)
        {
            res.Append(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] != s[i - 1])
                {
                    res.Append(s[i]);
                }
            }
        }

        Console.WriteLine(res.ToString());
    }
}