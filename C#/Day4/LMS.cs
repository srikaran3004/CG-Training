using System;
class Book
{
    private Dictionary<int, string> books = new Dictionary<int, string>();
    public string this[int bookId]
    {
        get
        {
            return books[bookId];
        }
        set
        {
            books[bookId] = value;
        }
    }
    public string this[string bookName]
    {
        get
        {
            return books.FirstOrDefault(b => b.Value == bookName).Value;
        }
    }

}