using GameOfLife.Core.Models;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Core.UnitTests
{
    public class GridHelpersTests
    {


        private Point _leftTop = new Point { X = 0, Y = 0 };
        private Point _leftMiddle = new Point { X = 0, Y = 1 };
        private Point _leftBottom = new Point { X = 0, Y = 2 };

        private Point _centerTop = new Point { X = 1, Y = 0 };
        private Point _centerMiddle = new Point { X = 1, Y = 1 };
        private Point _centerBottom = new Point { X = 1, Y = 2 };

        private Point _rightTop = new Point { X = 2, Y = 0 };
        private Point _rightMiddle = new Point { X = 2, Y = 1 };
        private Point _rightBottom = new Point { X = 2, Y = 2 };

        private CellState[,] _currentTest = new CellState[3, 3];
        // | X 0 _ |
        // | 0 0 _ |
        // | _ _ _ |
        [Fact]
        public void TopleftSurroundingPoints()
        {
            var point = new List<Point> { _centerTop, _centerMiddle, _leftMiddle, };
            Assert.Equal(point, GridHelpers.DetermineValidRadialPoints(_currentTest, _leftTop));
        }
        // | 0 X 0 |
        // | 0 0 0 |
        // | _ _ _ |
        [Fact]
        public void TopMiddleSurroundingPoints()
        {
            var points = new List<Point> { _rightTop, _rightMiddle, _centerMiddle, _leftTop, _leftMiddle, };
            Assert.Equal(points, GridHelpers.DetermineValidRadialPoints(_currentTest, _centerTop));
        }
        // | _ 0 X |
        // | _ 0 0 |
        // | _ _ _ |
        [Fact]
        public void TopRightSurroundingPoints()
        {
            var point = new List<Point> { _rightMiddle, _centerTop, _centerMiddle, };
            Assert.Equal(point, GridHelpers.DetermineValidRadialPoints(_currentTest, _rightTop));
        }
        // | 0 0 _ |
        // | X 0 _ |
        // | 0 0 _ |
        [Fact]
        public void MiddleLeftSurroundingPoints()
        {
            var point = new List<Point> { _centerTop, _centerMiddle, _centerBottom, _leftTop, _leftBottom };
            Assert.Equal(point, GridHelpers.DetermineValidRadialPoints(_currentTest, _leftMiddle));
        }

        // | 0 0 0 |
        // | 0 X 0 |
        // | 0 0 0 |
        [Fact]
        public void MiddleMiddleSurroundingPoints()
        {
            var point = new List<Point> { _rightTop, _rightMiddle, _rightBottom, _centerTop, _centerBottom, _leftTop, _leftMiddle, _leftBottom };
            Assert.Equal(point, GridHelpers.DetermineValidRadialPoints(_currentTest, _centerMiddle));
        }

        // | _ 0 0 |
        // | _ 0 X |
        // | _ 0 0 |
        [Fact]
        public void MiddleRightSurroundingPoints()
        {
            var point = new List<Point> { _rightTop, _rightBottom, _centerTop, _centerMiddle, _centerBottom, };
            Assert.Equal(point, GridHelpers.DetermineValidRadialPoints(_currentTest, _rightMiddle));
        }

        // | _ _ _ |
        // | 0 0 _ |
        // | X 0 _ |
        [Fact]
        public void BottomleftSurroundingPoints()
        {
            var point = new List<Point> { _centerMiddle, _centerBottom, _leftMiddle };
            Assert.Equal(point, GridHelpers.DetermineValidRadialPoints(_currentTest, _leftBottom));
        }

        // | _ _ _ |
        // | 0 0 0 |
        // | 0 X 0 |
        [Fact]
        public void BottomMiddleSurroundingPoints()
        {
            var point = new List<Point> { _rightMiddle, _rightBottom, _centerMiddle, _leftMiddle, _leftBottom };
            Assert.Equal(point, GridHelpers.DetermineValidRadialPoints(_currentTest, _centerBottom));
        }
        [Fact]
        // | _ _ _ |
        // | _ 0 0 |
        // | _ 0 X |
        public void BottomRightSurroundingPoints()
        {
            var point = new List<Point> { _rightMiddle, _centerMiddle, _centerBottom };
            Assert.Equal(point, GridHelpers.DetermineValidRadialPoints(_currentTest, _rightBottom));
        }
      
    }
}
