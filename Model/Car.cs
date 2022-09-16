namespace Model;

public class Car : IEquipment
{
    public string Name { get; set; }
    public int Points { get; set; }
    public IEquipment Equipment { get; set; }
    public TeamColors TeamColor { get; set; }
    public int Quality { get; set; }
    public int Performance { get; set; }
    public int Speed { get; set; }
    public bool IsBroken { get; set; }

    public Car()
    {
        
    }
}