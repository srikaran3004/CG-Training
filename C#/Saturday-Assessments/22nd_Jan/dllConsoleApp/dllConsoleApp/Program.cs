using System.Reflection;

Assembly assembly = Assembly.Load("dllLibrary");
Type[] types = assembly.GetTypes();

foreach (var type in types)
{
    if (type.IsInterface)
    {
        Console.WriteLine($"\nInterface: {type.FullName}");
    }
    else if (type.IsClass)
    {
        Console.WriteLine($"\nClass: {type.FullName}");
    }
    else
    {
        Console.WriteLine($"\nType: {type.FullName}");
    }

    if (type.IsClass)
    {
        var interfaces = type.GetInterfaces();
        foreach (var iface in interfaces)
        {
            Console.WriteLine($"  Implements: {iface.FullName}");
        }
    }

    var methods = type.GetMethods(
        BindingFlags.Public |
        BindingFlags.NonPublic |
        BindingFlags.Instance |
        BindingFlags.Static 
        //BindingFlags.DeclaredOnly
    );

    foreach (var method in methods)
    {
        Console.WriteLine($"  Method: {method.Name}");
    }
}
