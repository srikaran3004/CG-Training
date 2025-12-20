using System;
class Calculator
{
    public static void calculate()
    {
        int add(int x, int y)
        {
            return x + y;
        }
        int sub(int x, int y)
        {
            return x - y;
        }
        int res1 = add(3, 5);
        int res2 = sub(6, 5);
        Console.WriteLine($"Result : {res1} and {res2}");
    }
}

/**
void Calculate()
{
    int number = 5;

    static int Square(int x)
    {
        return x * x;
    }

    Console.WriteLine(Square(number));
}
A static local function cannot access variables of its enclosing method; values must be passed explicitly as parameters.
A variable from a parent method is accessible inside an inner method only if the inner method is non-static; static local methods cannot access parent variables.


| Parent Method | Child Method | Variable Type | Accessible |
| ------------- | ------------ | ------------- | ---------- |
| static        | non-static   | static        | ✅          |
| static        | non-static   | local         | ✅          |
| static        | non-static   | instance      | ❌          |
| static        | static       | static        | ✅          |
| static        | static       | local         | ❌          |
| static        | static       | instance      | ❌          |
| non-static    | non-static   | static        | ✅          |
| non-static    | non-static   | instance      | ✅          |
| non-static    | non-static   | local         | ✅          |
| non-static    | static       | static        | ✅          |
| non-static    | static       | instance      | ❌          |
| non-static    | static       | local         | ❌          |

**/
