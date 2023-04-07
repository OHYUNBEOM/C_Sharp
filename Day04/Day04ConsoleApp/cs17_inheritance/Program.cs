using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs17_inheritance
{
    //부모클래스
    class parent
    {
        public string name;
        public parent(string name )
        {
            this.name = name;
            Console.WriteLine("{0} from 부모생성자",name);
        }
        public void parentmethod()
        {
            Console.WriteLine("{0} from 부모메서드", name);
        }
    }
    //자식클래스
    class child:parent
    {
        public child(string name):base(name)//부모생성자 먼저 실행한 뒤 자식 생성자 실행
        {
            Console.WriteLine("{0} from 자식생성자", name);
        }
        public void childmethod()
        {
            Console.WriteLine("{0} from 자식메서드", name);
        }
    }

    // 클래스간 형변환
    class mammal
    {
        public void nurse()
        {
            Console.WriteLine("포유류 기르다");
        }
    }
    class dogs:mammal
    {
        public void bark()
        {
            Console.WriteLine("왈왈");
        }
    }
    class cats:mammal
    {
        public void meow()
        {
            Console.WriteLine("야옹");
        }
    }
    class elephant:mammal
    {
        public void poo()
        {
            Console.WriteLine("뿌우");
        }
    }
    class zookeeper
    {
        public void wash(mammal mam) 
        {
            if(mam is elephant)
            {
                var animal = mam as elephant;
                Console.WriteLine("코끼리 wash");
                animal.poo();
            }
            else if(mam is dogs)
            {
                var animal = mam as dogs;
                Console.WriteLine("강아지 wash");
                animal.bark();
            }
            else if (mam is cats)
            {
                var animal = mam as cats;
                Console.WriteLine("고양이 wash");
                animal.meow();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region<기본상속>
            parent p = new parent("Parent");
            p.parentmethod();

            child c = new child("Child");
            //c.parentmethod();
            c.childmethod();
            #endregion

            #region<클래스간 형식변환>
            mammal mam = new dogs();//자식클래스가 부모클래스로 변환 가능
            mam.nurse();
            //mam.bark(); // 불가능
            if(mam is dogs)
            {
                dogs middog = mam as dogs; // 클래스 형변환
                middog.bark(); // 클래스 형변환 해줬기 때문에 bark 호출 가능
            }
            //dogs dog = new mammal();//부코믈래스가 자식클래스로 변환은 불가능

            dogs dog2 = new dogs();
            cats cat2 = new cats();
            elephant el2 = new elephant();

            zookeeper keeper = new zookeeper(); // zookeeper 클래스는 wash(부모클래스) 형태로 부모를 받아와서
            // keeper.wash(dogs,cats,elephant) 형태의 소스 문제없이 사용 가능
            keeper.wash(dog2);
            keeper.wash(cat2);
            keeper.wash(el2);

            #endregion
        }
    }
}
