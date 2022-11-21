using MarsRover.Entities;

namespace MarsRover.Orientations
{
  internal class East : Orientation
  {
    public override Position MovementDirection => new Position(c_stepSize, 0);

    public override IOrientation Left() => new North();

    public override IOrientation Right() => new South();

    public override string ToString() => "E";
  }
}