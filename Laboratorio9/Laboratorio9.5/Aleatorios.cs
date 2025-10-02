using System;
using System.Collections.Generic;

public class Aleatorios
{
    private Random rnd;

    public Aleatorios()
    {
        rnd = new Random();
    }

    public int GenerarNumero(int min, int max)
    {
        return rnd.Next(min, max + 1);
    }

    public int[] GenerarArreglo(int cantidad, int min, int max)
    {
        int[] arreglo = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = GenerarNumero(min, max);
        }

        return arreglo;
    }

    
    public int[] GenerarArregloSinRepetidos(int cantidad, int min, int max)
    {
        int rangoTotal = max - min + 1;

        if (cantidad > rangoTotal)
        {
            throw new ArgumentException("La cantidad solicitada excede el número de valores únicos posibles en el rango.");
        }

        List<int> posiblesNumeros = new List<int>();
        for (int i = min; i <= max; i++)
        {
            posiblesNumeros.Add(i);
        }

        int[] resultado = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            int indice = rnd.Next(posiblesNumeros.Count);
            resultado[i] = posiblesNumeros[indice];
            posiblesNumeros.RemoveAt(indice); 
        }

        return resultado;
    }
}

