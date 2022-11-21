using MarsRover.Entities;

namespace MarsRover.Orientations
{
  /// <summary>
  /// Represents an orientation
  /// </summary>
  internal interface IOrientation
  {
    IOrientation Left();
    IOrientation Right();

    Position ApplyMovement(Position initial);

    Position MovementDirection { get; }
  }
}
