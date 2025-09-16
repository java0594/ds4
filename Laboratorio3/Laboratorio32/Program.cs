using System;

namespace Laboratorio31;

public class CalculosMatematicos
{
   /* public static int Calcular(int a, int b)
    {
        return (a + b) * (a - b);
    }*/

    public static double calcularArea(double radio)
    {
        return Math.PI * Math.Pow(radio, 2);
    }   
}

public class Program
{
    private static void Main(string[] args)
    {
          double radio;
        Console.Write("ingrese el radio del circulo: ");
        radio = Convert.ToInt32(Console.ReadLine());
       
        if (radio < 0)
        {
            Console.WriteLine("El radio no puede ser negativo.");
        }
        else
        {
            double area = CalculosMatematicos.calcularArea(radio);
            Console.WriteLine($"Área del círculo: {area}");
        }

    }
}