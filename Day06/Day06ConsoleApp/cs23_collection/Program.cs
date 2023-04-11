using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs23_collection
{
    class CustomEnumerator
    {
        int[] list = { 1, 3, 5, 7, 9 };
        public IEnumerator GetEnumerator()
        {
            yield return list[0];//메서드를 빠져나가지 않고 값만 돌려줌
            yield return list[1];
            yield return list[2];
            yield return list[3];
            yield break;
        }
    }
    class MyArrayList : IEnumerator,IEnumerable
    {
        int[] array;
        int position = -1;

        public MyArrayList()
        {
            array = new int[3]; //기본크기 3
        }
        public int this[int index]
        {
            get { return array[index]; }
            set
            {
                if(index>=array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine("MyArrayList Resize : {0}", array.Length); //개발 완료 후 주석처리
                }
                array[index] = value;
            }
        }
        #region< IEnumerable 인터페이스 구현 >
        public IEnumerator GetEnumerator()
        {
            for(var i=0; i<array.Length; i++)
            {
                yield return array[i];
            }
        }
        #endregion

        #region < IEnumerator 인터페이스 구현>
        public object Current
        {
            get
            {
                return array[position];
            }
        }

        public bool MoveNext()
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }
            position++;
            return(position<array.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new CustomEnumerator();
            foreach(var item in obj)
            {
                Console.WriteLine(item);
            }
            var myArrayList = new MyArrayList();
            for(var i=0; i<=5; i++)
            {
                myArrayList[i] = i;
            }
            foreach(var item in  myArrayList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
