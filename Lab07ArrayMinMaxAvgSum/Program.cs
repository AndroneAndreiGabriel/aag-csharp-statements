using System;

namespace Lab07AssignArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = ReadArray("Array");

            PrintArray("Array is ", array);

            //calcul minim
            int min = Min(array);
            if (min == int.MinValue)
            {
                Console.WriteLine("Min cannot be calculated!");
            }
            else
            {
                Console.WriteLine($"Min={min}");
            }

            //calcul maxim
            int max = Max(array);
            if (max == int.MaxValue)
            {
                Console.WriteLine("Max cannot be calculated!");
            }
            else
            {
                Console.WriteLine($"Max={max}");
            }

            int element = ReadNumber("Element=", 0);
            int indexOfElement = IndexOf(array, element);
            if (indexOfElement == -1)
            {
                Console.WriteLine($"Element {element} was not found in the array");
            }
            else
            {
                Console.WriteLine($"Index of {element} is {indexOfElement}");
            }

            float avg = Average(array);
            Console.WriteLine($"Media aritmetica este {avg}");

            /*MinOfArray(array);
            MaxOfArray(array);
            IndexPosition(array);
            ArrayAverageValue(array);*/
        }

        /// <summary>
        /// Return the minimum element from an array
        /// </summary>
        /// <param name="array">array</param>
        /// <returns>minimum</returns>
        static int Min(int[] array)
        {
            //calcul minim
            if (array is null || array.Length == 0)
            {
                //nu pot calcula minim
                return int.MinValue;
            }
           
            //pot calcula minimul
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
            
        }

        /// <summary>
        /// Return the minimum element from an array
        /// </summary>
        /// <param name="array">array</param>
        /// <returns>minimum</returns>
        static int Max(int[] array)
        {
            //calcul minim
            if (array is null || array.Length == 0)
            {
                //nu pot calcula minim
                return int.MaxValue;
            }

            //pot calcula minimul
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;

        }

        static int IndexOf(int[] array, int element)
        {
            if (array is null || array.Length == 0)
            {
                return -1;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }

        static float Average(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                return -1;
            }

            float sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum / array.Length;
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

        static int[] ReadArray(string label)
        {
            int nr = ReadNumber("Array lenght: ", 0);
            int[] array = new int[nr];
            for (int i = 0; i < array.Length; i++)
            {
                int element = ReadNumber($"Element[{i}] is ", 0);
                array[i] = element;
            }

            return array;
        }

        static void PrintArray(string label, int[] array)
        {
            Console.WriteLine();
            string elementList = string.Join(", ", array);
            Console.WriteLine($"{label}= {elementList}");
        }

        static void MinOfArray(int[] array)
        {
            int prevNum;
            int minOfArray;

            minOfArray = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                prevNum = array[i];

                if (prevNum < minOfArray)
                {
                    minOfArray = prevNum;
                }
            }

            Console.Write($"Minimum of array is : {minOfArray}");
            Console.WriteLine();
        }

        static void MaxOfArray(int[] array)
        {
            int prevNum;
            int maxOfArray;

            maxOfArray = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                prevNum = array[i];

                if (prevNum > maxOfArray)
                {
                    maxOfArray = prevNum;
                }
            }

            Console.Write($"Maximum of array is : {maxOfArray}");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void IndexPosition(int[] array)
        {
            Console.Write("Find index position for number: ");
            string value = Console.ReadLine();
            int number = Convert.ToInt32(value);
            bool found = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (number == array[i])
                {
                    found = true;
                    Console.Write($"Number {number} found at index {i}.");
                    break;
                }
            }

            if (!found)
            {
                Console.Write("Number not found in array");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void ArrayAverageValue(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            Console.Write($"Average value of the array is {(double)sum / array.Length}");
            Console.WriteLine();
        }
    }
}