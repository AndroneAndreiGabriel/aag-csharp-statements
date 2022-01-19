using System;

namespace Lab08Exercices
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[,] matrix1 = ReadMatrix("Matrix1");
            PrintMatrix("Matricea1 este:", matrix1);

            int[,] matrix2 = ReadMatrix("Matrix2");
            PrintMatrix("Matricea2 este:", matrix2);

            int[,] sum = SumMatrix(matrix1, matrix2);
            PrintMatrix("Sum = ", sum);

            int[] mainDiagonal = MatrixMainDiagonal(sum);
            PrintArray("Main diagonal", mainDiagonal);

            int[,] prod = ProductMatrix(matrix1, matrix2);
            PrintMatrix("Produsul este", prod);

            int[][] jaggedArray = ReadJaggedArray("Jagged array");
            PrintJaggedArray("Jagged array is: ", jaggedArray);

            int[] set1 = { 1, 2, 3 };
            int[] set2 = { 7, 8, 9 };

            int[][] cartesian = CartesianProduct(set1, set2);
            PrintJaggedArray("ProdusCartesian", cartesian);*/

            int[] set3 = { 1, 2, 3, 1, 5, 7, 1, 3 };
            int[] freq = { 3, 1, 2, 3, 1, 1, 3, 2 };
            int[][] set3WithFreq = ElementsWithFrequencies(set3);
            PrintJaggedArray("Element and Frequencies", set3WithFreq);

        }

        static void PrintArray(string label, int[] array)
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

        static int[,] ReadMatrix(string label)
        {
            Console.WriteLine(label);
            int rowsCount = ReadNumber("Rows Count= ", 0);
            int colsCount = ReadNumber("Cols Count= ", 0);
            int[,] matrix = new int[rowsCount, colsCount];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int element = ReadNumber($"Element[{i},{j}]=", 0);
                    matrix[i, j] = element;
                }
            }

            return matrix;
        }

        static void PrintMatrix(string label, int [,] matrix)
        {
            Console.WriteLine();
            Console.WriteLine($"{label}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j], 6}");
                }

                Console.WriteLine();
            }

            
        }

        static int[,] SumMatrix(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 is null || matrix2 is null)
            {
                return new int[0, 0];
            }

            bool haveSameDimensions =
                matrix1.GetLength(0) == matrix2.GetLength(0) &&
                matrix1.GetLength(1) == matrix2.GetLength(1);

            if (!haveSameDimensions)
            {
                return new int[0, 0];
            }

            int[,] sum = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    sum[i,j] = matrix1[i,j] + matrix2[i,j];
                }
            }

            return sum;
        }

        static int[] MatrixMainDiagonal(int[,] matrix)
        {
            if (matrix is null)
            {
                return new int[0];
            }

            int minRowsCols = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
            int[] diagonal = new int[minRowsCols];

            for (int i = 0; i < minRowsCols; i++)
            {
                diagonal[i] = matrix[i, i];
            }

            return diagonal;
        }

        static int[,] ProductMatrix(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 is null || matrix2 is null)
            {
                return new int[0, 0];
            }

            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);

            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);

            bool areDimensionsOk = cols1 == rows2;

            if (!areDimensionsOk)
            {
                return new int[0, 0];
            }

            int[,] product = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }

                    product[i, j] = sum;
                }
            }

            return product;
        }

        static int[][] ReadJaggedArray(string label)
        {
            Console.WriteLine(label);
            int count = ReadNumber("Count= ", 0);
            
            int[][] array = new int[count][];

            for (int i = 0; i < count; i++)
            {
                int[] element = ReadArray($"Element[{i}]");
                array[i] = element;
            }

            return array;
        }

        static void PrintJaggedArray(string label, int[][] array)
        {
            Console.WriteLine();
            Console.WriteLine($"{label}");

            if (array is not null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int[] element = array[i];
                    Console.Write($"Element [{i}][]=");

                    if (element is not null)
                    {
                        Console.Write(string.Join(",", element));
                    }

                    Console.WriteLine();
                }
            }
        }

        static int[] ReadArray(string label)
        {
            Console.WriteLine(label);
            int nr = ReadNumber("Elements Count=", 0);
            int[] array = new int[nr];
            for (int i = 0; i < array.Length; i++)
            {
                int element = ReadNumber($"Element[{i}]=", 0);
                array[i] = element;
            }

            return array;
        }

        static int[][] CartesianProduct(int[] set1, int[] set2)
        {
            if (set1 is null || set2 is null)
            {
                return new int[0][];
            }

            int[][] result = new int[set1.Length * set2.Length][];
            for (int i = 0, idxResult = 0; i < set1.Length; i++)
            {
                //for (int j = 0; j < set2.Length; j++, idxResult++)
                for (int j = 0; j < set2.Length; j++, idxResult++)
                {
                    //or
                    //idxResult = i * set2.Lenght + j;
                    result[idxResult] = new int[] { set1[i], set2[j] };
                }
            }

            return result;
        }

        static int[][] ElementsWithFrequencies(int[] array)
        {
            if (array is null)
            {
                return new int[0][];
            }

            int[][] elementsWithFrequencies = new int[array.Length][];

            for (int i = 0; i < array.Length; i++)
            {
                int element = array[i];
                int count = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (element == array[j])
                    {
                        count++;
                    }
                }

                elementsWithFrequencies[i] = new int[] { element, count };
            }

            return elementsWithFrequencies;
        }
    }
}
