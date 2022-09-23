using Controller;
namespace RaceSim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Data.Initialize();
            Data.NextRace();
            Viz.DrawTrack(Data.CurrentRace!.Track);
            
            Viz.testPrint();
            
            for (; ;)
            {
                Thread.Sleep(100);
            }
        }
    }
}