using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cs09_nullcondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Foo myfoo = null; // 객체 생성
            //int? bar; // null 
            //if (myfoo != null)
            //{
            //    bar = myfoo.member;
            //}
            //else
            //{
            //    bar= null;
            //}
            //위의 아홉줄(주석부분)을 모두 축약시킴
            int? bar = myfoo?.member; // myfoo가 null이 아니면 member을 할당하라는 뜻
        }
    }
    class Foo
    {
        public int member;
    }
}
