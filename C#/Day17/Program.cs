using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Threading
{
    // public static void Main(string[] args)
    // {
    //     Thread thread = new Thread(new ParameterizedThreadStart(PrintMessage));
    //     thread.Start("Hello from thread");
    // }
    // static void PrintMessage(object message)
    // {
    //     Console.WriteLine(message);
    // }
    // static void Main()
    // {
    //     Thread worker = new Thread(DoWork);
    //     worker.Start();
    //     Console.WriteLine("Main Thread continues...");
    // }
    // static void DoWork()
    // {
    //     for(int i = 1; i <= 5; i++)
    //     {
    //         Console.WriteLine("Worker thread "+i);
    //         Thread.Sleep(1000);
    //     }
    // }
    // static void Main(string[] args)
    // {
    // Parallel.For(0, 5, i =>
    // {
    //     Console.WriteLine($"processing item {i}");
    // });
    // int[] numbers = new int[10];
    // for (int i = 0; i < numbers.Length; i++)
    // {
    //     numbers[i] = i + 1;
    // }
    // int sum = 0;
    // Parallel.For(0, numbers.Length, i =>
    // {
    //     sum += numbers[i]; // Not thread-safe (for demonstration) 
    // });
    // Console.WriteLine("Sum: " + sum);
    // Parallel.For(0, numbers.Length, () => 0,
    //     (i, loopState, localSum) => localSum + numbers[i],
    //     localSum => Interlocked.Add(ref sum, localSum));
    // Console.WriteLine("Sum: " + sum);
    // async Task<int> GetDataAsync()
    // {
    //     await Task.Delay(1000);
    //     return 42;
    // }
    // await GetDataAsync(); 
    // }
    static async Task Main(string[] args)
    {
        // Console.WriteLine("Starting async work...");
        // static async Task<int> GetDataAsync()
        // {
        //     await Task.Delay(1000); // Simulate async I/O
        //     return 42;
        // }
        // Task<int> pending = GetDataAsync(); // Start but don't await yet
        // DoOtherWork();                      // Runs while the async task is in-flight
        // int singleResult = await pending;   // Now await completion
        // Console.WriteLine($"Single result: {singleResult}");
        // var sw = Stopwatch.StartNew();
        // var t1 = GetDataAsync();
        // var t2 = GetDataAsync();
        // var results = await Task.WhenAll(t1, t2);
        // sw.Stop();
        // Console.WriteLine($"Parallel results: {string.Join(", ", results)}");
        // Console.WriteLine($"Elapsed (ms): {sw.ElapsedMilliseconds}");

        Console.WriteLine("Start reading file...");
        string content = await File.ReadAllTextAsync("data.txt"); //here it pauses the thread where await is written.
        Console.WriteLine("File content:");
        Console.WriteLine(content);
        Console.WriteLine("End of program");
    }
    // static void DoOtherWork()
    // {
    //     Console.WriteLine("Doing other work while async task runs...");
    //     for (int i = 1; i <= 3; i++)
    //     {
    //         Console.WriteLine($"Other work tick {i}");
    //         Thread.Sleep(200); // Simulate quick synchronous work
    //     }
    // }
}