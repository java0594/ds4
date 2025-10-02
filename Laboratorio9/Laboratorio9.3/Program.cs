using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Ingrese el lado A: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el lado B: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el lado C: ");
        double c = Convert.ToDouble(Console.ReadLine());

        
        if (EsTrianguloValido(a, b, c))
        {
            
            if (a == b && b == c)
            {
                Console.WriteLine("Es un triángulo equilátero.");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("Es un triángulo isósceles.");
            }
            else
            {
                Console.WriteLine("Es un triángulo escaleno.");
            }
        }
        else
        {
            Console.WriteLine("Los lados ingresados NO forman un triángulo válido.");
        }
    }

        static bool EsTrianguloValido(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }
}
