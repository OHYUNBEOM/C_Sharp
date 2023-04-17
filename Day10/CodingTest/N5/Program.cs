using N5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5
{
    public interface IAnimal
    {
        int Age { get; set; }
        String Name { get; set; }
        void Eat();
        void Sleep();
        void Sound();
    }
    public class Dog : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Eat()
        {
            Console.WriteLine($"{this.Name}이/가 먹습니다");
        }
        public void Sleep()
        {
            Console.WriteLine($"{this.Name}이/가 잡니다");
        }
        public void Sound()
        {
            Console.WriteLine($"{this.Name}이/가 짖습니다 멍멍");
        }
    }
    public class Cat : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Eat()
        {
            Console.WriteLine($"{this.Name}이/가 먹습니다");
        }
        public void Sleep()
        {
            Console.WriteLine($"{this.Name}이/가 잡니다");
        }
        public void Sound()
        {
            Console.WriteLine($"{this.Name}이/가 웁니다 야옹");
        }
    }
    public class Horse : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void Eat()
        {
            Console.WriteLine($"{this.Name}이/가 먹습니다");
        }
        public void Sleep()
        {
            Console.WriteLine($"{this.Name}이/가 잡니다");
        }
        public void Sound()
        {
            Console.WriteLine($"{this.Name}이/가 웁니다 이히힝");
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-- 강아지 객체 생성 --");
        Dog dog = new Dog { Name = "우리집강아지", Age = 1 };
        dog.Sleep();
        dog.Eat();
        dog.Sound();

        Console.WriteLine("\n-- 고양이 객체 생성 --");
        Cat cat = new Cat { Name = "우리집고양이", Age = 2 };
        cat.Sleep();
        cat.Eat();
        cat.Sound();

        Console.WriteLine("\n-- 말 객체 생성 --");
        Horse horse = new Horse { Name = "우리집말", Age = 3 };
        horse.Sleep();
        horse.Eat();
        horse.Sound();
    }
}
