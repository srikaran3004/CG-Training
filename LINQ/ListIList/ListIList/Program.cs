using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
class Program
{
    public static void Main(String[] args)
    {
        List<int> listNumbers = new List<int> { 10, 20, 30 };
        Collection<int> collectionNumbers = new Collection<int> { 40, 50, 60 };
        ObservableCollection<int> observableCollectionNumbers = new ObservableCollection<int> { 70, 80, 90 };
        PrintList(listNumbers);
        //PrintList(collectionNumbers);
        //PrintList(observableCollectionNumbers);
        Console.WriteLine();
        Console.WriteLine("Calling method that accpets IList: ");
        PrintIList(listNumbers);
        PrintIList(collectionNumbers);
        PrintIList(observableCollectionNumbers);
    }
    static void PrintIList(IList<int> numbers) //in this we have flexibility to pass List, Collection and ObservableCollection because they all implement IList interface   
    {
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
    static void PrintList(List<int> numbers)
    {
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}