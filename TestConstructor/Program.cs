using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConstructor
{
    class Program
    {
        class Blaat
        {
            public int x;
            /*
            public Blaat(int value)
            {
                x = value;
            }
            */

        }
        static void Main(string[] args)
        {
            var b = new Blaat();
            Console.WriteLine(b.x);
            Console.ReadKey();
        }
    }
}
