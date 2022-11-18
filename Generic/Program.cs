using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student() { Name = "Darya", LastName = "Dalaei", Id = "123" };
               
            
            WriteOnFile<Student>(stu,"log","Student");

            Console.ReadKey();
        }
        
        public static void WriteOnFile<T>(T param, string path, string fileName) where T: class
        {
            
            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                info.Create();

            }

            List<string> mytext = new List<string>();
            var datas = param.GetType().GetProperties().ToList();
            var filePath=Path.Combine(path, fileName);
            foreach (var data in datas)
            {
                mytext.Add($"{data.Name}: {data.GetValue(param)}");
            }
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            File.WriteAllLines(filePath,mytext);
        }
        
    }
    
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}
