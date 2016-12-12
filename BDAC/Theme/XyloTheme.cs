using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

// Xylos Theme.
// Made by AeroRev9.

internal sealed class Helpers
{
    public enum RoundingStyle : byte
    {
        All,
        Top,
        Bottom,
        Left,
        Right,
        TopRight,
        BottomRight
    }

    public static Color ColorFromHex(string Hex)
    {
        return Color.FromArgb(checked((int)long.Parse(string.Format("FFFFFFFFFF{0}", Hex.Substring(1)), NumberStyles.HexNumber)));
    }
}

public class XylosTabControl : TabControl
{
    private Graphics G;
    private Rectangle Rect;

    private int _OverIndex;
    //private bool _FirstHeaderBorder;

    public bool FirstHeaderBorder { get; set; }

    private int OverIndex
    {
        get
        {
            return this._OverIndex;
        }
        set
        {
            this._OverIndex = value;
            base.Invalidate();
        }
    }

    public XylosTabControl()
    {
        this._OverIndex = -1;
        this.DoubleBuffered = true;
        base.Alignment = TabAlignment.Left;
        base.SizeMode = TabSizeMode.Fixed;
        base.ItemSize = new Size(40, 180);
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        base.SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        base.OnControlAdded(e);
        e.Control.BackColor = Color.White;
        e.Control.ForeColor = Helpers.ColorFromHex("#7C858E");
        e.Control.Font = new Font("Segoe UI", 9f);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.G = e.Graphics;
        this.G.SmoothingMode = SmoothingMode.HighQuality;
        this.G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        base.OnPaint(e);
        this.G.Clear(Helpers.ColorFromHex("#33373B"));
        checked
        {
            int num = base.TabPages.Count - 1;
            for (int i = 0; i <= num; i++)
            {
                this.Rect = base.GetTabRect(i);
                bool flag = string.IsNullOrEmpty(Conversions.ToString(base.TabPages[i].Tag));
                if (flag)
                {
                    bool flag2 = base.SelectedIndex == i;
                    if (flag2)
                    {
                        using (SolidBrush solidBrush = new SolidBrush(Helpers.ColorFromHex("#2B2F33")))
                        {
                            using (SolidBrush solidBrush2 = new SolidBrush(Helpers.ColorFromHex("#BECCD9")))
                            {
                                using (Font font = new Font("Segoe UI semibold", 9f))
                                {
                                    this.G.FillRectangle(solidBrush, new Rectangle(this.Rect.X - 5, this.Rect.Y + 1, this.Rect.Width + 7, this.Rect.Height));
                                    this.G.DrawString(base.TabPages[i].Text, font, solidBrush2, new Point(this.Rect.X + 50 + (base.ItemSize.Height - 180), this.Rect.Y + 12));
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SolidBrush solidBrush3 = new SolidBrush(Helpers.ColorFromHex("#919BA6")))
                        {
                            using (Font font2 = new Font("Segoe UI semibold", 9f))
                            {
                                this.G.DrawString(base.TabPages[i].Text, font2, solidBrush3, new Point(this.Rect.X + 50 + (base.ItemSize.Height - 180), this.Rect.Y + 12));
                            }
                        }
                    }
                    bool flag3 = this.OverIndex != -1 & base.SelectedIndex != this.OverIndex;
                    if (flag3)
                    {
                        using (SolidBrush solidBrush4 = new SolidBrush(Helpers.ColorFromHex("#2F3338")))
                        {
                            using (SolidBrush solidBrush5 = new SolidBrush(Helpers.ColorFromHex("#919BA6")))
                            {
                                using (Font font3 = new Font("Segoe UI semibold", 9f))
                                {
                                    this.G.FillRectangle(solidBrush4, new Rectangle(base.GetTabRect(this.OverIndex).X - 5, base.GetTabRect(this.OverIndex).Y + 1, base.GetTabRect(this.OverIndex).Width + 7, base.GetTabRect(this.OverIndex).Height));
                                    this.G.DrawString(base.TabPages[this.OverIndex].Text, font3, solidBrush5, new Point(base.GetTabRect(this.OverIndex).X + 50 + (base.ItemSize.Height - 180), base.GetTabRect(this.OverIndex).Y + 12));
                                }
                            }
                        }
                        bool flag4 = !Information.IsNothing(base.ImageList);
                        if (flag4)
                        {
                            bool flag5 = base.TabPages[this.OverIndex].ImageIndex >= 0;
                            if (flag5)
                            {
                                this.G.DrawImage(base.ImageList.Images[base.TabPages[this.OverIndex].ImageIndex], new Rectangle(base.GetTabRect(this.OverIndex).X + 25 + (base.ItemSize.Height - 180), (int)Math.Round(unchecked((double)base.GetTabRect(this.OverIndex).Y + ((double)base.GetTabRect(this.OverIndex).Height / 2.0 - 9.0))), 16, 16));
                            }
                        }
                    }
                    bool flag6 = !Information.IsNothing(base.ImageList);
                    if (flag6)
                    {
                        bool flag7 = base.TabPages[i].ImageIndex >= 0;
                        if (flag7)
                        {
                            this.G.DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Rectangle(this.Rect.X + 25 + (base.ItemSize.Height - 180), (int)Math.Round(unchecked((double)this.Rect.Y + ((double)this.Rect.Height / 2.0 - 9.0))), 16, 16));
                        }
                    }
                }
                else
                {
                    using (SolidBrush solidBrush6 = new SolidBrush(Helpers.ColorFromHex("#6A7279")))
                    {
                        using (Font font4 = new Font("Segoe UI", 7f, FontStyle.Bold))
                        {
                            using (Pen pen = new Pen(Helpers.ColorFromHex("#2B2F33")))
                            {
                                bool firstHeaderBorder = this.FirstHeaderBorder;
                                if (firstHeaderBorder)
                                {
                                    this.G.DrawLine(pen, new Point(this.Rect.X - 5, this.Rect.Y + 1), new Point(this.Rect.Width + 7, this.Rect.Y + 1));
                                }
                                else
                                {
                                    bool flag8 = i != 0;
                                    if (flag8)
                                    {
                                        this.G.DrawLine(pen, new Point(this.Rect.X - 5, this.Rect.Y + 1), new Point(this.Rect.Width + 7, this.Rect.Y + 1));
                                    }
                                }
                                this.G.DrawString(base.TabPages[i].Text.ToUpper(), font4, solidBrush6, new Point(this.Rect.X + 25 + (base.ItemSize.Height - 180), this.Rect.Y + 16));
                            }
                        }
                    }
                }
            }
        }
    }

    protected override void OnSelecting(TabControlCancelEventArgs e)
    {
        base.OnSelecting(e);
        bool flag = !Information.IsNothing(e.TabPage);
        if (flag)
        {
            bool flag2 = !string.IsNullOrEmpty(Conversions.ToString(e.TabPage.Tag));
            if (flag2)
            {
                e.Cancel = true;
            }
            else
            {
                this.OverIndex = -1;
            }
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        checked
        {
            int num = base.TabPages.Count - 1;
            for (int i = 0; i <= num; i++)
            {
                bool flag = base.GetTabRect(i).Contains(e.Location) & base.SelectedIndex != i & string.IsNullOrEmpty(Conversions.ToString(base.TabPages[i].Tag));
                if (flag)
                {
                    this.OverIndex = i;
                    break;
                }
                this.OverIndex = -1;
            }
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        this.OverIndex = -1;
    }
}
