public class Test<T>{
    private Engine<T> testEngine;
    
    public Test(Engine<T> engine){
        testEngine = engine;
    }
    public void test1(){
        try{
            int i = 0, time = 0, endTime;
            double PrevTemperature = 0;
            endTime = testEngine.getTime(i);
            double MaxTemperature = testEngine.getMaxTemperature();
            int CountTimeSegments = testEngine.getCountTimeSegments();
            while(MaxTemperature > testEngine.EngineTemperature){
                PrevTemperature = testEngine.EngineTemperature;
                testEngine.Work(i);

                if(Math.Abs(testEngine.EngineTemperature-PrevTemperature)<1e-6) {
                    testEngine.Message($"t двигателя не изменяется: {time} сек");
                    break;
                }
                time++;

                if(time == endTime){
                    
                    i++;
                    if(i < CountTimeSegments) endTime = testEngine.getTime(i);
                    
                }
                
            }
            if(MaxTemperature <= testEngine.EngineTemperature)testEngine.Message($"Перегрев: {time} сек");

        }
        catch(Exception e){
            throw;
        }
    }
}