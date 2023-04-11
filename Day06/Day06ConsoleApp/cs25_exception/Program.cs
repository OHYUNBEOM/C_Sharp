using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs25_exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3 };
            try
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally// 보통 file 객체 close , DB 연결 종료 , 네트워크 소켓 닫을 떄 주로 사용
            {   //예외가 발생하더라도 무조건 처리해야하는 로직
                Console.WriteLine("계속 진행");
            }

            #region<예외 던지기>
            try
            {
                DivideTest(array[2], 0);
            }
            catch(Exception e)//메서드를 호출 했는데 0으로 나누는 예외가 발생하여
            {   //49행의 throw를 통해 던진 오류문을 받아오고
                Console.WriteLine(e.Message);//출력함
            }
            #endregion
        }
        private static void DivideTest(int v1, int v2)
        {
            try
            {
                Console.WriteLine(v1 / v2);
            }
            catch(Exception)//DivideTest 메서드 수행 시 오류발생하면 오류를 던짐
            {
                throw new Exception("DivideTest 메서드에서 예외 발생");
            }
        }
    }
}
