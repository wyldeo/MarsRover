using MarsRover.Entities;
using MarsRover.Orientations;
using System;

namespace MarsRover
{
  /// <summary>
  /// Base class for MarsRover
  /// </summary>
  internal abstract class Rover
  {
    public Position Position { get; set; }
    public IOrientation Orientation { get; protected set; }

    protected abstract void MoveLeft();
    protected abstract void MoveRight();
    protected abstract void MoveForward();
    
    public void InterpretCommand(Command command)
    {
      switch (command)
      {
        case Command.Left:
          MoveLeft();
          break;

        case Command.Right:
          MoveRight();
          break;

        case Command.Forward:
          MoveForward();
          break;

        default:
          throw new ArgumentException($"Unhandled command {command}.");
      }
    }

    public override string ToString()
    {
      return $"({Position}, {Orientation})";
    }
  }
}