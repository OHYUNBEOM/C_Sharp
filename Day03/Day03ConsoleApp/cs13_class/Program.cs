using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs13_class
{
    class cat // Class는 private이라도 cs13_class라는 namespace 내에서 접근 가능함
              // 내부 멤버변수 , 멤버메서드는 그렇지 않아서 public 등 접근 권한 명시해야함
    {
        #region<생성자>
        public cat()
        {
            name = string.Empty;
            color = string.Empty;
            age = 0;
        }
        public cat(string _name,string _color, sbyte _age)
        {
            name = _name;
            color = _color;
            age = _age;
        }
        #endregion
        #region<멤버변수 - 속성>
        public string name; // 고양이 이름
        public string color; // 고양이 색
        public sbyte age; // 고양이 나이 sbyte : 0~255
        #endregion
        #region<멤버메서드 - 기능>
        public void meow()
        {
            Console.WriteLine("{0} 야옹", name);
        }
        public void run()
        {
            Console.WriteLine("{0} 달림",name);
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //객체 생성 후 초기화
            cat kitty = new cat();
            kitty.color = "하얀색";
            kitty.name = "키티";
            kitty.age = 3;
            kitty.meow();
            kitty.run();
            Console.WriteLine("{0} : {1} / {2}살", kitty.name, kitty.color,kitty.age);
            Console.WriteLine();
            //객체 생성과 동시에 초기화
            cat nero = new cat() {name="네로",color="검은색",age=5};
            nero.meow();
            nero.run();
            Console.WriteLine("{0} : {1} / {2}살", nero.name, nero.color, nero.age);
            Console.WriteLine();
            //생성자를 통해 초기화
            cat catt=new cat("무명이","무색",10);
            catt.meow();
            catt.run();
            Console.WriteLine("{0} : {1} / {2}살", catt.name, catt.color, catt.age);
        }
    }
}
