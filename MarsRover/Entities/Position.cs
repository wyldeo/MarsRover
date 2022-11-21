namespace MarsRover.Entities
{
  // Struct so that we can use value semantics
  internal struct Position
  {
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    public int X;
    public int Y;

    public static Position operator +(Position first, Position second)
    {
      return new Position(first.X + second.X, first.Y + second.Y);
    }

    public static bool operator >(Position first, Position second)
    {
      return first.X > second.X || first.Y > second.Y;
    }

    public static bool operator <(Position first, Position second)
    {
      return first.X < second.X || first.Y < second.Y;
    }

    public override string ToString()
    {
      return $"{X}, {Y}";
    }
  }
}
