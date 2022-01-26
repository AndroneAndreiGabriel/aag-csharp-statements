using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopAccessLevels.Library
{
    public class Ultrabook  : Laptop
    {
        public void RunHighPerformanceTask()
        {
            // can be accessed because it's interal
            PlugIn();

            // can be accessed because we're in a child class
            int initialFrequency = processorFrequency;
            processorFrequency = 2000;
            Console.WriteLine($"Boost processor frequency to {processorFrequency}");
            Console.WriteLine("Running high performance task");
            processorFrequency = initialFrequency;
        }
    }
}
