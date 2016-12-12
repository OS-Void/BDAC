using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Imaging;

//------------------
//Creator: aeonhack
//Site: elitevs.net
//Created: 08/02/2011
//Changed: 12/06/2011
//Version: 1.5.4
//------------------

abstract class ThemeControl154 : Control
{
    #region " Initialization "

    protected Graphics G;

    protected Bitmap B;
    public ThemeControl154()
    {
        SetStyle((ControlStyles)139270, true);

        _ImageSize = Size.Empty;
        Font = new Font("Verdana", 8);

        MeasureBitmap = new Bitmap(1, 1);
        MeasureGraphics = Graphics.FromImage(MeasureBitmap);

        DrawRadialPath = new GraphicsPath();

        InvalidateCustimization();
        //Remove?
    }

    protected override sealed void OnHandleCreated(EventArgs e)
    {
        InvalidateCustimization();
        ColorHook();

        if (!(_LockWidth == 0))
            Width = _LockWidth;
        if (!(_LockHeight == 0))
            Height = _LockHeight;

        Transparent = _Transparent;
        if (_Transparent && _BackColor)
            BackColor = Color.Transparent;

        base.OnHandleCreated(e);
    }

    private bool DoneCreation;
    protected override sealed void OnParentChanged(EventArgs e)
    {
        if (Parent != null)
        {
            OnCreation();
            DoneCreation = true;
        }

        base.OnParentChanged(e);
    }

    #endregion

    private void DoAnimation(bool i)
    {
        OnAnimation();
        if (i)
            Invalidate();
    }

    protected override sealed void OnPaint(PaintEventArgs e)
    {
        if (Width == 0 || Height == 0)
            return;

        if (_Transparent)
        {
            PaintHook();
            e.Graphics.DrawImage(B, 0, 0);
        }
        else
        {
            G = e.Graphics;
            PaintHook();
        }
    }

    #region " Size Handling "

    protected override sealed void OnSizeChanged(EventArgs e)
    {
        if (_Transparent)
        {
            InvalidateBitmap();
        }

        Invalidate();
        base.OnSizeChanged(e);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        if (!(_LockWidth == 0))
            width = _LockWidth;
        if (!(_LockHeight == 0))
            height = _LockHeight;
        base.SetBoundsCore(x, y, width, height, specified);
    }

    #endregion

    #region " State Handling "

    private bool InPosition;
    protected override void OnMouseEnter(EventArgs e)
    {
        InPosition = true;
        SetState(MouseState.Over);
        base.OnMouseEnter(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (InPosition)
            SetState(MouseState.Over);
        base.OnMouseUp(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
            SetState(MouseState.Down);
        base.OnMouseDown(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        InPosition = false;
        SetState(MouseState.None);
        base.OnMouseLeave(e);
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        if (Enabled)
            SetState(MouseState.None);
        else
            SetState(MouseState.Block);
        base.OnEnabledChanged(e);
    }

    protected MouseState State;
    private void SetState(MouseState current)
    {
        State = current;
        Invalidate();
    }

    #endregion

    #region " Base Properties "

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color ForeColor
    {
        get { return Color.Empty; }
        set { }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Image BackgroundImage
    {
        get { return null; }
        set { }
    }
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
        get { return ImageLayout.None; }
        set { }
    }

    public override string Text
    {
        get { return base.Text; }
        set
        {
            base.Text = value;
            Invalidate();
        }
    }
    public override Font Font
    {
        get { return base.Font; }
        set
        {
            base.Font = value;
            Invalidate();
        }
    }

    private bool _BackColor;
    [Category("Misc")]
    public override Color BackColor
    {
        get { return base.BackColor; }
        set
        {
            if (!IsHandleCreated && value == Color.Transparent)
            {
                _BackColor = true;
                return;
            }

            base.BackColor = value;
            if (Parent != null)
                ColorHook();
        }
    }

    #endregion

    #region " Public Properties "

    private bool _NoRounding;
    public bool NoRounding
    {
        get { return _NoRounding; }
        set
        {
            _NoRounding = value;
            Invalidate();
        }
    }

    private Image _Image;
    public Image Image
    {
        get { return _Image; }
        set
        {
            if (value == null)
            {
                _ImageSize = Size.Empty;
            }
            else
            {
                _ImageSize = value.Size;
            }

            _Image = value;
            Invalidate();
        }
    }

    private bool _Transparent;
    public bool Transparent
    {
        get { return _Transparent; }
        set
        {
            _Transparent = value;
            if (!IsHandleCreated)
                return;

            if (!value && !(BackColor.A == 255))
            {
                throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
            }

            SetStyle(ControlStyles.Opaque, !value);
            SetStyle(ControlStyles.SupportsTransparentBackColor, value);

            if (value)
                InvalidateBitmap();
            else
                B = null;
            Invalidate();
        }
    }

    private Dictionary<string, Color> Items = new Dictionary<string, Color>();
    public Bloom[] Colors
    {
        get
        {
            List<Bloom> T = new List<Bloom>();
            Dictionary<string, Color>.Enumerator E = Items.GetEnumerator();

            while (E.MoveNext())
            {
                T.Add(new Bloom(E.Current.Key, E.Current.Value));
            }

            return T.ToArray();
        }
        set
        {
            foreach (Bloom B in value)
            {
                if (Items.ContainsKey(B.Name))
                    Items[B.Name] = B.Value;
            }

            InvalidateCustimization();
            ColorHook();
            Invalidate();
        }
    }

    private string _Customization;
    public string Customization
    {
        get { return _Customization; }
        set
        {
            if (value == _Customization)
                return;

            byte[] Data = null;
            Bloom[] Items = Colors;

            try
            {
                Data = Convert.FromBase64String(value);
                for (int I = 0; I <= Items.Length - 1; I++)
                {
                    Items[I].Value = Color.FromArgb(BitConverter.ToInt32(Data, I * 4));
                }
            }
            catch
            {
                return;
            }

            _Customization = value;

            Colors = Items;
            ColorHook();
            Invalidate();
        }
    }

    #endregion

    #region " Private Properties "

    private Size _ImageSize;
    protected Size ImageSize
    {
        get { return _ImageSize; }
    }

    private int _LockWidth;
    protected int LockWidth
    {
        get { return _LockWidth; }
        set
        {
            _LockWidth = value;
            if (!(LockWidth == 0) && IsHandleCreated)
                Width = LockWidth;
        }
    }

    private int _LockHeight;
    protected int LockHeight
    {
        get { return _LockHeight; }
        set
        {
            _LockHeight = value;
            if (!(LockHeight == 0) && IsHandleCreated)
                Height = LockHeight;
        }
    }

    #endregion

    #region " Property Helpers "

    protected Pen GetPen(string name)
    {
        return new Pen(Items[name]);
    }
    protected Pen GetPen(string name, float width)
    {
        return new Pen(Items[name], width);
    }

    protected SolidBrush GetBrush(string name)
    {
        return new SolidBrush(Items[name]);
    }

    protected Color GetColor(string name)
    {
        return Items[name];
    }

    protected void SetColor(string name, Color value)
    {
        if (Items.ContainsKey(name))
            Items[name] = value;
        else
            Items.Add(name, value);
    }
    protected void SetColor(string name, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(r, g, b));
    }
    protected void SetColor(string name, byte a, byte r, byte g, byte b)
    {
        SetColor(name, Color.FromArgb(a, r, g, b));
    }
    protected void SetColor(string name, byte a, Color value)
    {
        SetColor(name, Color.FromArgb(a, value));
    }

    private void InvalidateBitmap()
    {
        if (Width == 0 || Height == 0)
            return;
        B = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
        G = Graphics.FromImage(B);
    }

    private void InvalidateCustimization()
    {
        MemoryStream M = new MemoryStream(Items.Count * 4);

        foreach (Bloom B in Colors)
        {
            M.Write(BitConverter.GetBytes(B.Value.ToArgb()), 0, 4);
        }

        M.Close();
        _Customization = Convert.ToBase64String(M.ToArray());
    }

    #endregion

    #region " User Hooks "

    protected abstract void ColorHook();
    protected abstract void PaintHook();

    protected virtual void OnCreation(){ }
    protected virtual void OnAnimation(){ }

    #endregion

    #region " Offset "

    private Rectangle OffsetReturnRectangle;
    protected Rectangle Offset(Rectangle r, int amount)
    {
        OffsetReturnRectangle = new Rectangle(r.X + amount, r.Y + amount, r.Width - (amount * 2), r.Height - (amount * 2));
        return OffsetReturnRectangle;
    }

    private Size OffsetReturnSize;
    protected Size Offset(Size s, int amount)
    {
        OffsetReturnSize = new Size(s.Width + amount, s.Height + amount);
        return OffsetReturnSize;
    }

    private Point OffsetReturnPoint;
    protected Point Offset(Point p, int amount)
    {
        OffsetReturnPoint = new Point(p.X + amount, p.Y + amount);
        return OffsetReturnPoint;
    }

    #endregion

    #region " Center "

    private Point CenterReturn;
    protected Point Center(Rectangle p, Rectangle c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X + c.X, (p.Height / 2 - c.Height / 2) + p.Y + c.Y);
        return CenterReturn;
    }
    protected Point Center(Rectangle p, Size c)
    {
        CenterReturn = new Point((p.Width / 2 - c.Width / 2) + p.X, (p.Height / 2 - c.Height / 2) + p.Y);
        return CenterReturn;
    }

    protected Point Center(Rectangle child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }
    protected Point Center(Size child)
    {
        return Center(Width, Height, child.Width, child.Height);
    }
    protected Point Center(int childWidth, int childHeight)
    {
        return Center(Width, Height, childWidth, childHeight);
    }

    protected Point Center(Size p, Size c)
    {
        return Center(p.Width, p.Height, c.Width, c.Height);
    }

    protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
    {
        CenterReturn = new Point(pWidth / 2 - cWidth / 2, pHeight / 2 - cHeight / 2);
        return CenterReturn;
    }

    #endregion

    #region " Measure "

    private Bitmap MeasureBitmap;
    //TODO: Potential issues during multi-threading.
    private Graphics MeasureGraphics;

    protected Size Measure()
    {
        return MeasureGraphics.MeasureString(Text, Font, Width).ToSize();
    }
    protected Size Measure(string text)
    {
        return MeasureGraphics.MeasureString(text, Font, Width).ToSize();
    }

    #endregion

    #region " DrawPixel "

    private SolidBrush DrawPixelBrush;
    protected void DrawPixel(Color c1, int x, int y)
    {
        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
        }
        else
        {
            DrawPixelBrush = new SolidBrush(c1);
            G.FillRectangle(DrawPixelBrush, x, y, 1, 1);
        }
    }

    #endregion

    #region " DrawCorners "

    private SolidBrush DrawCornersBrush;
    protected void DrawCorners(Color c1, int offset)
    {
        DrawCorners(c1, 0, 0, Width, Height, offset);
    }
    protected void DrawCorners(Color c1, Rectangle r1, int offset)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
    }
    protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
    {
        DrawCorners(c1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawCorners(Color c1)
    {
        DrawCorners(c1, 0, 0, Width, Height);
    }
    protected void DrawCorners(Color c1, Rectangle r1)
    {
        DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
    }
    protected void DrawCorners(Color c1, int x, int y, int width, int height)
    {
        if (_NoRounding)
            return;

        if (_Transparent)
        {
            B.SetPixel(x, y, c1);
            B.SetPixel(x + (width - 1), y, c1);
            B.SetPixel(x, y + (height - 1), c1);
            B.SetPixel(x + (width - 1), y + (height - 1), c1);
        }
        else
        {
            DrawCornersBrush = new SolidBrush(c1);
            G.FillRectangle(DrawCornersBrush, x, y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y, 1, 1);
            G.FillRectangle(DrawCornersBrush, x, y + (height - 1), 1, 1);
            G.FillRectangle(DrawCornersBrush, x + (width - 1), y + (height - 1), 1, 1);
        }
    }

    #endregion

    #region " DrawBorders "

    protected void DrawBorders(Pen p1, int offset)
    {
        DrawBorders(p1, 0, 0, Width, Height, offset);
    }
    protected void DrawBorders(Pen p1, Rectangle r, int offset)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
    }
    protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
    {
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2));
    }

    protected void DrawBorders(Pen p1)
    {
        DrawBorders(p1, 0, 0, Width, Height);
    }
    protected void DrawBorders(Pen p1, Rectangle r)
    {
        DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
    }
    protected void DrawBorders(Pen p1, int x, int y, int width, int height)
    {
        G.DrawRectangle(p1, x, y, width - 1, height - 1);
    }

    #endregion

    #region " DrawText "

    private Point DrawTextPoint;

    private Size DrawTextSize;
    protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
    {
        DrawText(b1, Text, a, x, y);
    }
    protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
    {
        if (text.Length == 0)
            return;

        DrawTextSize = Measure(text);
        DrawTextPoint = Center(DrawTextSize);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawString(text, Font, b1, x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Center:
                G.DrawString(text, Font, b1, DrawTextPoint.X + x, DrawTextPoint.Y + y);
                break;
            case HorizontalAlignment.Right:
                G.DrawString(text, Font, b1, Width - DrawTextSize.Width - x, DrawTextPoint.Y + y);
                break;
        }
    }

    protected void DrawText(Brush b1, Point p1)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, p1);
    }
    protected void DrawText(Brush b1, int x, int y)
    {
        if (Text.Length == 0)
            return;
        G.DrawString(Text, Font, b1, x, y);
    }

    #endregion

    #region " DrawImage "

    private Point DrawImagePoint;
    protected void DrawImage(HorizontalAlignment a, int x, int y)
    {
        DrawImage(_Image, a, x, y);
    }
    protected void DrawImage(Image image, HorizontalAlignment a, int x, int y)
    {
        if (image == null)
            return;
        DrawImagePoint = Center(image.Size);

        switch (a)
        {
            case HorizontalAlignment.Left:
                G.DrawImage(image, x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Center:
                G.DrawImage(image, DrawImagePoint.X + x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
            case HorizontalAlignment.Right:
                G.DrawImage(image, Width - image.Width - x, DrawImagePoint.Y + y, image.Width, image.Height);
                break;
        }
    }

    protected void DrawImage(Point p1)
    {
        DrawImage(_Image, p1.X, p1.Y);
    }
    protected void DrawImage(int x, int y)
    {
        DrawImage(_Image, x, y);
    }

    protected void DrawImage(Image image, Point p1)
    {
        DrawImage(image, p1.X, p1.Y);
    }
    protected void DrawImage(Image image, int x, int y)
    {
        if (image == null)
            return;
        G.DrawImage(image, x, y, image.Width, image.Height);
    }

    #endregion

    #region " DrawGradient "

    private LinearGradientBrush DrawGradientBrush;

    private Rectangle DrawGradientRectangle;
    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle);
    }
    protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(blend, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(ColorBlend blend, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }
    protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle);
        DrawGradientBrush.InterpolationColors = blend;
        G.FillRectangle(DrawGradientBrush, r);
    }


    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle);
    }
    protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawGradientRectangle = new Rectangle(x, y, width, height);
        DrawGradient(c1, c2, DrawGradientRectangle, angle);
    }

    protected void DrawGradient(Color c1, Color c2, Rectangle r)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillRectangle(DrawGradientBrush, r);
    }
    protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
        G.FillRectangle(DrawGradientBrush, r);
    }

    #endregion

    #region " DrawRadial "

    private GraphicsPath DrawRadialPath;
    private PathGradientBrush DrawRadialBrush1;
    private LinearGradientBrush DrawRadialBrush2;

    private Rectangle DrawRadialRectangle;
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, width / 2, height / 2);
    }
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, center.X, center.Y);
    }
    public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(blend, DrawRadialRectangle, cx, cy);
    }

    public void DrawRadial(ColorBlend blend, Rectangle r)
    {
        DrawRadial(blend, r, r.Width / 2, r.Height / 2);
    }
    public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
    {
        DrawRadial(blend, r, center.X, center.Y);
    }
    public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
    {
        DrawRadialPath.Reset();
        DrawRadialPath.AddEllipse(r.X, r.Y, r.Width - 1, r.Height - 1);

        DrawRadialBrush1 = new PathGradientBrush(DrawRadialPath);
        DrawRadialBrush1.CenterPoint = new Point(r.X + cx, r.Y + cy);
        DrawRadialBrush1.InterpolationColors = blend;

        if (G.SmoothingMode == SmoothingMode.AntiAlias)
        {
            G.FillEllipse(DrawRadialBrush1, r.X + 1, r.Y + 1, r.Width - 3, r.Height - 3);
        }
        else
        {
            G.FillEllipse(DrawRadialBrush1, r);
        }
    }


    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawRadialRectangle);
    }
    protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
    {
        DrawRadialRectangle = new Rectangle(x, y, width, height);
        DrawRadial(c1, c2, DrawRadialRectangle, angle);
    }

    protected void DrawRadial(Color c1, Color c2, Rectangle r)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
        G.FillEllipse(DrawRadialBrush2, r);
    }
    protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
    {
        DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
        G.FillEllipse(DrawRadialBrush2, r);
    }

    #endregion

    #region " CreateRound "

    private GraphicsPath CreateRoundPath;

    private Rectangle CreateRoundRectangle;
    public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
    {
        CreateRoundRectangle = new Rectangle(x, y, width, height);
        return CreateRound(CreateRoundRectangle, slope);
    }

    public GraphicsPath CreateRound(Rectangle r, int slope)
    {
        CreateRoundPath = new GraphicsPath(FillMode.Winding);
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270f, 90f);
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0f, 90f);
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90f, 90f);
        CreateRoundPath.CloseFigure();
        return CreateRoundPath;
    }

    #endregion

}

enum MouseState : byte
{
    None = 0,
    Over = 1,
    Down = 2,
    Block = 3
}

struct Bloom
{

    public string _Name;
    public string Name
    {
        get { return _Name; }
    }

    private Color _Value;
    public Color Value
    {
        get { return _Value; }
        set { _Value = value; }
    }

    public string ValueHex
    {
        get { return string.Concat("#", _Value.R.ToString("X2", null), _Value.G.ToString("X2", null), _Value.B.ToString("X2", null)); }
        set
        {
            try
            {
                _Value = ColorTranslator.FromHtml(value);
            }
            catch
            {
                return;
            }
        }
    }


    public Bloom(string name, Color value)
    {
        _Name = name;
        _Value = value;
    }
}
