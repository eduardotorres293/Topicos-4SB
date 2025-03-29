using System;
using System.Diagnostics;
using System.Threading;
class Program
{
    static long sumaTotal = 0;
    static object lockObject = new object();
    static void CalcularPrimos(object rango)
    {
        (int inicio, int fin) = ((int, int))rango;
        int suma = 0;
        for (int i = inicio; i <= fin; i++)
        {
            if (EsPrimo(i))
            {
                suma += i;
            }
        }
        lock (lockObject)
        {
            sumaTotal += suma;
        }
    }
    static bool EsPrimo(int numero)
    {
        if (numero < 2) return false;
        if (numero == 2 || numero == 3) return true;
        if (numero % 2 == 0 || numero % 3 == 0) return false;

        for (int i = 5; i * i <= numero; i += 6)
        {
            if (numero % i == 0 || numero % (i + 2) == 0)
                return false;
        }
        return true;
    }
    static void Main()
    {
        Console.WriteLine("Ingrese el número límite:");
        int N = int.Parse(Console.ReadLine());
        int M = 4; // Número de hilos

        Stopwatch stopwatchSecuencial = Stopwatch.StartNew();
        int sumaTotalSecuencial = 0;
        for (int i = 2; i <= N; i++)
        {
            if (EsPrimo(i))
            {
                sumaTotalSecuencial += i;
            }
        }
        stopwatchSecuencial.Stop();

        Console.WriteLine($"Suma total de números primos hasta {N} (Secuencial): {sumaTotalSecuencial}");
        Console.WriteLine($"Tiempo de ejecución (Secuencial): {stopwatchSecuencial.ElapsedMilliseconds} ms");

        Stopwatch stopwatchConcurrente = Stopwatch.StartNew();
        sumaTotal = 0;
        Thread[] hilos = new Thread[M];
        for (int i = 0; i < M; i++)
        {
            int inicio = i * (N / M) + 1;
            int fin = (i == M - 1) ? N : inicio + (N / M) - 1;
            hilos[i] = new Thread(CalcularPrimos);
            hilos[i].Start((inicio, fin));
        }
        foreach (var hilo in hilos)
        {
            hilo.Join();
        }
        stopwatchConcurrente.Stop();

        Console.WriteLine($"Suma total de números primos hasta {N} (Concurrente): {sumaTotal}");
        Console.WriteLine($"Tiempo de ejecución (Concurrente): {stopwatchConcurrente.ElapsedMilliseconds} ms");
    }

}