using System;

namespace Laboratorio31;

public class CalculosMatematicos
{

    public static double perimetroRectangulo(double recBase, double altura)
    {
        return  2 * (recBase + altura);
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        double recBase, altura;
        Console.Write("ingrese la base del rectangulo: ");
        recBase = Convert.ToInt32(Console.ReadLine());

        Console.Write("ingrese la altura del rectangulo: ");
        altura = Convert.ToInt32(Console.ReadLine());

        if (recBase <= 0 || altura <= 0)
        {
            Console.WriteLine("Los lados deben ser mayores que cero.");
            return;
        }

        double perimetro = CalculosMatematicos.perimetroRectangulo(recBase, altura);
        Console.WriteLine($"El perímetro del rectángulo es: {perimetro}");



    }
}