﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTeatTask
{
    public interface IEngineData
    {
        public double ambientTemperature { get; set; }
        public double engineTemperature { get; set; }
    }
    public interface IEngine: IEngineData
    {
        public double GetMaxTemperature() { return 0; }
        public int GetCountTimeSegments() { return 0; }

        public int GetTime(int count) { return 0; }
        public void Work() { }
        public void Step(int i) { }
    }
}
