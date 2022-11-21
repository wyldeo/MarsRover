using MarsRover.Entities;
using MarsRover.Orientations;
using MarsRover.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test.State
{
  /// <summary>
  /// Tests the <see cref="RoverState"/>
  /// </summary>
  [TestClass]
  public class RoverStateTests
  {
    private Position m_originPosition = new Position(0, 0);

    [TestMethod]
    public void AppliesCommand()
    {
      // Arrange 
      var command = new []{ Command.Forward };
      var rover = new MarsRover(new North(), m_originPosition);
      var state = new RoverState(rover, command);

      // Act
      state.Update();

      // Assert
      Assert.IsFalse(state.Commands.MoveNext());
      Assert.AreEqual(new Position(0, 1), rover.Position);
    }

    [TestMethod]
    public void DoesntUpdateIfLost()
    {
      // Arrange 
      var command = new[] { Command.Left, Command.Forward, Command.Forward };
      var rover = new MarsRover(new North(), m_originPosition);
      var state = new RoverState(rover, command);

      state.SetLost();

      // Act
      state.Update();
      state.Update();
      state.Update();

      // Assert
      Assert.AreEqual(m_originPosition, rover.Position);
    }

    [TestMethod]
    public void DoesntUpdateIfFinished()
    {
      // Arrange 
      var command = new[] { Command.Forward };
      var rover = new MarsRover(new North(), m_originPosition);
      var state = new RoverState(rover, command);

      // Act
      state.Update();
      state.Update();

      // Assert
      Assert.IsFalse(state.Commands.MoveNext());
      Assert.AreEqual(new Position(0, 1), rover.Position);
    }
  }
}
