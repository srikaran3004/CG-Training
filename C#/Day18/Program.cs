// using System;
// using System.Diagnostics;

// class Program
// {
//     static void Main()
//     {
//         Process currentProcess = Process.GetCurrentProcess();
//         Console.WriteLine("Current Process ID: " + currentProcess.Id);
//         Console.WriteLine("Process Name: " + currentProcess.ProcessName);
//         Console.WriteLine("Process Start Time: "+currentProcess.StartTime);
//     }
// }
using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    // static int counter = 0;
    static void Main()
    {
        // // Create a new thread
        // Thread worker = new Thread(DoWork);

        // // Start the thread
        // worker.Start();

        // Console.WriteLine("Main thread continues...");

        // // Optional: Wait for worker thread to finish
        // worker.Join();
        // Console.WriteLine("Main thread finished");
        // Process.Start("explorer.exe");
        // Thread t1 = new Thread(Increment);
        // Thread t2 = new Thread(Increment);
        // t1.Start();
        // t2.Start();
        // t1.Join();
        // Console.WriteLine("Counter after t1: "+counter);
        // t2.Join();
        // Console.WriteLine("Final Counter value: " + counter);
        
    }
    // static void Increment()
    // {
    //     for (int i = 0; i < 100000; i++)
    //     {
    //         counter++;
    //     }
    // }
    // Thread t1 = new Thread(() =>
    // {
    //     for (int i = 0; i < 1000000; i++)
    //     {
    //         Interlocked.Add(ref counter, 1);
    //     }
    // });
    // Thread t2 = new Thread(() =>
    // {
    //     for (int i = 0; i < 1000000; i++)
    //     {
    //         Interlocked.Add(ref counter, 1);
    //     }
    // });

    // static void DoWork()
    // {
    //     for (int i = 1; i <= 5; i++)
    //     {
    //         Console.WriteLine("Worker thread: " + i);
    //         Thread.Sleep(500); // Simulate work
    //     }
    // }
}
