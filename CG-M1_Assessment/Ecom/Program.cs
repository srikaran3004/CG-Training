using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Order order = new Order();

        order.AddOrderDetails(101, "Arjun", "Laptop");
        order.AddOrderDetails(102, "Neha", "Mobile");

        Console.WriteLine(order.GetOrderDetails());

        order.RemoveOrderDetails();

        if (Order.OrderStack.Count > 0)
        {
            Console.WriteLine(order.GetOrderDetails());
        }
    }
}

public class Order
{
    public static Stack<Order> OrderStack { get; set; } = new Stack<Order>();

    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string Item { get; set; }

    public Stack<Order> AddOrderDetails(int orderId, string customerName, string item)
    {
        Order o = new Order
        {
            OrderId = orderId,
            CustomerName = customerName,
            Item = item
        };

        OrderStack.Push(o);
        return OrderStack;
    }

    public string GetOrderDetails()
    {
        if (OrderStack.Count == 0)
        {
            return "No orders available";
        }

        Order o = OrderStack.Peek();
        return o.OrderId + " " + o.CustomerName + " " + o.Item;
    }

    public Stack<Order> RemoveOrderDetails()
    {
        if (OrderStack.Count > 0)
        {
            OrderStack.Pop();
        }

        return OrderStack;
    }
}
