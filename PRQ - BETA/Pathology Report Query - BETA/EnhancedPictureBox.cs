using System.Windows.Forms;
using System.Drawing;

namespace Pathology_Report_Query___BETA
{
    class EnhancedPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.DarkViolet, 4, ButtonBorderStyle.Solid, Color.DarkViolet, 4, ButtonBorderStyle.Solid, Color.DarkViolet, 4, ButtonBorderStyle.Solid, Color.DarkViolet, 4, ButtonBorderStyle.Solid);
        }
    }
}
