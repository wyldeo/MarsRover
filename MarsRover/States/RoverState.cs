using MarsRover.Entities;
using System.Collections.Generic;

namespace MarsRover.States
{
  /// <summary>
  /// Represents the state of a rover
  /// </summary>
  internal class RoverState : IState
  {
    public Rover Rover;
    public IEnumerator<Command> Commands;

    private bool m_finished = false;
    private bool m_lost = false;

    public bool NeedsUpdate => !(m_finished || m_lost);

    public RoverState(Rover rover, IEnumerable<Command> commands)
    {
      Rover = rover;
      Commands = commands.GetEnumerator();
    }

    public void SetLost()
    {
      m_lost = true;
    }

    public void Update()
    {
      if (m_lost) return;
      if (!Commands.MoveNext())
      {
        // No commands left
        m_finished = true;
        return;
      }

      Rover.InterpretCommand(Commands.Current);
    }

    public override string ToString()
    {
      return $"{Rover}{(m_lost ? " LOST" : "")}";
    }
  }
}
