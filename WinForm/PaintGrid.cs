using System.Windows.Forms;

namespace WinForm
{
    /// <summary>
    /// Extended DataGridView 
    /// DoubleBuffered. Restricts user selection of cells to facilitate seamless highlighting line drawing.
    /// </summary>
    /// <remarks></remarks>
    public class PaintGrid : DataGridView
    {

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        
        public PaintGrid()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnRowPrePaint(System.Windows.Forms.DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewPaintParts paintParts = (int)e.PaintParts - DataGridViewPaintParts.Focus;
            e.PaintParts = paintParts;
            base.OnRowPrePaint(e);
        }

        

        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // exDGV
            // 
            this.RowTemplate.Height = 24;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
