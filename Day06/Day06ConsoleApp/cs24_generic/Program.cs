using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs24_generic
{
    #region< 일반화 클래스 >
    class MyArray<T> where T : class //where T : class 사용할 타입은 무조건 클래스 타입
    {
        T[] array;
    }
    #endregion
    internal class Program
    {
        #region< 일반화 메서드 >
        // Generic , 일반화
        static void CopyArray<T>(T[] source, T[] target)
            //T로 선언하면 모든 자료형 다 받을 수 있음
        {
            for(var i=0; i<source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        #endregion
        static void Main(string[] args)
        {
            #region< 일반화 >
            int[] source = { 2, 4, 6, 8, 10 };
            int[] target = new int[source.Length];

            CopyArray(source, target);//복사
            foreach(var item in target)
            {
                Console.WriteLine(item);
            }
            #endregion
            Console.WriteLine("일반화 컬렉션");
            //일반화 컬렉션
            List<int> list = new List<int>();
            for(var i =10; i>0; i--)
            {
                list.Add(i);
            }
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            list.RemoveAt(3);//7 삭제
            Console.WriteLine("3번째 인덱스 값 삭제");
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            //일반화 Stack
            Stack<float> stFloats = new Stack<float>();
            stFloats.Push(3.15f);
            stFloats.Push(9.99f);
            while(stFloats.Count > 0)
            {
                Console.WriteLine(stFloats.Pop());//스택 구조대로 Pop됨
            }
            //일반화 Queue
            Queue<string> qStrings = new Queue<string>();
            qStrings.Enqueue("Hello");
            qStrings.Enqueue("World");
            while(qStrings.Count > 0)
            {
                Console.WriteLine(qStrings.Dequeue());
            }
            //일반화 Dictionary
            Dictionary<string,int>dicNumbers = new Dictionary<string,int>();
            dicNumbers["일"] = 1;
            dicNumbers["이"] = 2;
            dicNumbers["삼"] = 3;
            dicNumbers["사"] = 4;
            Console.WriteLine(dicNumbers["삼"]);
        }
    }
}
