using System;

using LibItemsAlias = LibrarySystem.Items;

public enum UserRole
{
    Admin,
    Librarian,
    Member
}

public enum ItemStatus
{
    Available,
    Borrowed,
    Reserved,
    Lost
}

namespace LibrarySystem
{
    namespace Items
    {
        class Book : LibraryItem, IReservable, INotifiable
        {
            public override void displayItem()
            {
                Console.WriteLine("Item Type: Book");
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("Item ID: " + ItemID);
            }

            public override double calculateFee(int days)
            {
                return days * 1.0;
            }

            public void Reserving()
            {
                Console.WriteLine("Book reserved successfully.");
            }

            public void AcceptMsg()
            {
                Console.WriteLine("Notification sent.");
            }
        }

        class Magazine : LibraryItem
        {
            public override void displayItem()
            {
                Console.WriteLine("Item Type: Magazine");
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("Item ID: " + ItemID);
            }

            public override double calculateFee(int days)
            {
                return days * 0.5;
            }
        }
    }

    namespace Users
    {
        public class Member
        {
            public string Name { get; set; }
            public UserRole Role { get; set; }
        }
    }
}

public abstract class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int ItemID { get; set; }

    public abstract void displayItem();
    public abstract double calculateFee(int days);
}

interface IReservable
{
    void Reserving();
}

interface INotifiable
{
    void AcceptMsg();
}

public partial class LibraryAnalytics
{
    public static int Items = 0;
}

public partial class LibraryAnalytics
{
    public static void DisplayAnalytics()
    {
        Console.WriteLine("Total Items Borrowed: " + Items);
    }
}
