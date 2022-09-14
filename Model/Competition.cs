namespace Model;

public class Competition : Driver
{
    public List<IParticipant> Participants { get; set; }
    public Queue<Track> Tracks { get; set; }
    
    
}