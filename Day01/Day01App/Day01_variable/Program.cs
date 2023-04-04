using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01_variable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte bdata = byte.MaxValue;//byte의 MaxValue
            Console.WriteLine(bdata);

            bdata=byte.MinValue;//byte의 MinValue
            Console.WriteLine(bdata);

            long ldata=long.MaxValue;//long의 MaxValue 
            Console.WriteLine(ldata);
            long rdata=long.MinValue;//long의 MinValue
            Console.WriteLine(rdata);

            ldata--;
            Console.WriteLine(ldata);

            int binval = 0b11111111;//2진수
            Console.WriteLine(binval);

            int hexval = 0xFF;
            Console.WriteLine(hexval); 

            float fdata=float.MaxValue;
            Console.WriteLine(fdata);
            fdata = float.MinValue;
            Console.WriteLine(fdata);

            double ddata=double.MaxValue;
            Console.WriteLine(ddata);
        }
    }
}
