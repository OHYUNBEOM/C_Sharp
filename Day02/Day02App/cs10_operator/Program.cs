 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs10_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstval = 15;// 15 = 1111
            int secondval = firstval << 1; // 11110 = 16+8+4+2 = 30
            // 비트 연산 << 1 --> 이진수로 변경 후 왼쪽으로 한칸 민다
            Console.WriteLine(secondval);
            // 1111 & 1101 => 1101 / 15&13=>13
            // 1010 | 0101 => 1111 

            //Null 병합 연산자
            int? checkval = null;
            Console.WriteLine(checkval == null ? 0 : checkval);//3항연산자(null이면 checkval에 0대입
            Console.WriteLine(checkval ?? 0); // null병합연산자는 3항 연산자를 더 축소함

        }
    }
}
