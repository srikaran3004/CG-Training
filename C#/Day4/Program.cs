using System;
/**
class Product
{
    public string Name = "";
    public int Price;

    public Product() { }

    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public void displayDetails()
    {
        Console.WriteLine($"Name is {Name}");
        Console.WriteLine($"Price is {Price}");
    }
}
@Using getter , setter methods !!
class ProductWithProperty
{
    private string name;
    private int price;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Name is {Name}");
        Console.WriteLine($"Price is {Price}");
    }
}

class ProductWithProperty
{
    public string Name { get; set; }
    public int Price { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine($"Name is {Name}");
        Console.WriteLine($"Price is {Price}");
    }
}
**/

class Program
{
    static void Main()
    {
        /** BankAccount b1= new BankAccount(30000,"ACC34567"); 
        b1.ShowAccount(); 
        FixedDeposit fd = new FixedDeposit(50000, "ACC12345", 3, 6.5); 
        fd.ShowFD(); 
        Product p1 = new Product("Soap", 30);
        //Product p1 = new Product{Name="Soap",Pric e= 30};-> Here Product constructor of default constructor is being used.
        p1.displayDetails();
        ProductWithProperty p2 = new ProductWithProperty();
        p2.Name = "Soap";
        p2.Price = 30;
        p2.DisplayDetails();
        **/
        Student s1 = new Student();
        s1.Name = "Srikaran";
        s1.Age = 21;
        s1.Marks = 100;
        s1.Password = "abc1234";
        Console.WriteLine($"Name is {s1.Name}");
        Console.WriteLine($"Age is {s1.Age}");
        Console.WriteLine($"Marks is {s1.Marks}");
        // Console.WriteLine($"Password is {s1.Password}"); // we can't use it because we only used set value and not get value. 
    }
}


