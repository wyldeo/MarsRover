using MarsRover.Entities;
using MarsRover.Orientations;

namespace MarsRover
{
  /// <summary>
  /// Mars rover
  /// </summary>
  internal class MarsRover : Rover
  {
    public MarsRover(IOrientation orientation, Position position)
    {
      Orientation = orientation;
      Position = position;
    }

    protected override void MoveLeft()
    {
      Orientation = Orientation.Left();
    }

    protected override void MoveRight()
    {
      Orientation = Orientation.Right();
    }

    protected override void MoveForward()
    {
      Position = Orientation.ApplyMovement(Position);
    }
  }
}