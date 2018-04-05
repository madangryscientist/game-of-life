using GameOfLife.Core;
using GameOfLife.Core.Models;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        private IGameOfLife _gameOfLife;
        private Animation _animation;
        Thread backgroundThread;
        private GridSize gridSize = new GridSize() { X = 50, Y = 50 };
        public Form1()
        {
            InitializeComponent();
            paintGrid1.SuspendLayout();
            for (int x = 0; x < gridSize.X; x++)
            {
                paintGrid1.Columns.Add("", "");
                paintGrid1.Columns[x].Width = paintGrid1.Size.Width / gridSize.X - 1;
            }

            paintGrid1.Rows.Add(gridSize.Y);

            for (int x = 0; x < gridSize.Y; x++)
            {
                paintGrid1.Rows[x].Height = paintGrid1.Size.Height / gridSize.Y - 1;
            }
            paintGrid1.ResumeLayout();
            _gameOfLife = new GameOfLife.Core.GameOfLife(gridSize);
            _animation = new Animation(paintGrid1, _gameOfLife, label2);
            paintGrid1.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            paintGrid1.DefaultCellStyle.SelectionForeColor = Color.Transparent;
            textBox1.Text = _animation.Delay.ToString();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _animation.cancelled = true;
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (backgroundThread == null)
            {
                backgroundThread = new Thread(new ParameterizedThreadStart(_animation.animate));
                backgroundThread.Start(0);

            }
        }

        private void paintGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var point = new GameOfLife.Core.Models.Point { X = paintGrid1.CurrentCell.RowIndex, Y = paintGrid1.CurrentCell.ColumnIndex };
            var state = _gameOfLife.ToggleState(point);

            _animation.repaint();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void textChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int i))
            {
                _animation.Delay = i;
            }
        }
    }
}
