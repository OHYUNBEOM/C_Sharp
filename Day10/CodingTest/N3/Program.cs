using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace N3
{
    class car
    {
        public string Name { get; set; }
        public string Maker { get; set; }
        public string Color { get; set; }
        public int YearMode { get; set; }
        public int MaxSpeed { get; set; }
        public string UniqueNumber { get; set; }
        public void Start()
        {
            Console.WriteLine($"{this.Name}의 시동을 겁니다");
        }
        public void Acclerate()
        {
            Console.WriteLine("절대시속 220km/h로 가속합니다");
        }
        public void TurnRight()
        {
            Console.WriteLine($"{this.Name}을 우회전합니다");
        }
        public void Break()
        {
            Console.WriteLine($"{this.Name}의 브레이크를 밟습니다");
        }
    }
    class ElectricCar : car
    {
        public virtual void Recharge()
        {
            //HybridCar에서 오버라이딩 할거라서 선언만함
        }
    }
    class HybridCar : ElectricCar
    {
        public override void Recharge()
        {
            base.Recharge();
            Console.WriteLine("달리면서 배터리를 충전합니다");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HybridCar ioniq = new HybridCar();
            ioniq.Name = "아이오닉";
            ioniq.Maker = "현대자동차";
            ioniq.Color = "White";
            ioniq.YearMode = 2018;
            ioniq.MaxSpeed = 220;
            ioniq.UniqueNumber = "54라 3346";

            ioniq.Start();
            ioniq.Acclerate();
            ioniq.Recharge();
            ioniq.TurnRight();
            ioniq.Break();
        }
    }
}
