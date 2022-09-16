namespace Model;

public class Competition
{
    public List<IParticipant> Participants { get; set; }
    public Queue<Track> Tracks { get; set; }

    public Competition()
    {
        Participants = new List<IParticipant>();
        Tracks = new Queue<Track>();
        Tracks.Enqueue(new Track("Placeholder", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Finish }) );
    }

    public Track NextTrack() // Going to the next track
    {
        Tracks.Dequeue();
        return Tracks.Peek();
    }


}