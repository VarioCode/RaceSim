namespace Model;

public interface IEquipment : IParticipant
{
    // Length of a section is 70 meters, so every cordinate is 10 meters.
    public int Quality { get; set; }
    public int Performance { get; set; }
    public int Speed { get; set; }
    public bool IsBroken { get; set; }
}