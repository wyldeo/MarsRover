using MarsRover.Parsers;
using System;
using System.Collections.Generic;

namespace MarsRover
{
  class Program
  {
    private static CommandParser CommandParser => new CommandParser();
    
    static void Main(string[] args)
    {
      while (true) Run();
    }

    private static void Run()
    {
      Console.WriteLine("Input grid size and states. 'GO' to run.");

      CollectInput(out var gridLine, out var roverLines);

      var runner = new Runner(new CommandParser());
      var finalGridState = runner.Run(gridLine, roverLines.ToArray());

      Console.WriteLine("Done. Final states:");
      Console.WriteLine(finalGridState.ToString());
    }

    private static void CollectInput(out string gridLine, out List<string> roverLines)
    {
      var line = Console.ReadLine();
      gridLine = null;
      roverLines = new List<string>();
      while (!string.IsNullOrEmpty(line))
      {
        // First line is grid size
        if (string.IsNullOrEmpty(gridLine)) gridLine = line;

        line = Console.ReadLine();

        if (line.ToUpper() == "GO") return;

        roverLines.Add((line));
      }
    }
  }
}
