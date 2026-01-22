//Collections Example:

// using System;
// using System.Collections.Generic;

// class Program
// {
//     public static void Main(string[] args)
//     {
//         List<int> twoMul = new List<int>();
//         List<int> threeMul = new List<int>();
//         List<int> other = new List<int>();
//         for (int i = 1; i <= 100; i++)
//         {
//             if (i % 2 == 0)
//             {
//                 twoMul.Add(i);
//             }

//             if (i % 3 == 0)
//             {
//                 threeMul.Add(i);
//             }

//             if (i % 2 != 0 && i % 3 != 0)
//             {
//                 other.Add(i);
//             }

//         }
//         Console.Write("Divisble by 2: ");
//         foreach (int i in twoMul)
//         {
//             Console.Write(i + " ");
//         }
//         Console.WriteLine();
//         Console.WriteLine("Divisble by 3: ");
//         foreach (int i in threeMul)
//         {
//             Console.Write(i + " ");
//         }
//         Console.WriteLine();
//         Console.WriteLine("Not divisible by either 2 or 3: ");
//         foreach (int i in other)
//         {
//             Console.Write(i + " ");
//         }
//     }
// }

//Interface Example:
// using System;

// interface IGear
// {
//     void Gear1Test();
//     void Gear2Test();
//     void Gear3Test();
//     void Gear4Test();
//     void Gear5Test();
//     void Gear6Test();
// }

// class MariCar : IGear
// {
//     public void Gear1Test()
//     {
//         Console.WriteLine("Gear1 Tested");
//     }
//     public void Gear2Test()
//     {
//         Console.WriteLine("Gear2 Tested");
//     }
//     public void Gear3Test()
//     {
//         Console.WriteLine("Gear3 Tested");
//     }
//     public void Gear4Test()
//     {
//         Console.WriteLine("Gear4 Tested");
//     }
//     public void Gear5Test()
//     {
//         Console.WriteLine("Gear5 Tested");
//     }
//     public void Gear6Test()
//     {
//         Console.WriteLine("Gear6 Tested");
//     }
// }

// class Program
// {
//     public static void Main(string[] args)
//     {
//         MariCar m = new MariCar();
//         m.Gear1Test();
//         m.Gear2Test();
//         m.Gear3Test();
//         m.Gear4Test();
//         m.Gear5Test();
//         m.Gear6Test();
//     }
// }

//Abstract Example: (Abstract Class + abstract method = Mandatory (equvivalent to Interface))
// using System;

// abstract class Car
// {
//     public abstract void Gear1();
//     public abstract void Gear2();
//     public virtual void ReverseCam()
//     {
//         Console.WriteLine("ReverseCam Implemented");
//     }
//     public virtual void Audio()
//     {
//         Console.WriteLine("Audio feature Implemented");
//     }
// }
// class Nano : Car
// {
//     public override void Gear1()
//     {
//         Console.WriteLine("Nano car Gear1 Implemented");
//     }
//     public override void Gear2()
//     {
//         Console.WriteLine("Nano car Gear1 Implemented");
//     }
// }
// class Program
// {
//     public static void Main(string[] args)
//     {
//         Nano n = new Nano();
//         n.Gear1();
//         n.Gear2();
//         //Optional Methods
//         n.ReverseCam();
//         n.Audio();
//     }
// }

//Delegates:a type-safe object that holds a reference to one or more methods
// using System;

// class Program
// {
//     public delegate int Math(int x, int y);
//     public delegate int Len(string s);

//     public static int Add(int a, int b)
//     {
//         return a + b;
//     }

//     public static int Sub(int c, int d)
//     {
//         return c - d;
//     }

//     public static int StrLen(string s)
//     {
//         return s.Length;
//     }

//     public static void Main(string[] args)
//     {
//         Math mAdd = Add;
//         Math mSub = Sub;
//         Len l = StrLen;

//         Console.WriteLine("Addition: " + mAdd(3, 2));
//         Console.WriteLine("Subtraction: " + mSub(10, 5));
//         Console.WriteLine("StrLen: " + l("Srikaran"));
//     }
// }

//Extension Methods: If we want to add new methods, into the original class without creating a new class, but class and method must be static.  
//Use of finally block: When we want to execute code, irrespective of Exception.
//String vs StringBuilder: Memory contengency is saved using Sb, because when we use string it creates everytime new memory, but sb operates on only one memory spcae.

