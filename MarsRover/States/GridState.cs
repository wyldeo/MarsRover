using MarsRover.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.States
{
  /// <summary>
  /// Represents the state of the grid
  /// </summary>
  internal class GridState : IState
  {
    private IEnumerable<RoverState> m_roverStates;
    private Grid m_grid;
    public bool Done => m_roverStates.All(x => !x.NeedsUpdate);

    public GridState(IEnumerable<RoverState> initialStates, Grid grid)
    {
      m_roverStates = initialStates;
      m_grid = grid;
    }

    public void Update()
    {
      foreach (var state in m_roverStates.Where(x => x.NeedsUpdate))
      {
        var positionBeforeUpdate = state.Rover.Position;
        state.Update();

        if (m_grid.ViolatesBounds(state.Rover.Position))
        {
          // Set lost, and rollback position
          state.SetLost();
          state.Rover.Position = positionBeforeUpdate;
        }
      }
    }

    public override string ToString()
    {
      return string.Join(Environment.NewLine, m_roverStates.Select(x => x.ToString()));
    }
  }
}
