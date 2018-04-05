using GameOfLife.Core.Models;
using System.Collections.Generic;

namespace GameOfLife.Core
{
    public interface IGameOfLife
    {
        void NextGenaration(List<CellPoint> changedState);
        CellState ToggleState(Point point);
        List<CellPoint> UpdateState();
        GridSize GridSize { get; }
        CellState GetState(Point p);
    }
}