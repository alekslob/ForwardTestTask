using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTeatTask
{
    public class ICETest
    {
        public InternalCombustionEngine engine { get; set; }
        public ICETest(InternalCombustionEngine ice)
        {
            engine = ice;
        }
        public void RunTest1()
        {
            try
            {
                int i = 0, time = 0, endTime;
                double PrevTemperature = 0;
                endTime = engine.GetTime(i);
                double MaxTemperature = engine.GetMaxTemperature();
                int CountTimeSegments = engine.GetCountTimeSegments();
                while (MaxTemperature > engine.EngineTemperature)
                {
                    PrevTemperature = engine.EngineTemperature;
                    engine.Step(i);

                    if (Math.Abs(engine.EngineTemperature - PrevTemperature) < 1e-6)
                    {
                        Message.InConsole($"t двигателя не изменяется: {time} сек");
                        break;
                    }
                    time++;

                    if (time == endTime)
                    {

                        i++;
                        if (i < CountTimeSegments) endTime = engine.GetTime(i);

                    }

                }
                if (MaxTemperature <= engine.EngineTemperature) Message.InConsole($"Перегрев: {time} сек");

            }
            catch (Exception e)
            {
                Message.InConsole($"Возникла ошибка: {e}");
            }
        }
    }
}
