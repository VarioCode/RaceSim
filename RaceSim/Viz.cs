using System.Diagnostics;
using Model;

namespace RaceSim;

public static class Viz
{
    private static int _x;
    private static int _y = 7;
    private static string DisplayNames;
    
    #region graphics
      
    // Left Corners
    private static string[] _cornerLeftEast =
        {"      |", "      |", "      |" , "      |" , "      |", "      |" , "------/" };
    private static string[] _cornerLeftNorth =
        {"------\\", "      |",  "      |", "      |", "      |", "      |", "      |"};
    private static string[] _cornerLeftWest =
        {"/------", "|      ", "|      ", "|      ", "|      ", "|      ", "|      "};
    private static string[] _cornerLeftSouth =
        {"|      ", "|      ", "|      ", "|      ", "|      ", "|      ", "\\------"};

    // Right corners
    private static string[] _cornerRightSouth =
        {"      |", "      |", "      |", "      |", "      |", "      |", "------/"};
    private static string[] _cornerRightEast =
        {"------\\", "      |", "      |", "      |", "      |", "      |", "      |"};
    private static string[] _cornerRightNorth =
        {"/------", "|      ", "|      ", "|      ", "|      ", "|      ", "|      "};
    private static string[] _cornerRightWest =
        {"|      ", "|      ", "|      ", "|      ", "|      ", "|      ", "\\------"};

    // Straights
    private static string[] _straightHortizontal = 
        {"-------", "       ", "       ", "       ", "       ", "       ", "-------"};
    private static string[] _straightVertical = 
        {"|     |", "|     |", "|     |", "|     |", "|     |", "|     |", "|     |"};
    
    // Special cases
    private static string[] _startGrid = 
        {"-------", "       ", "  !#   ", "       ", "  !#   ", "       ", "-------"};
    private static string[] _finishHorizontal = 
        {"------", "  #   ", "  #   ", "  #   ", "  #   ", "  #   ", "------" };
    private static string[] _finishVertical =
        {"|     |", "|     |", "|     |", "|     |", "#######", "|     |", "|     |"};

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
    
    private static void PrintTrackPart(string[] arraytobeprinted)
    {
        int ytest = _y;
        for (int i = 0; i < arraytobeprinted.Length; i++)
        {
            for (int j = 0; j < arraytobeprinted[i].Length; j++)
            {
                Console.Write(arraytobeprinted[i][j]);
            }
            ytest += 1;
            Console.SetCursorPosition(_x, ytest);
            
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
                    PlaceDriversOnTrack();
                    PrintTrackPart(_startGrid);
                    _x = +7;
                    Console.SetCursorPosition(_x, _y);
                    break;
                case SectionTypes.Straight:
                    if (_direction == Direction.East || _direction == Direction.West)
                    {
                        PrintTrackPart(_straightHortizontal);
                        if (_direction == Direction.East)
                        {
                            _x += 7;
                        }
                        if (_direction == Direction.West)
                        {
                            _x -= 7;
                        }
                        Console.SetCursorPosition(_x, _y);
                    } else if (_direction == Direction.North || _direction == Direction.South)
                    {
                        PrintTrackPart(_straightVertical);
                        if (_direction == Direction.East)
                        {
                            _y += 7;
                        }
                        if (_direction == Direction.West)
                        {
                            _y -= 7;

                        }
                        Console.SetCursorPosition(_x, _y);
                    }
                    break;
                case SectionTypes.LeftCorner:
                    if (_direction == Direction.East)
                    {
                        PrintTrackPart(_cornerLeftEast);
                        _y -= 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.North;
                    } else if (_direction == Direction.North)
                    {
                        PrintTrackPart(_cornerLeftNorth);
                        _x -= 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.West;
                    } else if (_direction == Direction.South)
                    {
                        PrintTrackPart(_cornerLeftSouth);
                        _x += 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.East;
                    } else if (_direction == Direction.West)
                    {
                        PrintTrackPart(_cornerLeftWest);
                        _y += 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.South;
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
                        _x -= 7;
                        Console.SetCursorPosition(_x, _y);
                        _direction = Direction.West;
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

    public static string SetDrivers(string strings, IParticipant driver1, IParticipant driver2)
    {
        // creating placeholder strings for driver names.
        string driver1displayname = driver1.Name;
        string driver2displayname = driver2.Name;

        // Removing "Driver" from the driver names.
        driver1displayname = driver1displayname.Replace("Driver ", "");
        driver2displayname = driver2displayname.Replace("Driver ", "");

        DisplayNames = driver1displayname + " " + driver2displayname;
        
        return DisplayNames;

    }

    public static void PlaceDriversOnTrack()
    {
        string[] viznames = DisplayNames.Split(" ");
        int index = 0;
        for (int i = 0; i < _startGrid.Length; i++)
        {
            for (int j = 0; j < _startGrid[i].Length; j++)
            {
                if (_startGrid[i][j] == '!')
                {
                    if (DisplayNames != null)
                    {
                        _startGrid[i] = _startGrid[i].Replace("!", viznames[index]);
                        index++;
                    }
                }
            }
        }
    }
    
    public static void EventHandler(DriversChangedEventArgs e)
    {
        DrawTrack(e.Track);
        PlaceDriversOnTrack();
    }
}