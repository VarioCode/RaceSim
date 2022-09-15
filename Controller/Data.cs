using System.Collections;
using System.ComponentModel.Design;
using Model;
namespace Controller;

public static class Data
{
    
    public static Competition? Competition { get; set; }
    public static Race? CurrentRace { get; set; }

    public static void Initialize()
    {
        Competition = new Competition();
        AddParticipants();
        AddTracks();
        
    }

    public static void AddParticipants()
    {
        Random rnd = new Random();
        int newNumberOfParticipants = rnd.Next(2, 5);

        for (int i = 0; i < newNumberOfParticipants; i++)
        {
            Driver newDriver = new Driver();
            Array values = Enum.GetValues(typeof(TeamColors));
            
            newDriver.Name = $"Driver {i++}";
            newDriver.TeamColor = (TeamColors)values.GetValue(rnd.Next(values.Length))!;
            newDriver.Equipment = new Car();
            newDriver.Equipment.Name = nameof(newDriver.Name);

            Competition.Participants.Add(newDriver);
        }
    }

    public static void AddTracks()
    {
        Random rnd = new Random();
        int newNumberOfTracks = rnd.Next(2, 6);
        
        for (int i = 0; i < newNumberOfTracks; i++)
        {
            int trackLenght = rnd.Next(10, 30);
            Array values = Enum.GetValues(typeof(SectionTypes));
            ArrayList trackValues = new ArrayList();

            foreach (SelectionTypes value in values) // removing values Finish and StartGrid from the array
            {
                if (value == (SelectionTypes)SectionTypes.Finish || value == (SelectionTypes)SectionTypes.StartGrid)
                {
                    continue;
                }
                trackValues.Add(value);
            }
            
            ArrayList newTrack = new ArrayList();
            newTrack.Add(SectionTypes.StartGrid);

            for (int a = 0; a < trackLenght; a++)
            {
                newTrack.Add(trackValues[rnd.Next(trackValues.Count)]);
            }
            
            newTrack.Add(SectionTypes.Finish);

            Competition!.Tracks.Enqueue(new Track($"Track {i++}", newTrack.ToArray()));
        }
    }

    public static void NextRace()
    {
        Track nextTrack = Competition!.NextTrack();
        if (nextTrack == null)
        {
            Console.WriteLine("Wanna go again? Press Enter.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Initialize();
                CurrentRace = new Race(Competition!.NextTrack(), Competition.Participants);
            }
        }
        else
        {
            CurrentRace = new Race(nextTrack, Competition.Participants);
        }
        
        
    }
}