using MarsRover.Entities;
using MarsRover.Orientations;
using MarsRover.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test.State
{
  /// <summary>
  /// Tests the <see cref="GridState"/>
  /// </summary>
  [TestClass]
  public class GridStateTests
  {
    private Position m_originPosition = new Position(0, 0);

    [TestMethod]
    public void RollsBackPositionAfterLost()
    {
      // Arrange
      var commands = new[] { Command.Left, Command.Forward };
      var roverState = new RoverState(new MarsRover(new North(), m_originPosition), commands);
      var grid = new Grid(10, 10);
      var state = new GridState(new[]{ roverState }, grid);

      // Act
      state.Update();
      state.Update();

      // Assert
      Assert.AreEqual(m_originPosition, roverState.Rover.Position);
    }

    [TestMethod]
    public void DoesntUpdateFinishedRovers()
    {
      // Arrange
      var commands = new[] { Command.Left, Command.Forward };
      var roverState = new RoverState(new MarsRover(new North(), m_originPosition), commands);
      var grid = new Grid(10, 10);
      var state = new GridState(new[] { roverState }, grid);

      // Act
      state.Update();
      state.Update();

      // Assert
      Assert.AreEqual(m_originPosition, roverState.Rover.Position);
    }

    [TestMethod]
    public void DoesntUpdateLostRovers()
    {
      // Arrange
      var commands = new[] { Command.Forward, Command.Forward };
      var roverState = new RoverState(new MarsRover(new North(), m_originPosition), commands);
      var grid = new Grid(10, 10);
      var state = new GridState(new[] { roverState }, grid);

      roverState.SetLost();

      // Act
      state.Update();
      state.Update();

      // Assert
      Assert.AreEqual(m_originPosition, roverState.Rover.Position);
    }
  }
}
