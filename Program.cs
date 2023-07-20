
using System.Text.Json;
using System.Text.Json.Serialization;
using ForwardTeatTask;

namespace Radiat
{
    public class Program
    {
        public static void Main(string[] args){
            try{
                InternalCombustionEngine ice = Config<InternalCombustionEngine>.Initialize();
                ICETest test = new ICETest(ice);
                test.RunTest1();
            }
            catch{ }
            finally{
                Console.Read();
            }

        }
       
    }
}