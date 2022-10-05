using System.Diagnostics;

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

    public Section[] StartPositions()
    {
        int count = 0;
        
        // Count the number of sections that are a starting grid
        for (int i =  0; i < Sections.Count; i++)
        {
            if (Sections.ElementAt(i).SectionType == SectionTypes.StartGrid)
            {
                count += 1;
            }
        }
        
        // Create an array of sections that are a starting grid
        Section[] startPositions = new Section[count];
        int index = 0;
        for (int i = 0; i < Sections.Count; i++)
        {
            if (Sections.ElementAt(i).SectionType == SectionTypes.StartGrid)
            {
                startPositions[index] = Sections.ElementAt(i);
                index += 1;
            }
        }

        return startPositions;
    }
}