// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Radiat
{
    public class Program
    {
        public static void Main(string[] args){
            try{
                Engine<IInternalCombustionEngineData> ice = new InternalCombustionEngine("./data.json");
                
                Test<IInternalCombustionEngineData> test = new Test<IInternalCombustionEngineData>(ice);
                test.test1();
            }
            catch{ }
            finally{
                Console.Read();
            }

        }
       
    }
}