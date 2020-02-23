using System;
using System.Collections.Generic;
using System.IO;

namespace CloudSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //白云
            //var basePath = "D:\\documents\\Cloud";
            //new CloudCreator().CreateDiretory(0, basePath);
            var path = "C:\\Users\\yaoyilian\\Desktop\\android_26b80197228dba92287fc89eb99c1884.7z";
            var newPath = new CloudCreator().copyTo(path, "android_26b80197228dba92287fc89eb99c1884.7z");
            //Console.WriteLine(newPath);
            Console.ReadKey();
        }
    }


    public class CloudCreator
    {
        public List<string> DirectoryName = new List<string> { "白云", "白云深处", "云深不知处", "某个小角落" };

        public void CreateDiretory(int i, string basePath)
        {
            if(i < DirectoryName.Count)
            {
                for(var j = 1; j <= 50; j++)
                {
                    var path = $"{basePath}\\{ DirectoryName[i] }{j}";
                    Directory.CreateDirectory(path);
                    CreateDiretory(i + 1, path);
                }
            }
            return;
        }

        public string copyTo(string path, string fileName)
        {
            var radom = new Random();
            var i = radom.Next(1,50);
            var newPath = $"D:\\documents\\慕容&云海\\白云{i}\\白云深处{i}\\云深不知处{i}\\某个小角落{i}\\{fileName}";
            FileInfo file = new FileInfo(path);
            file.CopyTo(newPath);
            return newPath;
        }
    }
}
