using Controller;
using Model;

namespace RaceSim;

public static class Viz
{
    private static int _x;
    private static int _y = 14;
    private static string? _displayNames;
    private static int _driversCount;
    private static int _dirversPrinted; 
    private static int _dirversNotPrinted;
    
    #region graphics
      
    // Left Corners
    private static string[] _cornerLeftEast =
        {
            "|     |", 
            "      |", 
            "      |" , 
            "      |" , 
            "      |", 
            "      |" , 
            "------/" 
        };
    private static string[] _cornerLeftNorth =
    {
        "------\\",
        "      |",
        "      |",
        "      |",
        "      |",
        "      |",
        "|     |"
    };
    private static string[] _cornerLeftWest =
        {
            "/------",
            "|      ",
            "|      ",
            "|      ",
            "|      ",
            "|      ", 
            "|     |"};
    private static string[] _cornerLeftSouth =
        {
            "|     |", 
            "|      ", 
            "|      ", 
            "|      ", 
            "|      ", 
            "|      ", 
            "\\------"};

    // Right corners
    private static string[] _cornerRightSouth =
        {
            "|     |", 
            "      |", 
            "      |", 
            "      |", 
            "      |", 
            "      |", 
            "------/"};
    private static string[] _cornerRightEast =
    {
        "------\\", 
        "      |", 
        "      |", 
        "      |", 
        "      |", 
        "      |", 
        "|     |"
    };
    private static string[] _cornerRightNorth =
    {
        "/------", 
        "|      ", 
        "|      ", 
        "|      ", 
        "|      ", 
        "|      ", 
        "|     |"
    };
    private static string[] _cornerRightWest =
    {
        "|     |", 
        "|      ", 
        "|      ", 
        "|      ", 
        "|      ", 
        "|      ", 
        "\\------"
    };

    // Straights
    private static string[] _straightHortizontal =
    {
        "-------", 
        "       ", 
        "       ", 
        "       ", 
        "       ", 
        "       ", 
        "-------"
    };
    private static string[] _straightVertical =
    {
        "|     |", 
        "|     |", 
        "|     |", 
        "|     |", 
        "|     |",
        "|     |",
        "|     |"
    };
    
    // Special cases
    private static string[] _startGrid =
    {
        "-------", 
        "       ", 
        "  !#   ", 
        "       ", 
        "  !#   ", 
        "       ", 
        "-------"
    };
    private static string[] _finishHorizontal =
    {
        "-------", 
        "   #   ", 
        "   #   ", 
        "   #   ", 
        "   #   ", 
        "   #   ", 
        "-------"
    };
    private static string[] _finishVertical =
    {
        "|     |", 
        "|     |", 
        "|     |", 
        "|     |", 
        "#######", 
        "|     |", 
        "|     |"
    };

    private static Direction _direction = Direction.South;

    #endregion

    #region HelperFunctions

    private static void ChangeCursor(string xORy, bool minus)
    {
        if (xORy == "y" || xORy == "Y")
        {
            if (minus) { _y -= 7; }
            else { _y += 7; }
        }
        else if (xORy == "x" || xORy == "X")
        {
            if (minus) { _x -= 7; }
            else { _x += 7; }
        }
        Console.SetCursorPosition(_x, _y);
    }
    
    private static void PrintTrackPart(string[] arraytobeprinted)
    {
        int ytest = _y;
        for (int i = 0; i < arraytobeprinted.Length; i++)
        {
            Console.Write(arraytobeprinted[i]);
            ytest += 1;
            Console.SetCursorPosition(_x, ytest);
        }
    }

    #endregion
    

    public static void Initialaize()
    {
        
    }

    public static void main(Race currentRace)
    {
        currentRace.DriversChanged += onDriverChanged;
        
    }
    public static void onDriverChanged(object sender, DriversChangedEventArgs e)
    {
        DrawTrack(e.Track);
    }

    public static void DrawTrack(Track track)
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome to {track.Name}");
        Console.WriteLine("=========================");
        
        Console.SetCursorPosition(_x,_y);

        foreach (Section section in track.Sections)
        {
            switch (section.SectionType)
            {
                case SectionTypes.StartGrid:
                    PlaceDriversOnTrack();
                    PrintTrackPart(_startGrid);
                    _x += 7;
                    Console.SetCursorPosition(_x, _y);
                    break;
                case SectionTypes.Straight:
                    if (_direction == Direction.East || _direction == Direction.West)
                    {
                        PrintTrackPart(_straightHortizontal);
                        if (_direction == Direction.East)
                        {
                            ChangeCursor("x", false);
                        } else if (_direction == Direction.West)
                        {
                            ChangeCursor("x", true);
                        }
                    } else if (_direction == Direction.North || _direction == Direction.South)
                    {
                        PrintTrackPart(_straightVertical);
                        if (_direction == Direction.South)
                        {
                            ChangeCursor("y", false);
                        }
                        if (_direction == Direction.North)
                        {
                            ChangeCursor("y", true);
                        }
                    }
                    break;
                case SectionTypes.LeftCorner:
                    if (_direction == Direction.East)
                    {
                        PrintTrackPart(_cornerLeftEast);
                        ChangeCursor("y", true);
                        _direction = Direction.North;
                    } else if (_direction == Direction.North)
                    {
                        PrintTrackPart(_cornerLeftNorth);
                        ChangeCursor("x", true);
                        _direction = Direction.West;
                    } else if (_direction == Direction.South)
                    {
                        PrintTrackPart(_cornerLeftSouth);
                        ChangeCursor("x", false);
                        _direction = Direction.East;
                    } else if (_direction == Direction.West)
                    {
                        PrintTrackPart(_cornerLeftWest);
                        ChangeCursor("y", false);
                        _direction = Direction.South;
                    }
                    break;
                case SectionTypes.RightCorner:
                    if (_direction == Direction.East)
                    {
                        PrintTrackPart(_cornerRightEast);
                        ChangeCursor("y", false);
                        _direction = Direction.South;
                    } else if (_direction == Direction.North)
                    {
                        PrintTrackPart(_cornerRightNorth);
                        ChangeCursor("y", false);
                        _direction = Direction.East;
                    } else if (_direction == Direction.South)
                    {
                        PrintTrackPart(_cornerRightSouth);
                        ChangeCursor("x", true);
                        _direction = Direction.West;
                    } else if (_direction == Direction.West)
                    {
                        PrintTrackPart(_cornerRightWest);
                        ChangeCursor("y", true);
                        _direction = Direction.North;
                    }
                    break;
                case SectionTypes.Finish:
                    if (_direction == Direction.East || _direction == Direction.West)
                    {
                        PrintTrackPart(_finishHorizontal);
                        ChangeCursor("x", false);
                    } else if (_direction == Direction.North || _direction == Direction.South)
                    {
                        PrintTrackPart(_finishVertical);
                        ChangeCursor("y", false);
                    }
                    break;
            }
        }
    }

    public static string? SetDrivers(string strings, List<IParticipant> participants) // TODO: Make Scalable
    {
        // convert list to array
        IParticipant[] drivers = participants.ToArray();
        
        // creating placeholder strings for driver names.
        for (int i = 0; i < drivers.Length; i++)
        {
            _driversCount += 1;
            _displayNames += " " + drivers[i].Name.Replace("Driver ", "");
        }
        return _displayNames;
    }

    public static string[] PlaceDriversOnTrack() //TODO: Make Scalable
    {
        string[] viznames = _displayNames.Split(" ");
        int index = _driversCount - _dirversNotPrinted;
        string[] grid = _startGrid;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '!')
                {
                    if (_displayNames != null)
                    {
                        index++;
                        grid[i] = grid[i].Replace("!", viznames[index]);
                        _dirversPrinted++;
                    }
                }
            }
        }

        return grid;
    }
}