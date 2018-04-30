using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

//https://social.msdn.microsoft.com/Forums/windows/en-US/628f8b29-1192-4c67-bae9-91547dd37039/assign-background-image-to-datagridview?forum=winforms

namespace Pathology_Report_Query___BETA
{
    class EnhancedDataGridView : DataGridView
    {
        private Image _backgroundPic;

        [Browsable(true)]
        public override Image BackgroundImage

        {
            get { return _backgroundPic; }

            set { _backgroundPic = value; }
        }
        protected override void PaintBackground(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle gridBounds)
        {
            base.PaintBackground(graphics, clipBounds, gridBounds);
            if (((this.BackgroundImage != null)))
            {
                graphics.FillRectangle(Brushes.Black, gridBounds);
                graphics.DrawImage(this.BackgroundImage, gridBounds);
            }

        }
        //Make BackgroundImage can be seen in all cells
        public void SetCellsTransparent()
        {
            this.EnableHeadersVisualStyles = false;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
            this.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;
            foreach (DataGridViewColumn col in this.Columns)
            {
                col.DefaultCellStyle.BackColor = Color.Transparent;
            }

        }
        private Color SuperDarkPurple()
        {
            Color superDarkPurple = new Color();
            superDarkPurple = Color.FromArgb(20, 0, 29);
            return superDarkPurple;
        }

    }
}

