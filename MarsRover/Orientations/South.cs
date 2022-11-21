using MarsRover.Entities;

namespace MarsRover.Orientations
{
  internal class South : Orientation
  {
    public override Position MovementDirection => new Position(0, -c_stepSize);

    public override IOrientation Left() => new East();

    public override IOrientation Right() => new West();

    public override string ToString() => "S";
  }
}
