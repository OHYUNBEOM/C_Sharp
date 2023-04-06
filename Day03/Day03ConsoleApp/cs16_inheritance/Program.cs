using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs16_inheritance
{
    class Base//기반 또는 부모 클래스
    {
        protected string name;
        private string color;
        public int age;

        public Base(string name, string color, int age)        
        {
            this.name = name;
            this.color = color;
            this.age = age;
            Console.WriteLine("{0}.Base()",name);
        }
        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()",name);
        }
        public string GetColor()//동일 클래스 내에 private으로 선언한 color에 접근 가능
        {
            return color;
        }
    }
    class Child:Base // 상속 시 protected / public 으로 선언된 멤버 변수는 접근가능, private은 불가능
    {
        public Child(string name, string color, int age) : base(name, color, age)
        {
            Console.WriteLine("{0}.Child()", name);
        }
        public void ChildMethod()
        {
            Console.WriteLine("{0}.ChildMethod()", name);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base("부모", "Blue", 15);
            b.BaseMethod();

            Child c = new Child("자식", "Green", 16);
            c.BaseMethod();
            c.ChildMethod();
        }
    }
}
