using Model;

namespace RaceSim;

public static class Viz
{
    private static int _x = 0;
    private static int _y = 7;
    
    #region graphics
    
    // Left Corners
    private static string[][] _cornerLeftEast =
        { new [] { "            |" }, new [] { "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "------------/" }};
    private static string[][] _cornerLeftNorth =
        { new [] { "-----------\\" }, new [] { "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" } };
    private static string[][] _cornerLeftWest =
        { new [] { "/-----------" }, new [] { "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " } };
    private static string[][] _cornerLeftSouth =
        { new [] { "|            " }, new [] { "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "\\------------" }};

    // Right corners
    private static string[][] _cornerRightSouth =
        { new [] { "            |" }, new [] { "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "------------/" }};
    private static string[][] _cornerRightEast =
        { new [] { "-----------\\" }, new [] { "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" }, new []{ "            |" } };
    private static string[][] _cornerRightNorth =
        { new [] { "/-----------" }, new [] { "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " } };
    private static string[][] _cornerRightWest =
        { new [] { "|            " }, new [] { "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "|            " }, new []{ "\\------------" }};

    // Straights
    private static string[][] StraightHortizontal = 
        { new [] { "-START-------" }, new [] { "             " }, new []{ "             " }, new []{ "             " }, new []{ "             " }, new []{ "             " }, new []{ "-START-------" } };
    private static string[][] StraightVertical = 
        { new [] {"|           |"}, new [] { "|           |" }, new []{"|           |"}, new []{"|           |"}, new []{"|           |"}, new []{"|           |"}, new []{"|           |"} };
    
    // Special cases
    private static string[][] StartGrid = 
            { new [] {"-------------"}, new [] {"             "}, new []{"             "}, new []{"             "}, new []{"             "}, new []{"             "}, new []{"-------------"} };
    private static string[] _finishHorizontal = { "----", "  # ", "  # ", "----" };
    private static string[][] _finishVertical =
        { new [] {"|           |"}, new [] { "|           |" }, new []{"|           |"}, new []{"|           |"}, new []{"#F#I#N#I#S#H#"}, new []{"|           |"}, new []{"|           |"} };


    private static void printTrackPart(string[][] arraytobeprinted)
    {
        for (int i = 0; i < arraytobeprinted.Length; i++)
        {
            for (int j = 0; j < arraytobeprinted[i].Length; j++)
            {
                Console.Write(arraytobeprinted[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }
    public static void testPrint()
    {
    }
    
    #endregion

    public static void Initialaize()
    {
        
    }

    public static void DrawTrack(Track track)
    {
        Console.WriteLine($"Welcome to {track.Name}");
        Console.WriteLine("=========================");

        Console.GetCursorPosition();
        Console.SetCursorPosition(_x,_y);
        
        foreach (Section section in track.Sections)
        {
            if (section.SectionType == SectionTypes.StartGrid)
            {
                // Console.WriteLine(StartGrid);
            }
            else if (section.SectionType == SectionTypes.RightCorner)
            {
                // Console.WriteLine(RightCorner);
            }
            else if (section.SectionType == SectionTypes.LeftCorner)
            {
                // Console.WriteLine(LeftCorner);
            }
            else if (section.SectionType == SectionTypes.Straight)
            {
                // Console.WriteLine(Straight);
            }
            else if (section.SectionType == SectionTypes.Finish)
            {
                // Console.WriteLine(Finish);
            }
        }
    }
}