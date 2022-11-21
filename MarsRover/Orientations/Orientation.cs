using MarsRover.Entities;

namespace MarsRover.Orientations
{
  internal abstract class Orientation : IOrientation
  {
    protected const int c_stepSize = 1;

    public abstract Position MovementDirection { get; }

    public abstract IOrientation Left();

    public abstract IOrientation Right();

    public Position ApplyMovement(Position initial)
    {
      return initial + MovementDirection;
    }
  }
}