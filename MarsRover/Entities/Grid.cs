namespace MarsRover.Entities
{
  internal class Grid
  {
    // Size
    public Position Origin;
    public Position TopRight;

    public Grid(int width, int height)
    {
      Origin = new Position(0, 0);
      TopRight = new Position(width, height);
    }

    public bool ViolatesBounds(Position position)
    {
      return position > TopRight || position < Origin;
    }
  }
}