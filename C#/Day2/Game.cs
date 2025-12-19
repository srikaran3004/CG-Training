using System;
class Game
{
    public static void calculate()
    {
        int cnt=10;
        Console.WriteLine("GAME BEGINS: ");
        for(int i = 1; i <= cnt; i++)
        {
            if (i == 4)
            {
                Console.WriteLine($"Enemy{i} is invisible, Skipping E{i}");
                continue;
            }
            Console.WriteLine($"Player killed Enemy{i}");
        }
        Console.WriteLine("GAME END");
    }
}