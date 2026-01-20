using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Store store = new Store
        {
            store_id = 1,
            store_name = "DMART",
            phone = "1800 250 450 89",
            email = "dmart@mail.com",
            street = "Jyoti Chowk",
            city = "Jalandhar",
            state = "PB",
            zip_code = "144411"
        };

        Staff manager = new Staff
        {
            staff_id = 1,
            first_name = "Jaspal Singh",
            last_name = "Manager",
            email = "jspsingh@mail.com",
            phone = "9651245896",
            active = true,
            store_id = store
        };

        Staff staff = new Staff
        {
            staff_id = 2,
            first_name = "Preeti",
            last_name = "Sales",
            email = "preeti@mail.com",
            phone = "8795462356",
            active = true,
            store_id = store,
            manager_id = manager
        };

        store.staffs.Add(manager);
        store.staffs.Add(staff);
        manager.subordinates.Add(staff);

        Customer customer = new Customer
        {
            customer_id = 1,
            first_name = "Srikaran",
            last_name = "Devarakonda",
            phone = "7895462356",
            email = "srk@mail.com",
            street = "Kapurthala",
            city = "Jalandhar",
            state = "PB",
            zip_code = "144411"
        };

        Order order = new Order
        {
            order_id = 1001,
            customer_id = customer.customer_id,
            order_status = 1,
            order_date = DateTime.Now,
            required_date = DateTime.Now.AddDays(5),
            shipped_date = DateTime.Now.AddDays(2),
            store_id = store,
            staff_id = staff
        };

        customer.orders.Add(order);
        store.orders.Add(order);
        staff.orders.Add(order);

        OrderItem orderItem = new OrderItem
        {
            order_id = order.order_id,
            item_id = 1,
            product_id = 10,
            quantity = 2,
            list_price = 500,
            discount = 0.1m,
            order = order
        };

        order.order_items.Add(orderItem);

        Console.WriteLine(customer.first_name);
        Console.WriteLine(order.order_id);
        Console.WriteLine(staff.first_name);
        Console.WriteLine(store.store_name);
        Console.WriteLine(order.order_items.Count);
    }
}

public class Customer
{
    public int customer_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string street { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zip_code { get; set; }

    public List<Order> orders { get; set; } = new List<Order>();
}

public class Store
{
    public int store_id { get; set; }
    public string store_name { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string street { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zip_code { get; set; }

    public List<Order> orders { get; set; } = new List<Order>();
    public List<Staff> staffs { get; set; } = new List<Staff>();
}

public class Staff
{
    public int staff_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public bool active { get; set; }

    public Store store_id { get; set; }
    public Staff manager_id { get; set; }

    public List<Staff> subordinates { get; set; } = new List<Staff>();
    public List<Order> orders { get; set; } = new List<Order>();
}

public class Order
{
    public int order_id { get; set; }
    public int customer_id { get; set; }
    public int order_status { get; set; }
    public DateTime order_date { get; set; }
    public DateTime required_date { get; set; }
    public DateTime? shipped_date { get; set; }

    public Store store_id { get; set; }
    public Staff staff_id { get; set; }

    public List<OrderItem> order_items { get; set; } = new List<OrderItem>();
}

public class OrderItem
{
    public int order_id { get; set; }
    public int item_id { get; set; }
    public int product_id { get; set; }
    public int quantity { get; set; }
    public decimal list_price { get; set; }
    public decimal discount { get; set; }

    public Order order { get; set; }
}
