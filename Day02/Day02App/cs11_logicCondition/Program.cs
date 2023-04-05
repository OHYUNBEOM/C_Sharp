using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cs11_logicCondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region<IF>
            int a = 20;
            if (a == 20)
            {
                Console.WriteLine("20");
            }
            else
            {
                Console.WriteLine("20아님");
            }

            object obj = null;
            string inputs=Console.ReadLine(); // 콘솔에서 입력
            if(int.TryParse(inputs,out int ioutput))// 예외가 발생하면 0
            {
                obj= ioutput; // 입력한 값이 정수라서 문자열을 정수로 변환
            }
            else if(float.TryParse(inputs,out float foutput))
            {
                obj= foutput; // 입력값이 실수라서 문자열을 실수로 변환
            }
            else
            {
                obj = inputs;//이도저도 아니다
            }
            #endregion

            #region<Switch>
            switch (obj)
            {
                case int i://정수라면
                    Console.WriteLine("{0}는 int 형식",i);
                    break;
                case float f://실수라면
                    Console.WriteLine("{0}는 float 형식",f);
                    break;
                case string s://문자열이면
                    Console.WriteLine("{0}는 string 형식", s);
                    break;
                default:
                    Console.WriteLine("그 외");
                    break;
            }
            #endregion

            #region <2중 For문>
            for(int i=2; i<10; i++)
            {
                for(int j=1; j<10; j++)
                {
                    Console.WriteLine("{0} X {1} = {2}", i, j, i * j);
                }
            }
            #endregion

            #region <Foreach>
            int[] ary = { 2, 4, 6, 8, 10 };
            foreach(int i in ary)
            {
                Console.WriteLine("{0}*2 = {1}", i, i*2); 
            }
            //위아래 완전 동일
            for(int i=0; i<ary.Length; i++)
            {
                Console.WriteLine("{0}*2 = {1}", ary[i], ary[i] * 2);
            }
            #endregion
        }
    }
}
