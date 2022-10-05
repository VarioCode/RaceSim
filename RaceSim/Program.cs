using Controller;
using Model;

namespace RaceSim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Track indi500 = new Track("indi500",
                new[]
                {
                    SectionTypes.StartGrid, 
                    SectionTypes.Straight,
                    SectionTypes.Straight,
                    SectionTypes.Straight,
                    SectionTypes.RightCorner,
                    SectionTypes.RightCorner,
                    SectionTypes.Straight, 
                    SectionTypes.LeftCorner,
                    SectionTypes.Straight,
                    SectionTypes.Finish
                });
            Data.Initialize();
            Data.NextRace();
            string placeholder = Viz.SetDrivers("", Data.Competition.Participants[0], Data.Competition.Participants[1]);
            Viz.DrawTrack(indi500);
            
            
            for (; ;)
            {
                Thread.Sleep(100);
            }
        }
    }
}