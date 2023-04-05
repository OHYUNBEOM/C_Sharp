using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace cs12_method
{
    class Calc
    {
        public static int plus(int a, int b)//static으로 선언해야 객체 생성없이도 바로 사용 가능
        { return a + b; }
        public  int minus(int a, int b) 
        { return a - b; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region <static 메소드>
            int result =Calc.plus(1, 2); 
            Console.WriteLine(result);
            int result1=new Calc().minus(1, 2);
            //static 없이 선언하였기에 객체를 생성하면서 클래스의 함수를 사용할 수 있음 
            Console.WriteLine(result1);
            #endregion

            #region <Call by reference>
            int x = 5;int y = 4;
            swap(ref x, ref y);//x,y가 가지고 있는 주소를 전달 즉 call by reference
            Console.WriteLine("x={0},y={1}", x,y);
            #endregion

            #region < out 매개변수 >
            int divid = 30;
            int divor = 2;

            int rem = 0;

            divide(divid, divor, out result, out rem);
            Console.WriteLine("몫 {0} 나머지 {1}", result, rem);

            #endregion

            #region < Params >
            Console.WriteLine(sum(1, 3, 5, 7, 9));
            #endregion
        }
        static void divide(int x, int y, out int val, out int rem)//원래 몫,나머지 함수 두개만드는데 이렇게하면 하나만 생성
        {
            val = x / y;
            rem = x % y;
        }
        //static void divide(int x, int y, ref int val, ref int rem)//원래 몫,나머지 함수 두개만드는데 이렇게하면 하나만 생성
        //{
        //    val = x / y;
        //    rem = x % y;
        //}
        //Main 메서드와 같은 레벨에 있는 메서드들은 전부 static이 되어야함(무조건)
        public static void swap(ref int a, ref int b)
        {
            int temp = 0;
            temp=a; 
            a=b; 
            b=temp;
        }

        public static int sum(params int[] args)
        {
            int sum = 0;
            for(int i=0;i<args.Length; i++)
            {
                sum += args[i];
            }
            return sum;
        }
    }
}
