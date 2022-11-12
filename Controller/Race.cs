using System.Timers;
using Model;

namespace Controller;

public class Race
{
    private Track Track { get; set; }
    private List<IParticipant> Participants { get; set; }
    private DateTime StartTime { get; set; }
    
    private System.Timers.Timer _timer;
    public event EventHandler<DriversChangedEventArgs> DriversChanged;
    public event EventHandler<ElapsedEventArgs> TimerElapsed; 
    private Random _random;
    private Dictionary<Section, SectionData> _positions;

    public Race(Track track, List<IParticipant> participants)
    {
        Track = track;
        Participants = participants;
        _positions = new Dictionary<Section, SectionData>();
        _random = new Random(DateTime.Now.Millisecond);
        _timer = new System.Timers.Timer(10000);
        SetStartPosition();
    }
    public void Start()
    {
        DriversChangedEvent();
        _timer.Start();
    }
    
    public void DriversChangedEvent()
    {
        DriversChanged.Invoke(this, new DriversChangedEventArgs() { Track = this.Track });
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
            participant.Equipment.Performance = _random.Next(1,10);
            participant.Equipment.Quality = _random.Next(1,10);
            participant.Equipment.Speed = _random.Next(1,50);
        }
    }
}