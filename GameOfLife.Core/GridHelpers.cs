using GameOfLife.Core.Models;
using System.Collections.Generic;

namespace GameOfLife.Core
{
    public static class GridHelpers
    {

        public static List<Point> DetermineValidRadialPoints(CellState[,] grid, Point p)
        {
            var radialPoints = new List<Point>();
            //right
            if (p.X < grid.GetLength(0) - 1)
            {
                var x = p.X + 1;
                CheckAndAddTopRadial(radialPoints, x, p.Y);
                radialPoints.Add(new Point { X = x, Y = p.Y });
                CheckAndAddBottomRadial(grid, radialPoints, x, p.Y);
            }
            //center
            CheckAndAddTopRadial(radialPoints, p.X, p.Y);
            CheckAndAddBottomRadial(grid, radialPoints, p.X, p.Y);
           
            ///left
            if (p.X > 0)
            {
                var x = p.X - 1;
                CheckAndAddTopRadial(radialPoints, x, p.Y);
                radialPoints.Add(new Point { X = x, Y = p.Y });
                CheckAndAddBottomRadial(grid, radialPoints, x, p.Y);
            }

            return radialPoints;
        }

        private static void CheckAndAddBottomRadial(CellState[,] grid, List<Point> radialPoints, int x, int y)
        {
            if (y < grid.GetLength(1) - 1)
            {
                radialPoints.Add(new Point { X = x, Y = y + 1 });
            }
        }

        private static void CheckAndAddTopRadial(List<Point> radialPoints, int x, int y)
        {
            if (y > 0)
            {
                radialPoints.Add(new Point { X = x, Y = y - 1 });
            }
        }

        
    }
}
