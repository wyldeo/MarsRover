using MarsRover.Entities;

namespace MarsRover.Orientations
{
  internal class North : Orientation
  {
    public override Position MovementDirection => new Position(0, c_stepSize);

    public override IOrientation Left() => new West();

    public override IOrientation Right() => new East();

    public override string ToString() => "N";
  }
}