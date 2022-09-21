namespace Model;

public class Track
{
    public string Name { get; set; }
    public LinkedList<Section> Sections { get; set; }

    public Track(string name, SectionTypes[] sections)
    {
        Name = name;
        Sections = ConvertToLinkedList(sections);
    }

    public LinkedList<Section> ConvertToLinkedList(SectionTypes[] sections)
    {
        LinkedList<Section> placeholderSections = new LinkedList<Section>();
        foreach (SectionTypes section in sections)
        {
            try
            {
                Section newSection = new Section();
                newSection.SectionType = section;
                placeholderSections?.AddLast(newSection);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        return placeholderSections!;
    }
}