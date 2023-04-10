using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs21_property
{
    class Boiler
    {
        private int temp;
        #region<property>
        public int Temp
        {
            get { return temp; }
            set 
            { 
                if(value<=10 || value>=70)
                {
                    temp = 10; // default
                }
                else
                {
                    temp = value;
                }
            }
        }
        #endregion
        //get;set , SetTemp,GetTemp 비교
        #region<GetTemp,SetTemp 메서드 선언>
        //public void SetTemp(int temp)
        //{
        //    if (temp <= 10 || temp >= 70)
        //    {
        //        Console.WriteLine("수온이 너무 낮거나 높음");
        //    }
        //    else
        //    {
        //        this.temp = temp;
        //    }
        //}
        //public int GetTemp() { return this.temp; }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler boiler = new Boiler();
            boiler.Temp = 5000;
            Console.WriteLine(boiler.Temp); //온도 범위 넘어가기에 기본 온도 10도 출력
        }
    }
}
