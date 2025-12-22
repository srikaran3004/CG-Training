using System;
using System.Security.Permissions;
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
        Student s1 = new Student(101)
        {
            AdmissionYear = 2024
        };

        s1.Name = "Srikaran";
        s1.Age = 21;
        s1.Marks = 100;
        s1.Password = "abc1234";

        Console.WriteLine($"Registration Number: {s1.RegistrationNumber}");
        Console.WriteLine($"Admission Year: {s1.AdmissionYear}");
        Console.WriteLine($"Name is {s1.Name}");
        Console.WriteLine($"Age is {s1.Age}");
        Console.WriteLine($"Marks is {s1.Marks}");
        Console.WriteLine($"Result is {s1.Result}");
        Console.WriteLine($"Percentage is {s1.Percentage}");
        // Console.WriteLine($"Password is {s1.Password}"); // we can't use it because we only used set value and not get value. 
        EmployeeDirectory ed = new EmployeeDirectory();
        ed[101] = "Ravi";
        Console.WriteLine(ed[101]);
        Console.WriteLine(ed["Ravi"]);

        Book b = new Book();
        b[1] = "harry";
        b[2] = "porter";
        b[3] = "lms";
        Console.WriteLine(b[1]);
        Console.WriteLine(b[2]);
        // Console.WriteLine(b[4]);
        **/
        Security s1 = new Security();
        s1.authenticate();

        LifeInsurance l1 = new LifeInsurance
        {
            PolicyNum = 101,
            PolicyHolder = "Srikaran",
            Premium = 1000
        };

        HealthInsurance h1 = new HealthInsurance
        {
            PolicyNum = 102,
            PolicyHolder = "Siva",
            Premium = 500
        };

        PolicyDirectory directory = new PolicyDirectory();
        directory[l1.PolicyNum] = l1;
        directory[h1.PolicyNum] = h1;

        Console.WriteLine(directory[101].PolicyHolder);
        Console.WriteLine(directory["Siva"].PolicyNum);

        Console.WriteLine("Life Premium: " + l1.premCalculate());
        Console.WriteLine("Health Premium: " + h1.premCalculate());

        l1.ShowPolicy();

        InsurancePolicy baseRef = l1;
        baseRef.ShowPolicy();
    }
}


