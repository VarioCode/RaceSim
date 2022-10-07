using System.Timers;
using Model;

namespace Controller;

public class Race
{
    public Track Track { get; set; }
    public List<IParticipant> Participants { get; set; }
    public DateTime StartTime { get; set; }
    public System.Timers.Timer timer;
    public event EventHandler<DriversChangedEventArgs> DriversChanged;
    private Random _random;
    private Dictionary<Section, SectionData> _positions;
    private EventHandler<ElapsedEventArgs> OnTimedEvent;

    public Race(Track track, List<IParticipant> participants)
    {
        Track = track;
        Participants = participants;
        _positions = new Dictionary<Section, SectionData>();
        _random = new Random(DateTime.Now.Millisecond);
        timer = new System.Timers.Timer(500);
        SetStartPosition();
        DriversChanged.Invoke(this, new DriversChangedEventArgs().);
    }
    
    public void Start()
    {
        timer.Start();
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

    public void SetStartPosition()
    {
        Section[] startPositions = Track.StartPositions();
        for (int i = 0; i < startPositions.Length; i++)
        {
            SectionData sectionData = GetSectionData(startPositions[i]);
            IParticipant? participantLeft = null;
            IParticipant? participantRight = null;
            
            // TODO: make this scalable
            for (int j = 0; j < 2; j = j + 2) // Temp solution, this will be scalable in the future
            {
                participantLeft = Participants[j];
                participantRight = Participants[j + 1];
            }
            if (participantLeft != null && participantRight != null)
            {
                sectionData.Left = participantLeft;
                sectionData.Right = participantRight;
            }
            _positions.TryAdd(startPositions[i], sectionData);
        }
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