using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
public class Engine<T>{
    public T options;
    public double AmbientTemperature {get; set;}
    public double EngineTemperature {get;set;}
    public Engine(string filename){
        try{
            ReadData(filename);
            string str = ReadConsole("Ввод t среды: ");
            if(!double.TryParse(str, out double t)) throw new Exception("Не задана t среды");
            AmbientTemperature = t;
            EngineTemperature = AmbientTemperature;
        }
        catch(Exception e){
            Message(e.Message);
            throw;
        }
    }
    public virtual double getMaxTemperature(){return 0;}
    public virtual int getCountTimeSegments(){return 0;}
    private void ReadData(string filename){
         try{
            if(!System.IO.File.Exists(filename)) throw new Exception($"Файл \"{filename}\" не существует");
            StreamReader r = new StreamReader(filename);
            string json = r.ReadToEnd();
            options = JsonSerializer.Deserialize<T>(json);
        }
        catch{
            throw;
        }
    }
    public string ReadConsole(string mess){
        string str = "";
        while(str == ""){
            Message(mess);
            str = Console.ReadLine();
        }
        return str;
    }
    public void Message(string mess){
        Console.WriteLine(mess);
    }
    public virtual int getTime(int count){ return 0;}
    public virtual void Work(){}
    public virtual void Work(int i){}
}