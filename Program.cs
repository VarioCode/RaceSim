using Controller;
namespace RaceSim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Data.Initialize();
            Data.NextRace();
            Console.WriteLine(Data.CurrentRace);
        }
    }
}