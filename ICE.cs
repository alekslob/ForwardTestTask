
public class InternalCombustionEngineData{
    public int I {get;set;}
    public double[] M {get; set;}
    public double[] V {get;set;}
    public int T {get; set;}
    public double Hm {get; set;}
    public double Hv {get; set;}
    public double C {get; set;}
}

public class InternalCombustionEngine: Engine<InternalCombustionEngineData>{
    public InternalCombustionEngine(string filename):base(filename){
        try{
            if(options.I == 0) throw new Exception("Не задан I");
            if(options.M == null) throw new Exception("Не задан M");
            if(options.V == null) throw new Exception("Не задан V");
            if(options.M.Length != options.V.Length) throw new Exception("V и M не соответствуют");
            if(options.T == 0) throw new Exception("Не задан T");
            if(options.Hm == 0) throw new Exception("Не задан Hm");
            if(options.Hv == 0) throw new Exception("Не задан Hv");
            if(options.C == 0) throw new Exception("Не задан C");
        }
        catch(Exception e){
            Message(e.Message);
            throw;
        }
        
    }
    public override double getMaxTemperature(){return options.T;}
    public override int getCountTimeSegments(){return options.M.Length-1;}
    public override int getTime(int count){
        int result = 0;
        double a;
        for(int i=0; i <= count; i++){
            a = (options.M[i])/options.I;
            result += (int) Math.Sqrt((options.V[i+1]-options.V[i])/a);
        }
        return result;
    }
    private double CalculateVn(int i){
        double result = options.M[i]*options.Hm + Math.Pow(options.V[i], 2)*options.Hv;
        return result;
    }
    private double CalculateVc(int i){
        double result = options.C*(AmbientTemperature - EngineTemperature);
        return result;
    }
    public override void Work(int i)
    {
        double Vn, Vc;
        Vn = CalculateVn(i);
        Vc = CalculateVc(i);
        EngineTemperature += (Vn + Vc);

    }

}