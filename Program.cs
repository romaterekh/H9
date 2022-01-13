using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace H8
{
    public abstract class Shape : IComparable<Shape>
    {
        public int CompareTo(Shape s)
        {
            return this.Area().CompareTo(s.Area());
        }

        private string name;
        public string Name
        {
            get { return name; }
        }
        public Shape(string name)
        {
            this.name = name;
        }
        public abstract double Area();
        public abstract double Perimeter();
    }

    public class Circle : Shape
    {
        private double radius;
        public double Radius
        {
            get { return radius; }
        }
        public Circle(string name, double radius) : base(name)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return Math.Pow(radius, 2) * Math.PI;
        }
        public override double Perimeter()
        {
            return radius * Math.Pow(Math.PI, 2);
        }
    }

    public class Square : Shape
    {
        private double side;

        public double Side
        {
            get { return side; }
        }
        public Square(string name, double side) : base(name)
        {
            this.side = side;
        }
        public override double Area()
        {
            return Math.Pow(side, 2);
        }
        public override double Perimeter()
        {
            return Math.Pow(side, 4);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string name;
            double radius;
            double side;
            double maxPer = 0;
            string maxPerName = "";

            List<Shape> shapes = new List<Shape>();

            for (int i = 0; i < 6; i++)
            {
            a1:
                Console.WriteLine("Enter Circle or Square");
                name = Convert.ToString(Console.ReadLine());

                if (name == "Circle" || name == "Square")
                {
                    if (name == "Circle")
                    {
                        Console.WriteLine("Enter radius");
                        radius = Convert.ToDouble(Console.ReadLine());
                        shapes.Add(new Circle(name, radius));
                    }

                    if (name == "Square")
                    {
                        Console.WriteLine("Enter side");
                        side = Convert.ToDouble(Console.ReadLine());
                        shapes.Add(new Square(name, side));
                    }
                }
                else
                {
                    Console.WriteLine("Enter only Circle or Square");
                    goto a1;
                }
            }



            shapes.Sort();
            Console.WriteLine("Sorted by area");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"Name {shape.Name} Area {shape.Area()} Perimeter {shape.Perimeter()}");
                if (shape.Perimeter() > maxPer)
                    maxPerName = shape.Name;
                maxPer = shape.Perimeter();
            }
            Console.WriteLine($"Max Name = {maxPerName} Max Perimeter = {maxPer}");
        }
    }
}
