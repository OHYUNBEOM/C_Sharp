using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs14_deepcopy
{
    class someclass
    {
        public int somefield1;
        public int somefield2;

        public someclass deepcopy()
        {
            someclass newcopy=new someclass();
            newcopy.somefield1 = this.somefield1;
            newcopy.somefield2=this.somefield2;
            
            return newcopy;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("얕은 복사");
            someclass source = new someclass(); 
            source.somefield1 = 100;
            source.somefield2 = 200;

            someclass target = source;//target에 source 복사
            target.somefield2 = 300;

            Console.WriteLine("s.somefield1=>{0} / s.somefield2=>{1}",
                source.somefield1,source.somefield2 );
            Console.WriteLine("t.somefield1=>{0} / t.somefield2=>{1}",
                target.somefield1, target.somefield2);

            Console.WriteLine("깊은 복사");
            someclass s = new someclass();
            s.somefield1 = 100;
            s.somefield2 = 200;

            someclass t = s.deepcopy(); //깊은복사
            t.somefield2 = 300;
            Console.WriteLine("s.somefield1=>{0} / s.somefield2=>{1}",
                s.somefield1, s.somefield2);
            Console.WriteLine("t.somefield1=>{0} / t.somefield2=>{1}",
                t.somefield1, t.somefield2);
        }
    }
}
