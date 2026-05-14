using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace PharmacyManagementSystem
{
    public class RoundedButton : Button
    {
        private int _borderRadius = 10;
        private int _borderSize;
        private Color _borderColor = Color.Transparent;
        private Color _normalBackColor;

        public RoundedButton()
        {
            Cursor = Cursors.Hand;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            ResizeRedraw = true;
        }

        [Category("Appearance")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("Appearance")]
        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color HoverBackColor { get; set; } = Color.Empty;

        [Category("Appearance")]
        public Color PressedBackColor { get; set; } = Color.Empty;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            _normalBackColor = BackColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _normalBackColor = _normalBackColor == Color.Empty ? BackColor : _normalBackColor;
            if (HoverBackColor != Color.Empty)
            {
                BackColor = HoverBackColor;
            }

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_normalBackColor != Color.Empty)
            {
                BackColor = _normalBackColor;
            }

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (PressedBackColor != Color.Empty)
            {
                BackColor = PressedBackColor;
            }

            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (ClientRectangle.Contains(PointToClient(Cursor.Position)) && HoverBackColor != Color.Empty)
            {
                BackColor = HoverBackColor;
            }
            else if (_normalBackColor != Color.Empty)
            {
                BackColor = _normalBackColor;
            }

            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var bounds = ClientRectangle;
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                base.OnPaint(pevent);
                return;
            }

            using var path = CreateRoundPath(bounds, BorderRadius);
            Region = new Region(path);

            base.OnPaint(pevent);

            if (BorderSize > 0)
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                var borderBounds = new Rectangle(bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
                using var borderPath = CreateRoundPath(borderBounds, BorderRadius);
                using var borderPen = new Pen(BorderColor, BorderSize);
                pevent.Graphics.DrawPath(borderPen, borderPath);
            }
        }

        private static GraphicsPath CreateRoundPath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            var diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));

            if (diameter <= 0)
            {
                path.AddRectangle(bounds);
                path.CloseFigure();
                return path;
            }

            var arc = new Rectangle(bounds.Location, new Size(diameter, diameter));
            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
