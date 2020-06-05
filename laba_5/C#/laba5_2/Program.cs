using System;

namespace laba5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure[] figures = new Figure[2];
            figures[0] = new Trapeze(new int[,] { { 0, 0 }, { 3, 4 }, { 8, 4 }, { 11, 0 } });
            figures[1] = new Circle(5);
            Console.WriteLine($"Trapeze:\n\tArea: {figures[0].Area()}\n\tPerimeter: {figures[0].Perimeter()}\n\nCircle:\n\tArea: {figures[1].Area()}\n\tPerimeter: {figures[1].Perimeter()}");
        }
    }
}
        