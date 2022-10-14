using Controller;
using Model;

namespace RaceSim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Data.Initialize();
            Data.NextRace();
            string? placeholder = Viz.SetDrivers("", Data.Competition.Participants);
            Viz.main(Data.CurrentRace);
            // Viz.DrawTrack(indi500);
            Data.CurrentRace.Start();
            
            
            for (; ;)
            {
                Thread.Sleep(100);
            }
        }
    }
}