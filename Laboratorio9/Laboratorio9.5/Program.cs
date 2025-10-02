class Program
{
    static void Main()
    {
        Aleatorios aleatorios = new Aleatorios();

        int min = 1;
        int max = 20;
        int cantidad = 10;

        try
        {
            int[] numerosUnicos = aleatorios.GenerarArregloSinRepetidos(cantidad, min, max);
            Console.WriteLine("Números aleatorios SIN repetidos:");
            foreach (int num in numerosUnicos)
            {
                Console.Write(num + " ");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
