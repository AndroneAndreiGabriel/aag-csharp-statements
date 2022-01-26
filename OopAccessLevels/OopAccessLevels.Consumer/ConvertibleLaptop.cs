using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OopAccessLevels.Library;

namespace OopAccessLevels.Consumer
{
    class ConvertibleLaptop : Laptop
    {
        public void DetachScreen()
        {
            // can be accesed because we're not in the same assembly, but it is protected internal
            PlugIn();
            processorFrequency = 1000;
            Console.WriteLine("Working with the screen as a tablet");
        }

        public void AttachScreen()
        {
            processorFrequency = 1700;
            Console.WriteLine("Working again like a laptop");
        }
    }
}
