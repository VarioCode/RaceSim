using System.Diagnostics;
using Model;

namespace Controller;

public class Race
{
    public Track Track { get; set; }
    public List<IParticipant> Participants { get; set; }
    public DateTime StartTime { get; set; }

    private Random _random;
    private Dictionary<Section, SectionData> _positions;

    public Race(Track track, List<IParticipant> participants)
    {
        Track = track;
        Participants = participants;
        _random = new Random(DateTime.Now.Millisecond);
    }
    
    public SectionData GetSectionData(Section section)
    {
        SectionData sectionData;
        if (_positions.TryGetValue(section, out sectionData))
        {
            return sectionData;
        }

        sectionData = new SectionData();
        _positions.Add(section, sectionData);

        return sectionData;
    }

    public void RandomizeEquiment()
    {
        foreach (IParticipant participant in Participants)
        {
            participant.Equipment.Performance = _random.Next();
            participant.Equipment.Quality = _random.Next();
        }
    }
}