using System;
using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        //List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        ////Deffered execution
        //var deferredQuery = numbers.Where(n => n > 2);
        //Console.WriteLine("Deferred Query:");
        //foreach (var num in deferredQuery)
        //{
        //    Console.WriteLine(num);
        //}
        //List<int> nums = new List<int> { 10, 34, 2, 21, 4, 53, 45, 35, 456, 4, 344, 12, 32, 35, 3, 52, 23, 12, 4 };
        //int count = nums.Count();
        //List<int> nums1 = nums.Skip(nums.Count / 2).ToList();
        //Console.WriteLine("Second half of the list:");
        //foreach (var num in nums1)
        //{
        //    Console.WriteLine(num);
        //}

        //Extract all integers from the ArrayList and print them
        //ArrayList arrayList = new ArrayList
        //{
        //    1,"Mari","MCA",200000
        //};
        //arrayList.OfType<int>().ToList().ForEach(Console.WriteLine);

        ////Using IEnum
        //IEnumerable<int> integers = arrayList.OfType<int>();
        //foreach (var i in integers)
        //{
        //    Console.WriteLine(i);
        //}

        //string[] names = { "Srikaran", "Pavan", "Raman", "Aditya","Subhanshu" };
        ////Starts With 'A'
        //var startWithA = names.Where(x => x.StartsWith("A"));
        //foreach (var name in startWithA)
        //{
        //    Console.WriteLine(name);
        //}

        ////Using IEnum
        //IEnumerable<string> startWithA1 = names.Where(x => x.StartsWith("A"));
        //foreach (var name in startWithA1)
        //{
        //    Console.WriteLine(name);
        //}

        ////End With 'u'
        //var endsWithU = names.Where(x => x.EndsWith("u")).Select(x => "Mr." + x);
        //foreach (var name in endsWithU)
        //{
        //    Console.WriteLine(name);
        //}

        ////Using IEnum
        //IEnumerable<string> endsWithU1 = names.Where(x => x.EndsWith("u")).Select(x => "Mr." + x);
        //foreach (var name in endsWithU1)
        //{
        //    Console.WriteLine(name);
        //}

        //int[] nums = { 15, 3, 2, 7, 33, 21, 71, 23 };
        //IEnumerable<int> res = nums.SkipWhile(n => n < 30);
        //foreach (var num in res)
        //{
        //    Console.WriteLine(num);
        //}

        //IEnumerable<int> res1 = nums.TakeWhile(n => n > 30);
        //foreach (var num in res1)
        //{
        //    Console.WriteLine(num);
        //}

        //Good Example to Understand Ienum vs List(Differed Exec vs Immediate Exec)
        //List<int> numbers = new List<int> { 1, 2, 3, 4 };
        //IEnumerable<int> result = numbers.Where(x => x > 2);
        //numbers.Add(10);
        ////IEnumerable uses Deferred Execution
        //foreach (var n in result)
        //{
        //    Console.WriteLine(n);
        //}

        //Var => Compile time fixation
        //var num = 10;
        //Console.WriteLine("Value: " + num);
        //Console.WriteLine("Type: " + num.GetType());
        ////num = "Srikaran; // This will cause a compile-time error because 'num' is inferred as int";

        //dynamic dynNum = 10;
        //Console.WriteLine("Dynamic Value: " + dynNum);
        //Console.WriteLine("Dynamic Type: " + dynNum.GetType());
        //dynNum = "Srikaran"; // This is allowed because 'dynNum' is dynamic
        //Console.WriteLine("Dynamic Value after change: " + dynNum);

        //Func Delegate internally uses lambda expression
        Func<int,bool> check = x => x > 10;
        Console.WriteLine(check(15));
        Console.WriteLine(check(5));

        //Expression Tree
        //Iquereable -> Build the SQL Query using Expression Tree ( Builds/Creates a Schema and can be executed any where ( Best Understand in Entity Framework )).
        //Ienum executes the  query immediately, never uses sql query.
    }
}