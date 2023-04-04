using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs05_nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? a = null; // null값을 담을 수 없음 , 때문에 6.0 버전에서 나온 Nullable
            // 다음과 같이 자료형? 로 선언한 후에 null로 초기화 가능
            Console.WriteLine(a == null);

            int b = 0;
            Console.WriteLine(b == null);
            Console.WriteLine(b.GetType());
            // 값형식 byte,short,int,long,float,double,char등은 null을 할당하지 못함
            // null을 할당 할 수 있도록 만드는 방식이 type? 로 담을 수 있음

            float? c = null;
            Console.WriteLine(c.HasValue); // null 로 할당했기 때문에 값이 없다고 False출력
            c = 3.14f;
            Console.WriteLine(c.HasValue);
        }
    }
}
