using System;

namespace Lab07AssignArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Citire array
            //int[] array = ReadArray("Array");

            int[] array = { 5, 7, 3, 1 };

            PrintArray("Array (sorted)=", array);

            // Parcurgere mare => array.Length, la fiecare pas aducem minimul pe pozitia curenta

            // 1) index = 0
            // Pe poz index = 0 trebuie sa aduc min din subsirul de la index = 1 -> capat
            //  j = (index + 1) -> array.Length
            //      (index = 0, j = 1) : compar 5 cu 7 - OK
            //      (index = 0, j = 2) : compar 5 cu 1 - NU E OK => swap
            //                           array = { 1, 7, 5, 3 }
            //      (index = 0, j = 3) : compar 1 cu 3 - OK

            // 2) Index = 1 array = { 1, 7, 5, 3 }
            // Pe poz index = 1 trebuie sa aduc min din subsirul de la index = 2 -> capat
            // j = (index + 1) -> array.Length
            //     (index = 1, j = 2) : compar 7 cu 5 => NU E OK => swap
            //                          array = { 1, 5, 7, 3 }
            //     (index = 1, j = 3) : compar 5 cu 3 => NU E OK => swap
            //                          array = { 1, 3, 7, 5 }

            // 3) Index = 2 array = { 1, 3, 7, 5 }
            //    (index = 2, j = 3) : compar 7 cu 5 => NU E OK => swap
            //                         array = { 1, 3, 5, 7}

            PrintArray("Array ", array);

            int[] sortedArrayAsc = BubbleSort(array, SortOrder.Ascending);
            //Console.WriteLine(object.ReferenceEquals(array, sortedArrayAsc));

            int[] sortedArrayDesc = BubbleSort(array, SortOrder.Descending);
            //Console.WriteLine(object.ReferenceEquals(array, sortedArrayDesc));
            //Console.WriteLine(object.ReferenceEquals(sortedArrayAsc, sortedArrayDesc));

            PrintArray("Ascending ", sortedArrayAsc);
            PrintArray("Descending ", sortedArrayDesc);

            //PrintSortedArray(array);
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

        static OrderOfSorting ReadSortingOrder(string label, OrderOfSorting defaultValue)
        {
            Console.Write(label);
            string value = Console.ReadLine();

            if (Enum.TryParse(typeof(OrderOfSorting), value, true, out object result))
            {
                return (OrderOfSorting)result;
            }

            return defaultValue;
        }

        static void PrintArray(string label, int[] array)
        {
            Console.WriteLine();
            string elementList = string.Join(", ", array);
            Console.WriteLine($"{label}= {elementList}");
        }

        public enum OrderOfSorting
        {
            Ascending,
            Descending
        }

        static void PrintSortedArray(int[] array)
        {
            OrderOfSorting sortOrder = ReadSortingOrder("Choose sorting order ascending/descending: ", OrderOfSorting.Ascending);

            int temp;
            string elementList = "";

            //ascending order
            if (sortOrder == OrderOfSorting.Ascending)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < array.Length; i++)
                {
                    elementList = string.Join(", ", array);
                }

                Console.WriteLine($"Ascending sorting: {elementList}");
            }
            //Descending order
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] < array[j])
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }

                for (int i = 0; i < array.Length; i++)
                {
                    elementList = string.Join(", ", array);
                }

                Console.WriteLine($"Descending sorting: {elementList}");
            }
        }

        static int[] BubbleSort(int[] array, SortOrder sortOrder)
        {
            int[] result = Clone(array);

            bool weHadSwaps;
            do
            {
                weHadSwaps = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    bool areElementsInCorrectOrder = true;
                    switch(sortOrder)
                    {
                        case SortOrder.Descending:
                            areElementsInCorrectOrder = result[i] > result[i + 1];
                            break;

                        case SortOrder.Ascending:
                        default:
                            areElementsInCorrectOrder = result[i] < result[i + 1];
                            break;
                    }

                    if (!areElementsInCorrectOrder)
                    { 
                        int temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;

                        weHadSwaps = true;
                        break;
                    }
                }
            }
            while (weHadSwaps);

            return result;
        }
        public enum SortOrder
        {
            Ascending = 0,
            Descending
        }

        static int[] Clone(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                return new int[0];
            }

            int[] clone = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                clone[i] = array[i];
            }
            return clone;
        }

        static int[] SelectionSort(int[] array, SortOrder sortOrder)
        {

            int[] result = Clone(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                //sa aduc pe array[i] minimul din subsirul de la array[i+1] => capat
                for (int j = i + 1; j < array.Length; j++)
                {
                    bool areElementsInCorrectOrder = true;
                    switch (sortOrder)
                    {
                        case SortOrder.Descending:
                            areElementsInCorrectOrder = result[i] > result[i + 1];
                            break;

                        case SortOrder.Ascending:
                        default:
                            areElementsInCorrectOrder = result[i] < result[i + 1];
                            break;
                    }

                    if (!areElementsInCorrectOrder)
                    {
                        //swap array[i] = array[j];
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
}


}