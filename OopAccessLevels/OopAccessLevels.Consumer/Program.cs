using System;
using OopAccessLevels.Library;

namespace OopAccessLevels.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop l = new Laptop();
            l.PrintSpecifications();

            Refrigerator r = new Refrigerator();
            r.KeepBeerCold();

            Ultrabook ultraBook = new Ultrabook();
            ultraBook.PrintSpecifications();
            ultraBook.RunHighPerformanceTask();

            ConvertibleLaptop convertible = new ConvertibleLaptop();
            convertible.PrintSpecifications();
            convertible.DetachScreen();
            convertible.AttachScreen();
        }
    }
}
