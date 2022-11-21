using MarsRover.Entities;
using MarsRover.Orientations;
using MarsRover.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MarsRover.Test.Parser
{
  /// <summary>
  /// Tests the <see cref="CommandParser"/>
  /// </summary>
  [TestClass]
  public class CommandParserTests
  {
    [TestMethod]
    public void CanParseCompositeLine()
    {
      // Arrange
      var parser = new CommandParser();
      var line = "(4, 4, N) LFFRRFF";

      // Act
      var commands = parser.ParseCommands(line);
      var rover = parser.ParseRover(line);

      // Assert
      CollectionAssert.AreEqual(
        new[] { 
          Command.Left, 
          Command.Forward, 
          Command.Forward, 
          Command.Right, 
          Command.Right, 
          Command.Forward, 
          Command.Forward },
        commands.ToArray());

      Assert.AreEqual(new Position(4, 4), rover.Position);
      Assert.IsInstanceOfType(rover.Orientation, typeof(North));
    }

    [TestMethod]
    public void DoesntParseInvalidLine()
    {
      // Arrange
      var parser = new CommandParser();
      var line = "Invalid input string";

      // Act
      var commands = parser.ParseCommands(line);
      var rover = parser.ParseRover(line);

      // Assert
      Assert.AreEqual(null, rover);
      Assert.AreEqual(null, commands);
    }
  }
}
