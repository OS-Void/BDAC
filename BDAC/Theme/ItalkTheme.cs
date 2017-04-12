#region Imports

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

// Creator: HazelDev
// Site   : HazelDev.com
// Created: 23.Jul.2014
// Changed: 24.Jan.2015
// Version: 1.4.0

namespace iTalk
{
   
    #region Button 2

    public class iTalk_Button_2 : Control
    {

        #region Variables

        private int MouseState;
        private GraphicsPath Shape;
        private LinearGradientBrush InactiveGB;
        private LinearGradientBrush PressedGB;
        private LinearGradientBrush PressedContourGB;
        private Rectangle R1;
        private Pen P1;
        private Pen P3;
        private Image _Image;
        private Size _ImageSize;
        private StringAlignment _TextAlignment = StringAlignment.Center;
        private ContentAlignment _ImageAlign = ContentAlignment.MiddleLeft;

        #endregion

        #region Image Designer

        private static PointF ImageLocation(StringFormat SF, SizeF Area, SizeF ImageArea)
        {
            PointF MyPoint = default(PointF);
            switch (SF.Alignment)
            {
                case StringAlignment.Center:
                    MyPoint.X = Convert.ToSingle((Area.Width - ImageArea.Width) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.X = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.X = Area.Width - ImageArea.Width - 2;
                    break;
            }

            switch (SF.LineAlignment)
            {
                case StringAlignment.Center:
                    MyPoint.Y = Convert.ToSingle((Area.Height - ImageArea.Height) / 2);
                    break;
                case StringAlignment.Near:
                    MyPoint.Y = 2;
                    break;
                case StringAlignment.Far:
                    MyPoint.Y = Area.Height - ImageArea.Height - 2;
                    break;
            }
            return MyPoint;
        }

        private StringFormat GetStringFormat(ContentAlignment _ContentAlignment)
        {
            StringFormat SF = new StringFormat();
            switch (_ContentAlignment)
            {
                case ContentAlignment.MiddleCenter:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.MiddleLeft:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.TopCenter:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.TopLeft:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.TopRight:
                    SF.LineAlignment = StringAlignment.Near;
                    SF.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.BottomCenter:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomLeft:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.BottomRight:
                    SF.LineAlignment = StringAlignment.Far;
                    SF.Alignment = StringAlignment.Far;
                    break;
            }
            return SF;
        }

        #endregion

        #region Properties

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

        public StringAlignment TextAlignment
        {
            get { return this._TextAlignment; }
            set
            {
                this._TextAlignment = value;
                this.Invalidate();
            }
        }

        protected Size ImageSize
        {
            get { return _ImageSize; }
        }

        public ContentAlignment ImageAlign
        {
            get { return _ImageAlign; }
            set
            {
                _ImageAlign = value;
                Invalidate();
            }
        }

        #endregion

        #region EventArgs

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            Invalidate();
            base.OnMouseClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            MouseState = 0;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            MouseState = 1;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {

            MouseState = 0;
            // [Inactive]
            Invalidate();
            // Update control
            base.OnMouseLeave(e);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        #endregion

        public iTalk_Button_2()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 14);
            ForeColor = Color.White;
            Size = new Size(166, 40);
            _TextAlignment = StringAlignment.Center;
            P1 = new Pen(Color.FromArgb(0, 118, 176));
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();
                R1 = new Rectangle(0, 0, Width, Height);

                InactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(0, 176, 231), Color.FromArgb(0, 152, 224), 90f);
                PressedGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(0, 118, 176), Color.FromArgb(0, 149, 222), 90f);
                PressedContourGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(0, 118, 176), Color.FromArgb(0, 118, 176), 90f);

                P3 = new Pen(PressedContourGB);
            }

            var _Shape = Shape;
            _Shape.AddArc(0, 0, 10, 10, 180, 90);
            _Shape.AddArc(Width - 11, 0, 10, 10, -90, 90);
            _Shape.AddArc(Width - 11, Height - 11, 10, 10, 0, 90);
            _Shape.AddArc(0, Height - 11, 10, 10, 90, 90);
            _Shape.CloseAllFigures();

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var _G = e.Graphics;
            _G.SmoothingMode = SmoothingMode.HighQuality;

            PointF ipt = ImageLocation(GetStringFormat(ImageAlign), Size, ImageSize);

            switch (MouseState)
            {
                case 0:
                    _G.FillPath(InactiveGB, Shape);
                    _G.DrawPath(P1, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
                case 1:
                    _G.FillPath(PressedGB, Shape);
                    _G.DrawPath(P3, Shape);
                    if ((Image == null))
                    {
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    else
                    {
                        _G.DrawImage(_Image, ipt.X, ipt.Y, ImageSize.Width, ImageSize.Height);
                        _G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat
                        {
                            Alignment = _TextAlignment,
                            LineAlignment = StringAlignment.Center
                        });
                    }
                    break;
            }
            base.OnPaint(e);
        }
    }

    #endregion

    #region Label

    public class iTalk_Label : Label
    {

        public iTalk_Label()
        {
            Font = new Font("Segoe UI", 8);
            ForeColor = Color.FromArgb(142, 142, 142);
            BackColor = Color.Transparent;
        }
    }

    #endregion

    #region Separator

    public class iTalk_Separator : Control
    {

        public iTalk_Separator()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.Size = new Size(120, 10);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(184, 183, 188)), 0, 5, Width, 5);
        }
    }

    #endregion

    #region SeparatorV

    public class iTalk_SeparatorV : Control
    {

        public iTalk_SeparatorV()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            this.Size = new Size(10, 100);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(184, 183, 188)), 0, 0, 0, Height);
        }
    }

    #endregion

    #region CheckBox

    [DefaultEvent("CheckedChanged")]
    public class iTalk_CheckBox : Control
    {

        #region Variables

        private GraphicsPath Shape;
        private LinearGradientBrush GB;
        private Rectangle R1;
        private Rectangle R2;
        private bool _Checked;
        public event CheckedChangedEventHandler CheckedChanged;
        public delegate void CheckedChangedEventHandler(object sender);

        #endregion

        #region Properties

        public bool Checked
        {
            get { return _Checked; }
            set
            {
                _Checked = value;
                if (CheckedChanged != null)
                {
                    CheckedChanged(this);
                }
                Invalidate();
            }
        }

        #endregion

        public iTalk_CheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10);
            Size = new Size(120, 26);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { return; }

            _Checked = !_Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this);
            }

            Invalidate();
            base.OnMouseClick(e);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnResize(System.EventArgs e)
        {
            if (Width > 0 && Height > 0)
            {
                Shape = new GraphicsPath();

                R1 = new Rectangle(17, 0, Width, Height + 1);
                R2 = new Rectangle(0, 0, Width, Height);
                GB = new LinearGradientBrush(new Rectangle(0, 0, 25, 25), Color.FromArgb(250, 250, 250), Color.FromArgb(240, 240, 240), 90);

                var _Shape = Shape;
                _Shape.AddArc(0, 0, 7, 7, 180, 90);
                _Shape.AddArc(7, 0, 7, 7, -90, 90);
                _Shape.AddArc(7, 7, 7, 7, 0, 90);
                _Shape.AddArc(0, 7, 7, 7, 90, 90);
                _Shape.CloseAllFigures();
                Height = 15;
            }

            Invalidate();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var _G = e.Graphics;
            _G.Clear(Color.FromArgb(246, 246, 246));
            _G.SmoothingMode = SmoothingMode.AntiAlias;
            // Fill the body of the CheckBox
            _G.FillPath(GB, Shape);
            // Draw the border
            _G.DrawPath(new Pen(Color.FromArgb(160, 160, 160)), Shape);
            // Draw the string
            _G.DrawString(Text, Font, new SolidBrush(Color.FromArgb(64, 64, 64)), R1, new StringFormat { LineAlignment = StringAlignment.Center });

            if (Checked)
            {
                _G.DrawString("ü", new Font("Wingdings", 14), new SolidBrush(Color.FromArgb(64, 64, 64)), new Rectangle(-2, 1, Width, Height), new StringFormat { LineAlignment = StringAlignment.Center });
            }
            e.Dispose();
        }
    }

    #endregion

    #region TabControl

    class iTalk_TabControl : TabControl
    {

        // NOTE: For best quality icons/images on the TabControl; from the associated ImageList, set
        // the image size (24,24) so it can fit in the tab rectangle. However, to ensure a
        // high-quality image drawing, make sure you only add (32,32) images and not (24,24) as
        // determined in the ImageList

        // INFO: A free, non-commercial icon list that would fit in perfectly with the TabControl is
        // Wireframe Toolbar Icons by Gentleface. Licensed under Creative Commons Attribution.
        // Check it out from here: http://www.gentleface.com/free_icon_set.html

        public iTalk_TabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer, true);

            DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(44, 135);
            DrawMode = TabDrawMode.OwnerDrawFixed;

            foreach (TabPage Page in this.TabPages)
            {
                Page.BackColor = Color.FromArgb(246, 246, 246);
            }
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();

            base.DoubleBuffered = true;
            SizeMode = TabSizeMode.Fixed;
            Appearance = TabAppearance.Normal;
            Alignment = TabAlignment.Left;
        }


        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is TabPage)
            {
                IEnumerator enumerator;
                try
                {
                    enumerator = this.Controls.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        TabPage current = (TabPage)enumerator.Current;
                        current = new TabPage();
                    }
                }
                finally
                {
                    e.Control.BackColor = Color.FromArgb(246, 246, 246);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);

            var _Graphics = G;

            _Graphics.Clear(Color.FromArgb(246, 246, 246));
            _Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            _Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            _Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

            // Draw tab selector background
            _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(54, 57, 64)), new Rectangle(-5, 0, ItemSize.Height + 4, Height));
            // Draw vertical line at the end of the tab selector rectangle
            _Graphics.DrawLine(new Pen(Color.FromArgb(25, 26, 28)), ItemSize.Height - 1, 0, ItemSize.Height - 1, Height);

            for (int TabIndex = 0; TabIndex <= TabCount - 1; TabIndex++)
            {
                if (TabIndex == SelectedIndex)
                {
                    Rectangle TabRect = new Rectangle(new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));

                    // Draw background of the selected tab
                    _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(35, 36, 38)), TabRect.X, TabRect.Y, TabRect.Width - 4, TabRect.Height + 3);
                    // Draw a tab highlighter on the background of the selected tab
                    Rectangle TabHighlighter = new Rectangle(new Point(GetTabRect(TabIndex).X - 2, GetTabRect(TabIndex).Location.Y - (TabIndex == 0 ? 1 : 1)), new Size(4, GetTabRect(TabIndex).Height - 7));
                    _Graphics.FillRectangle(new SolidBrush(Color.FromArgb(89, 169, 222)), TabHighlighter);
                    // Draw tab text
                    _Graphics.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(Color.FromArgb(254, 255, 255)), new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), new StringFormat { Alignment = StringAlignment.Near });

                    if (this.ImageList != null)
                    {
                        int Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            _Graphics.DrawImage(ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9, TabRect.Y + 6, 24, 24);
                        }
                    }
                }
                else
                {
                    Rectangle TabRect = new Rectangle(new Point(GetTabRect(TabIndex).Location.X - 2, GetTabRect(TabIndex).Location.Y - 2), new Size(GetTabRect(TabIndex).Width + 3, GetTabRect(TabIndex).Height - 8));
                    _Graphics.DrawString(TabPages[TabIndex].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(Color.FromArgb(159, 162, 167)), new Rectangle(TabRect.Left + 40, TabRect.Top + 12, TabRect.Width - 40, TabRect.Height), new StringFormat { Alignment = StringAlignment.Near });

                    if (this.ImageList != null)
                    {
                        int Index = TabPages[TabIndex].ImageIndex;
                        if (!(Index == -1))
                        {
                            _Graphics.DrawImage(ImageList.Images[TabPages[TabIndex].ImageIndex], TabRect.X + 9, TabRect.Y + 6, 24, 24);
                        }
                    }

                }
            }
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);
            G.Dispose();
            B.Dispose();
        }
    }

    #endregion
    
}