using System;

namespace Laborator7_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //citire array
            int[] array = ReadArray("Array");
                        
            //tiparire
            PrintArray("Array", array);
        }

        static int ReadNumber(string label, int defaultValue)
        {
            Console.Write(label);
            string value = Console.ReadLine();
            //Convert.ToInt32();
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            return defaultValue;
        }

        static int[] ReadArray(string label)
        {
            //citire array
            Console.WriteLine(label);
            int nr = ReadNumber("Elements count= ", 0);
            int[] array = new int[nr];
            for (int i = 0; i < array.Length; i++)
            {
                int element = ReadNumber($"Element[{i}]= ", 0);
                array[i] = element;
            }

            return array;
        }

        static void PrintArray(string label, int[] array)
        {
            Console.WriteLine();
            string elementList = string.Join(", ", array);
            Console.Write($"{label}={elementList}");
        }
    }
}
