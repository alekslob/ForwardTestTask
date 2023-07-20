using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTeatTask
{
    public class Test
    {
        public IEngine eng { get; set; }
        public Test(IEngine engine)
        {
            eng = engine;
        }
        public void RunTest1()
        {
            try
            {
                int i = 0, time = 0, endTime;
                double PrevTemperature = 0;
                endTime = eng.GetTime(i);
                double MaxTemperature = eng.GetMaxTemperature();
                int CountTimeSegments = eng.GetCountTimeSegments();
                while (MaxTemperature > eng.EngineTemperature)
                {
                    PrevTemperature = eng.EngineTemperature;
                    eng.Step(i);

                    if (Math.Abs(eng.EngineTemperature - PrevTemperature) < 1e-6)
                    {
                        Message.InConsole($"t двигателя не изменяется: {time} сек");
                        break;
                    }
                    time++;

                    if (time == endTime)
                    {

                        i++;
                        if (i < CountTimeSegments) endTime = eng.GetTime(i);

                    }

                }
                if (MaxTemperature <= eng.EngineTemperature) Message.InConsole($"Перегрев: {time} сек");

            }
            catch (Exception e)
            {
                Message.InConsole($"Возникла ошибка: {e}");
            }
        }
    }
}
