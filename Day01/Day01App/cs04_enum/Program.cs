using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_enum
{
    internal class Program
    {
        enum HomeTown
        {
            SEOUL=1,
            DAEJEON=2,
            DAEGU=3,
            BUSAN=4,
            JEJU=5
        }
        static void Main(string[] args)
        {
            HomeTown my;
            my = HomeTown.BUSAN;
            if (my == HomeTown.SEOUL)
            {
                Console.WriteLine("서울출신이네요ㅋㅋ");
            }
            else if (my == HomeTown.DAEGU)
            {
                Console.WriteLine("대구출신이네요ㅋㅋ");
            }
            else if (my == HomeTown.BUSAN)
            {
                Console.WriteLine("부산출신이네요ㅋㅋ");
            }
            else if(my == HomeTown.JEJU)
            {
                Console.WriteLine("제주출신이네요ㅋㅋ");
            }
            else
            {
                Console.WriteLine("대전출신이네요ㅋㅋ");
            }
        }
    }
}
