using GameOfLife.Core.Models;
using Xunit;

namespace GameOfLife.Core.UnitTests
{
    public class CellStateHelpersTests
    {


        [Theory]
        [InlineData(0, CellState.DYING)]
        [InlineData(1, CellState.DYING)]
        [InlineData(2, CellState.ALIVE)]
        [InlineData(3, CellState.ALIVE)]
        [InlineData(4, CellState.DYING)]
        [InlineData(5, CellState.DYING)]
        [InlineData(6, CellState.DYING)]
        [InlineData(7, CellState.DYING)]
        [InlineData(8, CellState.DYING)]
        public void AliveCellTests(int neighborsCount, CellState finalState)
        {
            Assert.Equal(finalState, CellStateHelpers.DetermineState(CellState.ALIVE, neighborsCount));
        }
        [Theory]
        [InlineData(0, CellState.DEAD)]
        [InlineData(1, CellState.DEAD)]
        [InlineData(2, CellState.DEAD)]
        [InlineData(3, CellState.SPAWNING)]
        [InlineData(4, CellState.DEAD)]
        [InlineData(5, CellState.DEAD)]
        [InlineData(6, CellState.DEAD)]
        [InlineData(7, CellState.DEAD)]
        [InlineData(8, CellState.DEAD)]
        public void DeadCellTests(int neighborsCount, CellState finalState)
        {
            Assert.Equal(finalState, CellStateHelpers.DetermineState(CellState.DEAD, neighborsCount));
        }
        [Fact]
        public void CalculateAliveNeighboursCount_AllAlive()
        {
            var _currentTest = new CellState[3, 3] {
                { CellState.DYING, CellState.ALIVE, CellState.ALIVE, },
                { CellState.ALIVE, CellState.DYING, CellState.ALIVE, },
                { CellState.ALIVE, CellState.ALIVE, CellState.DYING, } };
            Assert.Equal(8, CellStateHelpers.CalculateAliveNeighboursCount(_currentTest, new Point { X =1,Y=1}));
        }
        [Fact]
        public void CalculateAliveNeighboursCount_AllDead()
        {
            var _currentTest = new CellState[3, 3] {
                { CellState.DEAD, CellState.SPAWNING, CellState.SPAWNING, },
                { CellState.SPAWNING, CellState.ALIVE, CellState.DEAD, },
                { CellState.DEAD, CellState.DEAD, CellState.DEAD, } };
            Assert.Equal(0, CellStateHelpers.CalculateAliveNeighboursCount(_currentTest, new Point { X = 1, Y = 1 }));
        }
    }
}
