class Program
{
    static void Main()
    {
        Aleatorios aleatorio = new Aleatorios();

        // Generar un número aleatorio entre 10 y 20
        int numero = aleatorio.GenerarNumero(10, 20);
        Console.WriteLine($"Número aleatorio: {numero}");

        // Generar un arreglo de 5 números aleatorios entre 1 y 100
        int[] arreglo = aleatorio.GenerarArreglo(5, 1, 100);
        Console.WriteLine("Arreglo aleatorio:");
        foreach (int num in arreglo)
        {
            Console.Write(num + " ");
        }
    }
}
