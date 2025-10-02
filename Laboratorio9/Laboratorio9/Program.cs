using System;

class Program
{
    static void Main()
    {
        double precio;
        string formaPago;
        string numeroCuenta = "";

        
        do
        {
            Console.Write("Ingrese el precio del producto (positivo): ");
            if (!double.TryParse(Console.ReadLine(), out precio) || precio <= 0)
            {
                Console.WriteLine(" Precio inválido. Intente nuevamente.");
            }
        } while (precio <= 0);

        
        Console.Write("Forma de pago (efectivo/tarjeta): ");
        formaPago = Console.ReadLine().Trim().ToLower();

        if (formaPago == "tarjeta")
        {
           
            bool cuentaValida = false;

            do
            {
                Console.Write("Ingrese el número de cuenta (16 dígitos): ");
                numeroCuenta = Console.ReadLine().Trim();

                if (numeroCuenta.Length == 16 && long.TryParse(numeroCuenta, out _))
                {
                    cuentaValida = true;
                }
                else
                {
                    Console.WriteLine("⚠️ Número de cuenta inválido. Debe tener exactamente 16 dígitos numéricos.");
                }

            } while (!cuentaValida);
        }

       
        Console.WriteLine("\n RESUMEN DE COMPRA");
        Console.WriteLine($"Precio del producto: ${precio:F2}");
        Console.WriteLine($"Forma de pago: {formaPago}");

        if (formaPago == "tarjeta")
        {
            Console.WriteLine($"Número de cuenta: **** **** **** {numeroCuenta.Substring(12)}");
        }

        Console.WriteLine("\n Operación completada.");
        Console.ReadKey();
    }
}
