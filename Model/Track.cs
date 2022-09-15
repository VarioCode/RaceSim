namespace Model;

public class Track
{
    public string Name { get; set; }
    public LinkedList<Section> sections { get; set; }

    public Track(string name, SectionTypes[] sections)
    {
        Name = name;

        foreach (SectionTypes section in sections)
        {
            Section newSection = new Section();
            newSection.SectionType = section;
            this.sections.AddLast(newSection);
        }
    }
}