using System;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal price1 = PriceCalculator.CalculatePrice(
                name: "Paine", 
                price: 3.5M);
            decimal price2 = PriceCalculator.CalculatePrice(
                name: "Apa", 
                price: 2M, 
                quantity: 5);
             
            decimal price3 = PriceCalculator.CalculatePrice(
                name: "Someting else", 
                price: 10.5M, 
                quantity: 2, 
                vatPercent: 21);

            Console.WriteLine("Hello World!");
        }
    }
}
