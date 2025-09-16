using System;

namespace Laboratorio31;

public class CalculosMatematicos
{
    public static int Calcular(int a, int b)
    {
        return (a + b) * (a - b);
    }
}

public class Program
{
    private static void Main(string[] args)
    {
        int a, b;
        Console.Write("Introduce el valor para a: ");
            a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Introduce el valor para b: ");
            b = Convert.ToInt32(Console.ReadLine());
        int resultado = CalculosMatematicos.Calcular(a, b);
        Console.WriteLine($"El resultado de (a + b) * (a - b) es: {resultado}");
    }
}