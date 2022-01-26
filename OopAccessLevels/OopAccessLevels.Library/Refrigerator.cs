using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopAccessLevels.Library
{
    public class Refrigerator
    {
        private string energyClass = "A++";

        public void KeepBeerCold()
        {
            Console.WriteLine("Beer is kept cold in a {energyClass} refrigerator");

            Console.WriteLine("In a meanwhile coding on a laptop...");
            //but can't use Laptop's processor frequency
            Laptop l = new Laptop();
            // can be accessed because it's internal
            l.PlugIn();
            l.PrintSpecifications();
        }
    }
}
