using System;
using LibrarySystem;
using LibrarySystem.Users;
using LibItemsAlias = LibrarySystem.Items;

class Program
{
    static void Main()
    {
        LibItemsAlias.Book book = new LibItemsAlias.Book
        {
            Title = "C# Fundamentals",
            Author = "Siva Ram Karri",
            ItemID = 101
        };
        LibItemsAlias.Magazine magazine = new LibItemsAlias.Magazine
        {
            Title = ".NET Fundementals",
            Author = "Jane Doe",
            ItemID = 201
        };
        book.displayItem();
        Console.WriteLine("Late Fee for 3 days: " + book.calculateFee(3));
        magazine.displayItem();
        Console.WriteLine("Late Fee for 3 days: " + magazine.calculateFee(3));
        IReservable reservable = book;
        reservable.Reserving();
        INotifiable notifiable = book;
        notifiable.AcceptMsg();
        LibraryItem[] items = new LibraryItem[2];
        items[0] = book;
        items[1] = magazine;
        foreach (LibraryItem item in items)
        {
            item.displayItem();
        }
        LibraryAnalytics.Items = 5;
        LibraryAnalytics.DisplayAnalytics();
        Member member = new Member
        {
            Name = "Srikaran",
            Role = UserRole.Member
        };
        ItemStatus status = ItemStatus.Borrowed;
        Console.WriteLine("User Role: " + member.Role);
        Console.WriteLine("Item Status: " + status);
        Console.WriteLine("Admin Alert: System maintenance scheduled.");
        Console.WriteLine("Member Notification: Your borrowed item is due tomorrow.");
    }
}
