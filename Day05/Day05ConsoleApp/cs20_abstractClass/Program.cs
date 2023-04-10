using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs20_abstractClass
{
    abstract class AbstractParent
    {
        protected void MethodA()
        {
            Console.WriteLine("AbstractParent.MethodA()");
        }
        public void MethodB() // 클래스와 동일
        {
            Console.WriteLine("AbstractParent.MethodB()");
        }
        public abstract void MethodC();// 선언만, 상속받는 곳에서 구현 해야함
    }
    class Child : AbstractParent
    {
        public override void MethodC()//추상 메서드 구현
        {
            Console.WriteLine("Child.MethodC()/Abstract Method");
            MethodA();//protected는 자식클래스 내에서는 사용 가능
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractParent parent = new Child();
            // parent.MethodA(); methodA가 protected이기에 접근 불가
            parent.MethodB();
            parent.MethodC();
        }
    }
}
