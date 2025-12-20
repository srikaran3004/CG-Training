using System;
class MathOps
{
    public static int add(int a, int b)
    {
        return a + b;
    }
    public static double add(double a, double b)
    {
        return a + b;

    }
    public static int add(int a, int b, int c)
    {
        return a + b + c;
    }
}
//Static methods are called using class name, not object name
//But if want to create an obj of this class and automatically it need to choose which Add function it should use then we remove word static,
//so that if we create a object m1 and use m1.add(2,3) or m1.add(3,4) or m1.add(0.3,4,0.5) then it automatically uses which add method it should use.