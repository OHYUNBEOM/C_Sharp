using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs28_event
{
    //람다 식
    class sample
    {
        private int valueA;
        public int ValueA
        {
            //get {return valueA;}
            //set {valueA=value;}
            get => ValueA;
            set => ValueA = value;
        }
    }
    // 1.대리자 생성
    delegate void EventHandler(string message);
    class CustomNotifier
    {
        // 2.이벤트 준비(대리자)
        public event EventHandler SomethingChanged;
        public void DoSomething(int number)
        {
            int temp = number % 10;
            if(temp!=0 && temp%3==0)
            {
                // 3.이벤트 발생 상황에서 이벤트 수행
                SomethingChanged(string.Format("{0} : odd", number));
            }
        }
    }
    internal class Program
    {
        // 4.이벤트가 대신 호출할 메서드
        static void CustomHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            CustomNotifier notifier = new CustomNotifier();
            notifier.SomethingChanged += new EventHandler(CustomHandler);
            for(int i=0; i<=30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
