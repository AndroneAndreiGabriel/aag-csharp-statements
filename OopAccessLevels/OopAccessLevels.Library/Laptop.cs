using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopAccessLevels.Library
{
    public class Laptop
    {
        private string processorName = "Intel i7";
        protected int processorFrequency = 1700;
        public void PrintSpecifications()
        {
            Console.WriteLine("Specs:");
            Console.WriteLine($"   - Processor: {processorName}");
        }

        protected internal void PlugIn()
        {
            Console.WriteLine("Plugging in the laptop");
        }
    }
}
