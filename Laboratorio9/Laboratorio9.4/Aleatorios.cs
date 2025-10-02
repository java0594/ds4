using System;

public class Aleatorios
{
    // Atributo Random
    private Random rnd;

    // Constructor
    public Aleatorios()
    {
        rnd = new Random();
    }

    // Método 1: Generar un número aleatorio entre dos números
    public int GenerarNumero(int min, int max)
    {
        return rnd.Next(min, max + 1); // Incluye el límite superior
    }

    // Método 2: Generar un arreglo de números aleatorios entre dos números
    public int[] GenerarArreglo(int cantidad, int min, int max)
    {
        int[] arreglo = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = GenerarNumero(min, max);
        }

        return arreglo;
    }
}
