using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTeatTask
{
    public class InternalCombustionEngineData: Engine
    {
        public int I { get; set; } = 10;
        public List<int> M { get; set; } = new List<int>() { 20, 75, 100, 105, 75, 0 };
        public List<int> V { get; set; } = new List<int>() { 0, 75, 150, 200, 250, 300 };
        public int T { get; set; } = 110;
        public double Hm { get; set; } = 0.01;
        public double Hv { get; set; } = 0.0001;
        public double C { get; set; } = 0.1;
    }
    public class InternalCombustionEngine : InternalCombustionEngineData
    {
        public override double GetMaxTemperature()
        {
            return T;
        }
        public override int GetCountTimeSegments()
        {
            return M.Count - 1;
        }

        public override int GetTime(int count)
        {
            int result = 0;
            double a;
            for (int i = 0; i <= count; i++)
            {
                a = M[i] / I;
                result += (int)Math.Sqrt((V[i + 1] - V[i])/a);
            }
            return result;
        }

        private double CalculateVn(int i)
        {
            double result = M[i] * Hm + Math.Pow(V[i], 2) * Hv;
            return result;
        }
        private double CalculateVc()
        {
            double result = C * (AmbientTemperature - EngineTemperature);
            return result;
        }
        public override void Step(int i)
        {
            double Vn, Vc;
            Vn = CalculateVn(i);
            Vc = CalculateVc();
            EngineTemperature += (Vn + Vc);

        }
    }
}
