using System.Text.RegularExpressions;

namespace MarsRover.Entities
{
  /// <summary>
  /// Regexes for parsing initial state & grid
  /// </summary>
  internal static class Regexes
  {
    public static Regex InitialState =
      new Regex("\\((\\d+), (\\d+), ([NSEWnsew])\\) ([LRFlrf]+)", RegexOptions.Compiled);

    public static Regex GridSize = new Regex("(\\d+), (\\d+)", RegexOptions.Compiled);
  }
}