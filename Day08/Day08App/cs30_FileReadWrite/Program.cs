using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs30_FileReadWrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty;//텍스트 읽어와서 출력
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(@".\python.py");//스트림리더 파일 연결
                line=reader.ReadLine(); //한줄씩 읽음
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();//계속해서 다음줄 읽어옴
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message} 예외 발생");
            }
            finally//finally에 reader.close를 작성하여 반드시 종료
            {
                reader.Close();
            }

            // 파일 읽기 종료
            Console.WriteLine("\n==파일 읽기 종료==\n");

            StreamWriter writer = new StreamWriter(@".\pythonByCsharp.py");
            try
            {
                writer.WriteLine("import sys");
                writer.WriteLine();
                writer.WriteLine("print(sys.executable)");
            }
            catch(Exception e)
            {
                Console.WriteLine($"{e.Message} 예외 발생");
            }
            finally
            { writer.Close();}
            Console.WriteLine("파일 생성 완료");
        }
    }
}
