using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs29_filehandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string curDirectory = @"C:\Temp";//현재 디렉토리(상대경로) / ..:부모
            Console.WriteLine("현재 디렉토리 정보");

            var dirs = Directory.GetDirectories(curDirectory);
            foreach (var dir in dirs)
            {
                var dirInfo=new DirectoryInfo(dir);
                
                Console.Write(dirInfo.Name);
                Console.WriteLine(" [{0}]",dirInfo.Attributes);
            }

            Console.WriteLine("\n현재 디렉토리 파일정보");
            var files = Directory.GetFiles(curDirectory);
            foreach(var file in files)
            {
                var fileInfo = new FileInfo(file);
                Console.WriteLine(fileInfo.Name);
                Console.WriteLine(" [{0}]",fileInfo.Attributes);
            }

            // 특정 경로 하위폴더/  하위파일 조회
            string path = @"C:\Temp\Csharp_Bank";//생성할 폴더
            string sfile = "Test.log";//생성할 파일

            if (Directory.Exists(path))
            {
                Console.WriteLine("경로 존재, 파일 생성");
                File.Create(path + @"\" + sfile); // C:\Temp\Csharp_Bank\Test.log
            }
            else // 실행 후 C:\Temp로 가보면 Csharp_Bank 폴더 생성, Test.log 파일 생성
            {
                //Console.WriteLine("{path} 해당 경로 없음", path);
                Console.WriteLine($"{path} 해당 경로 없음");//45행과 같은 의미, 매우 간결해짐
                Directory.CreateDirectory(path);

                Console.WriteLine("경로 생성, 파일 생성");
                File.Create(path + @"\" + sfile);
            }
        }
    }
}
