using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs03_object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Object 형식
            //int == System.Int32
            //long == System.Int64
            long idata = 1024;
            Console.WriteLine(idata);
            Console.WriteLine(idata.GetType());

            object iobj = (object)idata;//박싱:데이터타입값을 object로 담는다
            Console.WriteLine(iobj);
            Console.WriteLine(iobj.GetType());

            long udata = (long)iobj;//언박싱 : object를 원래 데이터타입으로 바꾼다
            Console.WriteLine(udata);
            Console.WriteLine(udata.GetType());

            double ddata = 3.141592;
            object pobj = (object)ddata;
            double pdata = (double)pobj;

            Console.WriteLine(pobj);
            Console.WriteLine(pobj.GetType());
            Console.WriteLine(pdata);
            Console.WriteLine(pdata.GetType());

            short sdata = 32000;
            int indata = sdata;
            Console.WriteLine(indata);

            long lndata = long.MaxValue;
            Console.WriteLine(lndata);
            indata = (int)lndata;//overflow
            Console.WriteLine(indata);

            float fval = 3.141592f;
            Console.WriteLine("fval = "+fval);
            double dval = (double)fval;
            Console.WriteLine("dval = "+dval);

            // ! 실무에서 많이 사용 !
            int numival = 1024;
            string strival = numival.ToString();
            Console.WriteLine(strival);
            Console.WriteLine(numival);
            Console.WriteLine(numival.GetType()==strival.GetType());
            Console.WriteLine(strival.GetType());

            double numdval = 3.1415;
            string strdval = numdval.ToString();
            Console.WriteLine(strdval);

            //문자열을 숫자로
            //문자열 내 숫자가 아닌 다른 문자형태가 있는 경우 조심(.,/ 등등)
            string originstr = "3000000";
            int convval = Convert.ToInt32(originstr);
            Console.WriteLine(convval);

            originstr = "1.2345";
            float convfloat=float.Parse(originstr);
            Console.WriteLine(convfloat);
            // 예외발생하지 않도록 형변환 방법
            originstr = "123.0f";
            float ffval;
            float.TryParse(originstr, out ffval); // 예외 발생 x 숫자변환
            // Tryparse : 형변환 불가능하면 0으로 출력, 예외는 발생하지 않음
            Console.WriteLine(ffval);

            const double pi = 3.141592;
            Console.WriteLine(pi);
            //pi = 4.56; const 로 선언시에 상수 선언이기에 변수의 값 변경 불가
        }
    }
}
