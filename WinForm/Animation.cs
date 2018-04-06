
using GameOfLife.Core;
using GameOfLife.Core.Models;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using WinForm.core;

namespace WinForm
{
    public class Animation
    {
        
        private PaintGrid _grid;
        private IGameOfLife _gameOfLife;
        
        public int Delay { get; set; }
        private int iteration = 0;
        public bool cancelled = false;
        private System.Windows.Forms.Label _iterationCount;
        public Animation(PaintGrid dgv, IGameOfLife gameOfLife, System.Windows.Forms.Label iterationCount)
        {
            _grid = dgv;
            _gameOfLife = gameOfLife;
            Delay = 100;
            _iterationCount = iterationCount;
        }



        public void repaint()
        {
            
            for (int x = 0; x < _gameOfLife.GridSize.X; x++)
            {
                for (int y = 0; y < _gameOfLife.GridSize.Y; y++)
                {
                    var point = new GameOfLife.Core.Models.Point { X = x, Y = y };
                    var state = _gameOfLife.GetState(point);
                    SetCellColor(point, state);
                }
            }
        }

        public void SetCellColor(GameOfLife.Core.Models.Point point, CellState state)
        {
            if (state == CellState.ALIVE || state == CellState.SPAWNING)
            {
                _grid.Rows[point.X].Cells[point.Y].Style.BackColor = Color.Red;
            }
            else
            {
                _grid.Rows[point.X].Cells[point.Y].Style.BackColor = Color.White;
            }
        }

        public void animate(object i)
        {

            while (!cancelled)
            {
                Thread.Sleep(Delay);
                update();

            }
        }

        public void update()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var changed = _gameOfLife.UpdateState();
            repaint();
            _gameOfLife.NextGenaration(changed);
            iteration++;
            stopwatch.Stop();
            _iterationCount.SetPropertyThreadSafe(() => _iterationCount.Text, "iteration: "+ iteration.ToString()+" "+ stopwatch.ElapsedMilliseconds+"ms"); 
           
        }
    }
}
