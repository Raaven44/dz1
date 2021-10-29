using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    
   
    class Program
    {
        static void Main(string[] args)
        {
            
            Drobi d1 = new Drobi(2, 3);
            Drobi d2 = new Drobi(-2);
            Drobi d3 = new Drobi(2, 3, 4);
            Console.WriteLine(d1.ToDouble());
            Console.WriteLine((d1 * d3).ToDouble());
            Console.WriteLine((d1 + d2).ToDouble());
            Console.WriteLine((d1 - d2).ToDouble());
            Console.WriteLine((d1 / d2).ToDouble());
            Console.WriteLine((d1 * d2).Znak);
            d1.EventChangerCh += Method.MyMethodCh;
            d1.EventChangerZn += Method.MyMethodZn;
            d1.Ch = 15;
            d1.Zn = 3;
            Console.WriteLine(d1[0]);
            Console.WriteLine(d1[1]);
            Console.ReadKey();

        }
    }
}