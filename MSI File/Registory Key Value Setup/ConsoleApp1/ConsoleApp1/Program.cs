using System;
using Microsoft.Win32;

class Program
{
    static void Main()
    {
        string keyPath = @"Software\MyTestApp";

        // 1️⃣ Create or open key
        RegistryKey key = Registry.CurrentUser.CreateSubKey(keyPath);

        // 2️⃣ Write value
        key.SetValue("Username", "Srikaran3004");
        Console.WriteLine("Value written.");

        // 3️⃣ Read value safely
        object value = key.GetValue("Username");

        if (value != null)
            Console.WriteLine("Read from registry: " + value.ToString());
        elsea
            Console.WriteLine("Value not found.");

        key.Close();

        // 4️⃣ Delete value safely
        RegistryKey deleteKey = Registry.CurrentUser.OpenSubKey(keyPath, true);

        if (deleteKey.GetValue("Username") != null)
        {
            deleteKey.DeleteValue("Username");
            Console.WriteLine("Value deleted.");
        }
        else
        {
            Console.WriteLine("Nothing to delete.");
        }

        deleteKey.Close();
    }
}
