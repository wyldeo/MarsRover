using MarsRover.Entities;
using MarsRover.Orientations;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Parsers
{
  /// <summary>
  /// Parses initial grid & rover states from input strings
  /// </summary>
  internal class CommandParser : ICommandParser
  {
    private Dictionary<char, Command> m_commandLookup = 
      new[] { Command.Left, Command.Right, Command.Forward }.ToDictionary(x => (char)x, x => x);

    private Dictionary<string, IOrientation> m_orientationLookup
      = new IOrientation[] { new North(), new South(), new East(), new West() }.ToDictionary(x => x.ToString(), x => x);

    public CommandParser()
    {
    }

    public IEnumerable<Command> ParseCommands(string line)
    {
      var match = Regexes.InitialState.Match(line);
      if (!match.Success) return null;

      return match.Groups[4].Value.Select(x => m_commandLookup[x]);
    }

    public Grid ParseGrid(string line)
    {
      var match = Regexes.GridSize.Match(line);
      if (!match.Success) return null;

      return new Grid(
        int.Parse(match.Groups[1].Value),
        int.Parse(match.Groups[2].Value));
    }

    public MarsRover ParseRover(string line)
    {
      var match = Regexes.InitialState.Match(line);
      if (!match.Success) return null;

      var orientation = m_orientationLookup[match.Groups[3].Value];
      var position = new Position(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));

      return new MarsRover(orientation, position);
    }
  }
}