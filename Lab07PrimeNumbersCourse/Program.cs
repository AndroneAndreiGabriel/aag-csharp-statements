using System;

namespace Lab07PrimeNumbersCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = ReadNumber("N=", 2);
            int[] primes = Primes(n);
            PrintArray("Array", primes);

            long[] fibo = Fibonacci(n);
            PrintArrayLong("Array", fibo);
        }

        static void PrintArray(string label, int[] array)
        {
            Console.WriteLine();
            string elementList = string.Join(", ", array);
            Console.WriteLine($"{label}: {elementList}");
        }

        static void PrintArrayLong(string label, long[] array)
        {
            Console.WriteLine();
            string elementList = string.Join(", ", array);
            Console.WriteLine($"{label}: {elementList}");
        }

        static int ReadNumber(string label, int defaultValue)
        {
            Console.Write(label);
            string value = Console.ReadLine();
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            return defaultValue;
        }

        static int[] Primes(int n)
        {
            // 0 -> n
            // wasCut[i] = 0 (false): daca numarul "i" NU a fost taiat (este prim)
            // wasCut[i] = 1 (true): daca numarul "i" A fost taiat (nu este prim)

            bool[] wasCut = new bool[n + 1];
            int primesCount = 0;
            for (int i = 2; i <= n; i++)
            {
                if (!wasCut[i])
                {
                    // am un nr prim
                    primesCount++;

                    for (int factor = 2; factor * i <= n; factor++)
                    {
                        wasCut[i * factor] = true;
                    }
                }
            }

            int[] result = new int[primesCount];
            for (int i = 2, idxResult = 0; i < wasCut.Length; i++)
            {
                if (!wasCut[i])
                {
                    result[idxResult] = i;
                    idxResult++;
                }
            }

            return result;
        }

        static long[] Fibonacci(int n)
        {
            if (n == 0)
            {
                return new long[] { 0 };
            }

            if (n == 1)
            {
                return new long[] { 0, 1 };
            }

            long[] fibo = new long[n + 1];
            fibo[0] = 0;
            fibo[1] = 1;

            for (long i = 2; i <= n; i++)
            {
                fibo[i] = fibo[i - 1] + fibo[i - 2];
            }

            return fibo;
        }
    }
}
