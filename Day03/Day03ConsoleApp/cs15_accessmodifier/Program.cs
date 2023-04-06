using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs15_accessmodifier
{
    class waterheater//class 기본 접근 한정자 internal 
    {
        protected int temp;
        public void settemp(int temp)
        {
            if(temp<-5||temp>40)
            {
                Console.WriteLine("범위 이탈");
                return;
            }
            this.temp = temp;
        }
        internal void turnonheater()
        {
            Console.WriteLine("보일러 가동 / 온도:{0}", temp);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            waterheater boiler = new waterheater();
            boiler.settemp(50);
            boiler.settemp(21);
            boiler.turnonheater();
        }
    }
}
