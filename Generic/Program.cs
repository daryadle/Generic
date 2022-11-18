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
            ReadOnfile("log", "Student");
            Read<Student>(@"C:\Users\\gh\\source\\repos\\Generic\\Generic\\bin\\Debug\\net5.0\\log\\Student");
            

            Console.ReadKey();
        }
        
        public static void WriteOnFile<T>(T param, string path, string fileName) where T: class,new()
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
        public static void ReadOnfile(string path, string fileName)
        {
            var readData = File.ReadAllText(Path.Combine(path, fileName));
            Console.WriteLine(readData);
        }
        public static void Read<T>(string filePath) where T : class, new()
        {
            List<T> output = new List<T>();
            var lines = File.ReadAllLines(filePath).ToList();
            T entry = new T();
            var cols = entry.GetType().GetProperties().ToList();
            
            //foreach(var item in cols)
            //{
            //    Console.WriteLine(item);
            //}
            foreach(var item in lines)
            {
                Console.WriteLine(item);    
            }
           
           
        }

    }
    
    public class Student
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}
