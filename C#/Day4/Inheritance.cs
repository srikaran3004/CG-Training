/**
class Person
{
    public string Name;

    public Person(string name)
    {
        Name = name; (Name is global and class scope).
    }
}

class Student : Person
{
    public int RollNo;

    public Student(string name, int roll) : base(name) [ here base(name) is local parameter to child class Student.]
    {
        RollNo = roll;
    }
}

The name in Person class and Student class are not same as name in Parent class is being used and destroyed.
C# doesn't support multiple inheritance .
**/