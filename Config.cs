using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForwardTeatTask
{
    public class Config<T> where T : new()
    {
        public static T data { get; set; }
        public static string pathToDataFile { get; set; }

        public static T Initialize(string fileName = "data.json")
        {
            data = new T();
            //pathToDataFile = Directory.GetCurrentDirectory() + "\\" + fileName;
            pathToDataFile = fileName;
            if (System.IO.File.Exists(pathToDataFile))
            {
                ReadFromFile();
            }
            WriteInFile();
            LogData();
            return data;
        }

        public static T Update(T new_data)
        {
            data = new_data;
            WriteInFile();
            return data;
        }
        private static string DataToString()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize<T>(data, options);
        }
        private static void WriteInFile()
        {
            try
            {
                File.WriteAllText(pathToDataFile, DataToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        private static void ReadFromFile()
        {
            try
            {
                string json = File.ReadAllText(pathToDataFile);
                data = JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        public static void LogData()
        {
            Console.WriteLine("========================== Текущий файл настроек ===============================\n" +
                $"{DataToString()}" +
                "\n================================================================================");
        }
    }
}
