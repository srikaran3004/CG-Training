using System;
using System.Text;
class Stringbuilder
{
    public static void Main()
    {
        // string s = "Hello";
        // s = char.ToLower(s[0]) + s.Substring(1);
        // Console.WriteLine(s);
        // StringBuilder sb=new StringBuilder();
        // sb.Append("Hello");
        // sb.Append(" ");
        // sb.Append("World");
        // sb.Append("Text");
        // sb.AppendLine();
        // sb.Insert(0,"Start");
        // sb.Remove(0,5);
        // sb.Replace("Text","End");
        // sb.Clear();
        // Console.WriteLine(sb.GetType());
        // Console.WriteLine(sb.ToString().GetType());
        // Console.WriteLine(sb.ToString());
        // Console.WriteLine(GC.GetTotalMemory(false));
        // StringBuilder sb = new StringBuilder();
        // for (int i = 0; i < 10000; i++)
        // {
        //     sb.Append(i);
        // }
        // string res = sb.ToString();
        // Console.WriteLine(GC.GetTotalMemory(false));
        // string a = "Hello";
        // string b = "Hello";
        // // Console.WriteLine(object.ReferenceEquals(a, b));
        // unsafe
        // {
        //     fixed (char* pa = a)
        //     fixed (char* pb = b)
        //     {
        //         Console.WriteLine($"a addr: {(IntPtr)pa}");
        //         Console.WriteLine($"A's Hashcode: {a.GetHashCode()}");
        //         Console.WriteLine($"b addr: {(IntPtr)pb}");
        //         Console.WriteLine($"B's Hashcode: {b.GetHashCode()}");
        //         Console.WriteLine(Object.ReferenceEquals(a, b));
        //     }
        // }
        // StringBuilder sb1 = new("Hello");
        // StringBuilder sb2 = new("Hello");
        // Console.WriteLine(sb1.Equals(sb2));
        // Console.WriteLine(Object.ReferenceEquals(sb1, sb2));
        // StringBuilder sb3 = sb2;
        // Console.WriteLine(sb3.Equals(sb2));
        // Console.WriteLine(Object.ReferenceEquals(sb3, sb2));
        // Console.WriteLine(sb1 == sb2);
        /**
        In normal strings when we use == or .Equals it checks for values,
        When we use StringBuilder then it checks for references and not values, if we want to check values in StringBuilder we convert it into string using .ToString() and check.
        **/
        // DateTime now = DateTime.Now;
        // DateTime today = DateTime.Today;
        // DateTime utcNow = DateTime.UtcNow;
        // Console.WriteLine(now);
        // Console.WriteLine(today);
        // Console.WriteLine(utcNow);
    }
}