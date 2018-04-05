using GameOfLife.Core.Models;

namespace GameOfLife.Core
{
    public static class CellStateHelpers
    {
        private readonly static int minRequiredToLife = 2;
        private readonly static int maxAllowedForLife = 3;
        private readonly static int numberRequiredForLife = 3;
        public static CellState DetermineState(CellState cell, int aliveNeighours)
        {
            if (cell == CellState.ALIVE)
            {
                if (
                  aliveNeighours >= minRequiredToLife &&
                  aliveNeighours <= maxAllowedForLife
                )
                {
                    return CellState.ALIVE;
                }
                return CellState.DYING;
            }
            if (
              cell == CellState.DEAD &&
              aliveNeighours == numberRequiredForLife
            )
            {
                return CellState.SPAWNING;
            }
            return CellState.DEAD;
        }
        public static int CalculateAliveNeighboursCount(CellState[,] grid, Point p)
        {
            var radialPoints = GridHelpers.DetermineValidRadialPoints(grid, p);
            var total = 0;
            radialPoints.ForEach(item =>
            {
                var value = grid[item.X, item.Y];
                if (value == CellState.ALIVE || value == CellState.DYING)
                {
                    total++;
                }
            });

            return total;
        }

    }
}
