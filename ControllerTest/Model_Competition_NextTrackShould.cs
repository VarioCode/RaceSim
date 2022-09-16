using System.Runtime.CompilerServices;
using Model;

namespace ControllerTest;

[TestFixture]
public class Model_Competition_NextTrackShould
{
    private Competition _competition;

    [SetUp]
    public void SetUp()
    {
        _competition = new Competition();
    }

    [Test]
    public void NextTrack_EmptyQueue_ReturnNull()
    {
        Track result = _competition.NextTrack();
        Assert.IsNull(result);
    }

    [Test]
    public void NextTrack_OneInQueue_ReturnTrack()
    {
        Track newTrack = new Track("TestTrack1", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.Finish });
        _competition.Tracks.Enqueue(newTrack);
        Track result = _competition.NextTrack();
        Assert.AreEqual(newTrack, result);
    }

    [Test]
    public void NextTack_OneInQueue_RemoveTrackFromQueue()
    {
        Track newTrack = new Track("TestTrack1", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.Finish });
        _competition.Tracks.Enqueue(newTrack);
        Track result = _competition.NextTrack();
        result = _competition.NextTrack();
        Assert.IsNull(result);
    }

    [Test]
    public void NextTrack_TwoInQueue_ReturnNextTrack()
    {
        Track newTrack1 = new Track("TestTrack1", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.Finish });
        Track newTrack2 = new Track("TestTrack2", new SectionTypes[] { SectionTypes.StartGrid, SectionTypes.Straight, SectionTypes.Finish });
        
        _competition.Tracks.Enqueue(newTrack1);
        _competition.Tracks.Enqueue(newTrack2);
        
        Track result1 = _competition.NextTrack();
        Track result2 = _competition.NextTrack();
        
        Assert.AreEqual(newTrack1, result1);
        Assert.AreEqual(newTrack2, result2);
    }
}