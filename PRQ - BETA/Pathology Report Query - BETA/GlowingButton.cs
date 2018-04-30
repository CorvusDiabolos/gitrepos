using System;
using System.Drawing;
using System.Windows.Forms;
public class GlowingButton : Button
{
    Timer glowTimer;
    Timer appearTimer;
    int alpha = 0;
    public Color GlowColor { get; set; } //set these colors in properties
    public Color MouseDownBackColor { get; set; }
    public GlowingButton()
    {
        this.DoubleBuffered = true;
        glowTimer = new Timer() { Interval = 50 };
        glowTimer.Tick += glowTimer_Tick;
        appearTimer = new Timer() { Interval = 50 };
        appearTimer.Tick += appearTimer_Tick;
        this.FlatStyle = System.Windows.Forms.FlatStyle.Flat; //can also apply this technique without setting style to flat, by turning off visual style back color and changing the BackColor using timer.
        this.FlatAppearance.BorderSize = 0;
        //***commenting out as they often override properties at compile; want to keep custom options open.
        //this.GlowColor = Color.Gold; //defaults to gold; can be changed in code or via properties
        //this.FlatAppearance.MouseDownBackColor = Color.Gold; //defaults to gold; can be changed in code or via properties; setting to bit brighter than GlowColor is more noticeable
    }
    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        this.FlatAppearance.MouseOverBackColor = CalculateColor();
        glowTimer.Start();
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        glowTimer.Stop();
        alpha = 0;
        this.FlatAppearance.MouseOverBackColor = CalculateColor();
    }


    protected override void OnVisibleChanged(EventArgs e)
    {
        base.OnVisibleChanged(e);
        if (this.Visible == true)
        {
            this.BackColor = Color.White;
            this.BackColor = CalculateColor();
            appearTimer.Start();
        }

    }
    void VisibleEndTimer(EventArgs e)
    {
        this.BackColor = Color.Transparent;
        alpha = 0;
        this.BackColor = CalculateColor();
    }

    void appearTimer_Tick(object sender, EventArgs e)
    {
        int increment = 60;
        if (alpha + increment < 255)
        {
            alpha += increment;
        }
        else
        {
            appearTimer.Stop();
            alpha = 255;
            VisibleEndTimer(e);
        }

        this.BackColor = CalculateColor();
    }
    void glowTimer_Tick(object sender, EventArgs e)
    {
        int increment = 35;
        if (alpha + increment < 255)
        {
            alpha += increment;
        }
        else
        {
            glowTimer.Stop();
            alpha = 255;
        }

        this.FlatAppearance.MouseOverBackColor = CalculateColor();
    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            glowTimer.Dispose();
            appearTimer.Dispose();
        }
        base.Dispose(disposing);
    }
    private Color CalculateColor()
    {
        return AlphaBlend(Color.FromArgb(alpha, GlowColor), this.BackColor);
    }
    public Color AlphaBlend(Color A, Color B)
    {
        var r = (A.R * A.A / 255) + (B.R * B.A * (255 - A.A) / (255 * 255));
        var g = (A.G * A.A / 255) + (B.G * B.A * (255 - A.A) / (255 * 255));
        var b = (A.B * A.A / 255) + (B.B * B.A * (255 - A.A) / (255 * 255));
        var a = A.A + (B.A * (255 - A.A) / 255);
        return Color.FromArgb(a, r, g, b);
    }
}