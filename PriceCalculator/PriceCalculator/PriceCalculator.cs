using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    public static class PriceCalculator
    {
        
        public static decimal CalculatePrice(
                string name, 
                decimal price, 
                int quantity = 1, 
                decimal vatPercent = 19)
        {
            return quantity * price * (100 + vatPercent / 100);
        }
    }
}
