using MarsRover.Parsers;
using MarsRover.States;
using System.Collections.Generic;

namespace MarsRover
{
  /// <summary>
  /// Runs a round of grid updates
  /// </summary>
  internal class Runner
  {
    private readonly ICommandParser m_parser;

    public Runner(ICommandParser parser)
    {
      m_parser = parser;
    }

    public GridState Run(string gridLine, params string[] roverLines)
    {
      var roverStates = new List<RoverState>();
      foreach (var line in roverLines) roverStates.Add(BuildRoverState(line));

      var gridState = BuildGridState(gridLine, roverStates);

      while (!gridState.Done)
      {
        gridState.Update();
      }

      return gridState;
    }

    private RoverState BuildRoverState(string line)
    {
      var rover = m_parser.ParseRover(line);
      var commands = m_parser.ParseCommands(line);

      return new RoverState(rover, commands);
    }

    private GridState BuildGridState(string line, IEnumerable<RoverState> roverStates)
    {
      var grid = m_parser.ParseGrid(line);

      return new GridState(roverStates, grid);
    }
  }
}
