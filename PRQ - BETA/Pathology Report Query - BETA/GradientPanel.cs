using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Pathology_Report_Query___BETA
{
    class GradientPanel : Panel
    {
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush linGradBrush = new LinearGradientBrush(this.ClientRectangle, Color.Black, Color.Purple, 90F))
            {
                Graphics g = e.Graphics;
                g.FillRectangle(linGradBrush, this.ClientRectangle);
                base.OnPaint(e);
            }
        }
    }
}
