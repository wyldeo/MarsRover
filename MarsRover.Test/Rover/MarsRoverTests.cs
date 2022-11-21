using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Orientations;
using MarsRover.Entities;

namespace MarsRover.Test.Rover
{
  [TestClass]
  public class MarsRoverTests
  {
    private Position m_originPosition = new Position(0, 0);

    [TestMethod]
    public void CanTurnRight()
    {
      // Arrange
      var rover = new MarsRover(new South(), m_originPosition);

      // Act
      rover.InterpretCommand(Command.Right);

      // Assert
      Assert.IsInstanceOfType(rover.Orientation, typeof(West));
    }

    [TestMethod]
    public void CanTurnLeft()
    {
      // Arrange
      var rover = new MarsRover(new West(), m_originPosition);

      // Act
      rover.InterpretCommand(Command.Left);

      // Assert
      Assert.IsInstanceOfType(rover.Orientation, typeof(South));
    }

    [TestMethod]
    public void CanMoveForward()
    {
      // Arrange
      var rover = new MarsRover(new North(), m_originPosition);

      // Act
      rover.InterpretCommand(Command.Forward);

      // Assert
      Assert.AreEqual(rover.Position, new Position(0, 1));
    }
  }
}
