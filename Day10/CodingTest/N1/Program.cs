using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1
{
    public class Boiler
    {
        public string Brand { get; set; }
        public byte Voltage { get; set; }
        public int Temperature { get; set; }
        public void PrintAll()
        {
            Console.WriteLine($"Brand : {Brand} Voltage : {Voltage} Temperature : {Temperature}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler { Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            kitturami.PrintAll();
        }
    }
}
