using GameOfLife.Core.Models;
using System.Collections.Generic;

namespace GameOfLife.Core
{
    public class GameOfLife : IGameOfLife
    {

        private CellState[,] _current;
        public GridSize GridSize { get; }
        public GameOfLife(GridSize gridSize)
        {
            _current = new CellState[gridSize.X, gridSize.Y];
            GridSize = gridSize;
        }
        public GameOfLife(CellState[,] current)
        {
            _current = current;
            GridSize = new GridSize() {X=current.GetLength(0),Y= current.GetLength(1) };
        }

        public List<CellPoint> UpdateState()
        {
            var changedState = new List<CellPoint>();
            for (var x = 0; x < _current.GetLength(0); x++)
            {
                for (var y = 0; y < _current.GetLength(1); y++)
                {
                    UpdateSingleState(changedState, x, y);
                }
            }
            return changedState;
        }

        private void UpdateSingleState(List<CellPoint> changedState, int x, int y)
        {
            var currentState = _current[x, y];
            var point = new Point { X = x, Y = y };
            var aliveNeighours = CellStateHelpers.CalculateAliveNeighboursCount(_current, point);
            var cellState = CellStateHelpers.DetermineState(currentState, aliveNeighours);
            if (currentState != cellState)
            {
                _current[x, y] = cellState;
                changedState.Add(new CellPoint() { CellState = cellState, Point = point });
            }
        }

        public void NextGenaration(List<CellPoint> changedState)
        {
            changedState.ForEach(item =>
            {
                MakeAliveOrDead(item);
            });
        }

        private void MakeAliveOrDead(CellPoint item)
        {
            _current[item.Point.X, item.Point.Y] =
                              item.CellState == CellState.SPAWNING ||
                              item.CellState == CellState.ALIVE
                                ? CellState.ALIVE
                                : CellState.DEAD;
        }

        public CellState ToggleState(Point point)
        {
            var state = _current[point.X, point.Y];
            _current[point.X, point.Y] = state == CellState.DEAD ? CellState.ALIVE : CellState.DEAD;
            return _current[point.X, point.Y];
        }

        public CellState GetState(Point p) => _current[p.X, p.Y];
        
    }
}
