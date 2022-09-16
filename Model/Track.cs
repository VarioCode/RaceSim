namespace Model;

public class Track
{
    public string Name { get; set; }
    public LinkedList<Section> Sections { get; set; }

    public Track(string name, SectionTypes[] sections)
    {
        Name = name;

        foreach (SectionTypes section in sections)
        {
            try
            {
                Section newSection = new Section();
                newSection.SectionType = section;
                Sections?.AddLast(newSection);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}