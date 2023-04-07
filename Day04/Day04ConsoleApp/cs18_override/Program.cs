using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace cs18_override
{
    class armorsuite
    {
        public virtual void init()
        {
            Console.WriteLine("기본 아머슈트");
        }
    }
    class ironman:armorsuite
    {
        public override void init()
        {
            base.init();
            Console.WriteLine("리펄서 빔");
        }
    }
    class warmachine:armorsuite
    {
        public override void init()
        {
            base.init();
            Console.WriteLine("미니건");
            Console.WriteLine("돌격소총");
        }
    }
    class parent
    {
        public void currentmethod()
        {
            Console.WriteLine("부모클래스 메서드");
        }
    }
    class child:parent
    {
        public new void currentmethod()
        {
            Console.WriteLine("자식클래스 메서드");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("아머슈트 생산");
            armorsuite suite = new armorsuite();
            suite.init();

            Console.WriteLine("워머신 생산");
            warmachine machine = new warmachine();
            machine.init();

            Console.WriteLine("아이언맨 생산");
            ironman iron = new ironman();
            iron.init();

            parent par = new parent();
            par.currentmethod();

            child chd = new child();
            chd.currentmethod();
        }
    }
}
