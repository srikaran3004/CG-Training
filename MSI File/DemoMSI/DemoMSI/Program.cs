using System;
using System.Collections.Generic;

class Program
{
    static List<TaskItem> tasks = new List<TaskItem>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== TASK MANAGER ====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine();

        tasks.Add(new TaskItem(title));
        Console.WriteLine("Task added successfully.");
        Pause();
    }

    static void ViewTasks()
    {
        Console.WriteLine("\n--- Task List ---");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        Pause();
    }

    static void CompleteTask()
    {
        ViewTasks();
        Console.Write("Enter task number to mark complete: ");

        if (int.TryParse(Console.ReadLine(), out int index) &&
            index > 0 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
            Console.WriteLine("Task marked as completed.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }

        Pause();
    }

    static void DeleteTask()
    {
        ViewTasks();
        Console.Write("Enter task number to delete: ");

        if (int.TryParse(Console.ReadLine(), out int index) &&
            index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Task deleted.");
        }
        else
        {
            Console.WriteLine("Invalid task number.");
        }

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}

public class TaskItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string title)
    {
        Title = title;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return $"{Title} - {(IsCompleted ? "Completed" : "Pending")}";
    }
}