using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs22_collection
{
    class MyList
    {
        int[] array;
        public MyList()
        {
            array = new int[3];
        }
        public int Length
        {
            get { return array.Length; }
        }
        public int this[int index]
        {
            get { return array[index]; }
            set 
            {
                if(index>=array.Length)//array의 배열 크기보다 커지면
                {
                    Array.Resize<int>(ref array, index + 1);
                    Console.WriteLine("MyList Resized : {0}", array.Length);
                }
                array[index] = value; // array에 value 값 넣기
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5];
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;
            array[3] = 4;
            array[4] = 5;//5칸이상 불가능
            //Console.WriteLine(array[5]);//IndexOutOfRangeException

            char[] oldString = new char[5];
            string curString = "";//문자열길이 제한없음

            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            // list는 제한 없음
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            //list에서 데이터 삭제
            list.Remove(5);
            list.RemoveAt(1);//1번째 -> 사용자가 보는 두번째 값
            Console.WriteLine("==데이터 삭제==");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //MyList
            MyList myList = new MyList();
            for(int i=1; i<=5; i++)
            {
                myList[i-1] = i * 5;//5,10,15,20,25
            }
            for(int i=0; i<myList.Length; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}
