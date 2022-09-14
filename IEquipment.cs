namespace RaceSim;

public interface IEquipment : IParticipant
{
    public int Quality { get; set; }
    public int Performance { get; set; }
    public int Speed { get; set; }
    public bool IsBroken { get; set; }
}