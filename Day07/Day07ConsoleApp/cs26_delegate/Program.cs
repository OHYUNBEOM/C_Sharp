using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cs26_delegate
{
    #region<대리자선언>
    //대리자 사용 선언
    delegate int CalcDelegate(int a, int b);
    #endregion<대리자선언>
    delegate int Compare(int a, int b);
    #region<일반 클래스>
    class Calc
    {
        public int Plus(int a, int b)
        {
            return a + b;
        }
        //static으로 선언 시 실행과 동시에 메모리에 올라감
        public static int Minus(int a, int b)
        {
            return a - b;
        }
    }
    #endregion<일반 클래스>
    internal class Program
    {
        static void Main(string[] args)
        {
            #region<일반 클래스>
            Calc normalCalc = new Calc();
            int x = 10, y = 15;
            int res = normalCalc.Plus(x, y);
            Console.WriteLine(res);
            res = Calc.Minus(x, y);//Minus 메서드는 static이기에 바로 사용 가능
            Console.WriteLine(res);
            #endregion

            #region<대리자>
            Console.WriteLine("== 대리자 방식 ==");
            //대리자 사용 방식
            x = 30; y = 20;
            Calc delCalc = new Calc();
            CalcDelegate Callback;

            Callback = new CalcDelegate(delCalc.Plus);
            int res2 = Callback(x, y);
            Console.WriteLine(res2);

            Callback = new CalcDelegate(Calc.Minus);
            res2=Callback(x, y);
            Console.WriteLine(res2);
            #endregion
            
        }
    }
}
