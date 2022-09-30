using Model;

namespace RaceSim;

public static class Viz
{
    private static int _x;
    private static int _y = 7;
    
    #region graphics
    
    // Left Corners
    private static string[][] _cornerLeftEast =
        { new [] { "      |" }, new [] { "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "------/" }};
    private static string[][] _cornerLeftNorth =
        { new [] { "------\\" }, new [] { "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" } };
    private static string[][] _cornerLeftWest =
        { new [] { "/------" }, new [] { "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " } };
    private static string[][] _cornerLeftSouth =
        { new [] { "|      " }, new [] { "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "\\------" }};

    // Right corners
    private static string[][] _cornerRightSouth =
        { new [] { "      |" }, new [] { "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "------/" }};
    private static string[][] _cornerRightEast =
        { new [] { "------\\" }, new [] { "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" }, new []{ "      |" } };
    private static string[][] _cornerRightNorth =
        { new [] { "/------" }, new [] { "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " } };
    private static string[][] _cornerRightWest =
        { new [] { "|      " }, new [] { "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "|      " }, new []{ "\\------" }};

    // Straights
    private static string[][] _straightHortizontal = 
        { new [] { "-------" }, new [] { "       " }, new []{ "       " }, new []{ "       " }, new []{ "       " }, new []{ "       " }, new []{ "-------" } };
    private static string[][] _straightVertical = 
        { new [] {"|     |"}, new [] { "|     |" }, new []{"|     |"}, new []{"|     |"}, new []{"|     |"}, new []{"|     |"}, new []{"|     |"} };
    
    // Special cases
    private static string[][] _startGrid = 
            { new [] {"-------"}, new [] {"       "}, new []{"   #   "}, new []{"       "}, new []{"   #   "}, new []{"       "}, new []{"-------"} };
    private static string[][] _finishHorizontal = 
        { new []{ "------", "  #   ", "  #   ", "  #   ", "  #   ", "  #   ", "------" }};
    private static string[][] _finishVertical =
        { new [] {"|     |"}, new [] { "|     |" }, new []{"|     |"}, new []{"|     |"}, new []{"#######"}, new []{"|     |"}, new []{"|     |"} };

    private static Direction _direction = Direction.East;
    

    #endregion

    #region HelperFunctions

    public static int CurrentX()
    {
        return Console.GetCursorPosition().Left;
    }

    public static int CurrentY()
    {
        return Console.GetCursorPosition().Top;
    }
    
    private static void PrintTrackPart(string[][] arraytobeprinted)
    {
        int ytest = _y;
        for (int i = 0; i < arraytobeprinted.Length; i++)
        {
            for (int j = 0; j < arraytobeprinted[i].Length; j++)
            {
                for (int a = 0; a < arraytobeprinted[i][j].Length; a++)
                {
                    Console.Write(arraytobeprinted[i][j][a]);
                }
                ytest += 1;
                Console.SetCursorPosition(_x, ytest);
            }
            
        }
    }
    
    #endregion
    

    public static void Initialaize()
    {
        
    }

    public static void DrawTrack(Track track)
    {
        Console.WriteLine($"Welcome to {track.Name}");
        Console.WriteLine("=========================");
        
        foreach (Section section in track.Sections)
        {
            switch (section.SectionType)
            {
                case SectionTypes.StartGrid:
                    PrintTrackPart(_startGrid);
                    _x = +7;
                    Console.SetCursorPosition(_x, _y);
                    break;
                case SectionTypes.Straight:
                    if (_direction == Direction.East || _direction == Direction.West)
                    {
                        PrintTrackPart(_straightHortizontal);
                        _x += 7;
                        Console.SetCursorPosition(_x, _y);
                    } else if (_direction == Direction.North || _direction == Direction.South)
                    {
                        PrintTrackPart(_straightVertical);
                        _y += 7;
                        Console.SetCursorPosition(_x, _y);
                    }
                    break;
                case SectionTypes.LeftCorner:
                    if (_direction == Direction.East)
                    {
                        PrintTrackPart(_cornerLeftEast);
                        _x += 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.North;
                    } else if (_direction == Direction.North)
                    {
                        PrintTrackPart(_cornerLeftNorth);
                        _y += 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.West;
                    } else if (_direction == Direction.South)
                    {
                        PrintTrackPart(_cornerLeftSouth);
                        _y += 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.East;
                    } else if (_direction == Direction.West)
                    {
                        PrintTrackPart(_cornerLeftWest);
                        _x -= 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.North;
                    }
                    break;
                case SectionTypes.RightCorner:
                    if (_direction == Direction.East)
                    {
                        PrintTrackPart(_cornerRightEast);
                        _y += 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.South;
                    } else if (_direction == Direction.North)
                    {
                        PrintTrackPart(_cornerRightNorth);
                        _y += 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.East;
                    } else if (_direction == Direction.South)
                    {
                        PrintTrackPart(_cornerRightSouth);
                        _y += 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.West;
                        // Console.WriteLine(_direction);
                    } else if (_direction == Direction.West)
                    {
                        PrintTrackPart(_cornerRightWest);
                        _y -= 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.North;
                    }
                    break;
                case SectionTypes.Finish:
                    if (_direction == Direction.East || _direction == Direction.West)
                    {
                        PrintTrackPart(_finishHorizontal);
                        _x += 7;
                        Console.SetCursorPosition(_x, _y);
                    } else if (_direction == Direction.North || _direction == Direction.South)
                    {
                        PrintTrackPart(_finishVertical);
                        _y += 7;
                        Console.SetCursorPosition(_x, _y);
                    }
                    break;
            }
        }
    }
}