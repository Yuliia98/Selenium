using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        
        
        public class Car
        {
            public virtual void displayBrand()
            {
                Console.WriteLine("Base Class - I am Cars");
            }
        }

        public class Maruti : Car
        {
            public new void displayBrand()
            {
                Console.WriteLine("I am Maruti");
            }
        }

        static void Main(string[] args)
        {
            Car car = new Maruti();
            car.displayBrand();

            Console.ReadLine();
        }
    }
}
    

