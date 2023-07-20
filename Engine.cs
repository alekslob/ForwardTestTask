using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTeatTask
{
    public class EngineData
    {
        public double AmbientTemperature { get; set; }
        public double EngineTemperature { get; set; }
    }
    public class Engine : EngineData
    {
        public virtual double GetMaxTemperature() { return 0; }
        public virtual int GetCountTimeSegments() { return 0; }

        public virtual int GetTime(int count) { return 0; }
        public virtual void Work() { }
        public virtual void Step(int i) { }
    }
}
