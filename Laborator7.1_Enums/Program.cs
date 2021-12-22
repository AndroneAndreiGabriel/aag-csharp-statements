using System;

namespace Laborator7._1_Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DayOfWeek monday = DayOfWeek.Monday;
            Console.WriteLine((int)monday);
            Console.WriteLine(monday);*/

            string dayOfWeek = "Mondays";
            //bool isConvertible = Enum.TryParse(typeof(DayOfWeek), dayOfWeek, out object parseResult);

            bool isConvertible = Enum.TryParse(dayOfWeek, out DayOfWeek parsedResult);

            if (isConvertible)
            {
                DayOfWeek value = (DayOfWeek)parsedResult;
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine($"'{dayOfWeek}' cannot be converted to DayOfWeek");
            }
        }
    }
}
