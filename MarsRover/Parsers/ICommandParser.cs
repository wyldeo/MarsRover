using MarsRover.Entities;
using System.Collections.Generic;

namespace MarsRover.Parsers
{
  internal interface ICommandParser
  {
    Grid ParseGrid(string line);
    IEnumerable<Command> ParseCommands(string line);
    MarsRover ParseRover(string line);
  }
}