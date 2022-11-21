using MarsRover.Entities;

namespace MarsRover.Orientations
{
  internal class West : Orientation
  {
    public override Position MovementDirection => new Position(-c_stepSize, 0);

    public override IOrientation Left() => new South();

    public override IOrientation Right() => new North();

    public override string ToString() => "W";
  }
}