
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Radiat
{
    public class Program
    {
        public static void Main(string[] args){
            try{
                Engine<InternalCombustionEngineData> ice = new InternalCombustionEngine("data.json");
                
                Test<InternalCombustionEngineData> test = new Test<InternalCombustionEngineData>(ice);
                test.test1();
            }
            catch{ }
            finally{
                Console.Read();
            }

        }
       
    }
}