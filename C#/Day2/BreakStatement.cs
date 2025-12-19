using System;
class BreakStatement
{
    public static void calculate()
    {
        for(int i = 0; i <= 10; i++)
        {
            if (i == 5)
            {
                break;
            }
            Console.WriteLine(i);
        }
    }
}