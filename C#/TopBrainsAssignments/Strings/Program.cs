using System;
using System.Collections.Generic;

interface IArea
{
    double GetArea();
}

abstract class Shape : IArea
{
    public abstract double GetArea();
}

class Circle : Shape
{
    double r;
    public Circle(double radius) { r = radius; }
    public override double GetArea() => Math.PI * r * r;
}

class Rectangle : Shape
{
    double w, h;
    public Rectangle(double width, double height) { w = width; h = height; }
    public override double GetArea() => w * h;
}

class Triangle : Shape
{
    double b, h;
    public Triangle(double bse, double height) { b = bse; h = height; }
    public override double GetArea() => 0.5 * b * h;
}

class Program
{
    static double TotalArea(string[] shapes)
    {
        List<Shape> list = new List<Shape>();

        foreach (string s in shapes)
        {
            string[] parts = s.Split(' ');
            if (parts[0] == "C")
                list.Add(new Circle(double.Parse(parts[1])));
            else if (parts[0] == "R")
                list.Add(new Rectangle(double.Parse(parts[1]), double.Parse(parts[2])));
            else if (parts[0] == "T")
                list.Add(new Triangle(double.Parse(parts[1]), double.Parse(parts[2])));
        }

        double total = 0;
        foreach (var shape in list)
            total += shape.GetArea();

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] shapes = new string[n];
        for (int i = 0; i < n; i++)
            shapes[i] = Console.ReadLine();

        Console.WriteLine(TotalArea(shapes));
    }
}
