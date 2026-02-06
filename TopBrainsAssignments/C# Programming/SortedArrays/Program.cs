using System;
using System.Linq;

class Program
{
    static T[] M<T>(T[] a, T[] b) where T : IComparable<T>
    {
        T[] m = new T[a.Length + b.Length];
        int i = 0, j = 0, k = 0;

        while (i < a.Length && j < b.Length)
            m[k++] = a[i].CompareTo(b[j]) <= 0 ? a[i++] : b[j++];

        while (i < a.Length)
            m[k++] = a[i++];

        while (j < b.Length)
            m[k++] = b[j++];

        return m;
    }

    static void Main()
    {
        T[] Read<T>() where T : IComparable<T>
        {
            return Console.ReadLine().Split().Select(x => (T)Convert.ChangeType(x, typeof(T))).ToArray();
        }

        var a = Read<int>();
        var b = Read<int>();
        var m = M(a, b);

        Console.WriteLine(string.Join(" ", m));
    }
}
