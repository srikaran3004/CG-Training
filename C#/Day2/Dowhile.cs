using System;
class DoWhile()
{
    public static void calculate()
    {
        int cnt = 0;
        do
        {
            Console.WriteLine(cnt);
            cnt++;
        } while (cnt <= 5);
    }
}
//It need to atleast run once, then it runs according to the condition. 