using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing.Drawing2D;

namespace PharmacyManagementSystem
{
    public class RoundedTextBox : UserControl
    {
        private readonly TextBox _textBox = new();
        private int _borderRadius = 10;
        private int _borderSize = 1;
        private int _focusBorderSize = 2;
        private Color _borderColor = Color.FromArgb(170, 183, 196);
        private Color _hoverBorderColor = Color.FromArgb(104, 133, 163);
        private Color _focusBorderColor = Color.FromArgb(0, 123, 255);
        private Color _focusBackColor = Color.FromArgb(248, 252, 255);
        private bool _focused;
        private bool _hovered;

        public RoundedTextBox()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            ForeColor = Color.FromArgb(51, 51, 51);
            Size = new Size(260, 40);
            Padding = new Padding(14, 8, 14, 8);

            _textBox.BorderStyle = BorderStyle.None;
            _textBox.Location = new Point(Padding.Left, Padding.Top + 1);
            _textBox.Width = Width - Padding.Horizontal;
            _textBox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            _textBox.BackColor = BackColor;
            _textBox.ForeColor = ForeColor;
            _textBox.Font = Font;
            _textBox.TextChanged += (_, _) => OnTextChanged(EventArgs.Empty);
            _textBox.GotFocus += (_, _) =>
            {
                _focused = true;
                ApplyStateColors();
                Invalidate();
            };
            _textBox.LostFocus += (_, _) =>
            {
                _focused = false;
                ApplyStateColors();
                Invalidate();
            };
            _textBox.MouseEnter += (_, _) => SetHovered(true);
            _textBox.MouseLeave += (_, _) => SetHovered(false);

            Controls.Add(_textBox);
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [AllowNull]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => _textBox.Text;
            set => _textBox.Text = value ?? string.Empty;
        }

        [Category("Behavior")]
        public bool UseSystemPasswordChar
        {
            get => _textBox.UseSystemPasswordChar;
            set => _textBox.UseSystemPasswordChar = value;
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
        public int FocusBorderSize
        {
            get => _focusBorderSize;
            set
            {
                _focusBorderSize = Math.Max(1, value);
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
        public Color HoverBorderColor
        {
            get => _hoverBorderColor;
            set
            {
                _hoverBorderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color FocusBorderColor
        {
            get => _focusBorderColor;
            set
            {
                _focusBorderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        public Color FocusBackColor
        {
            get => _focusBackColor;
            set
            {
                _focusBackColor = value;
                ApplyStateColors();
                Invalidate();
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            ApplyStateColors();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            _textBox.ForeColor = ForeColor;
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            _textBox.Font = Font;
            UpdateInnerTextBoxBounds();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateInnerTextBoxBounds();
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _textBox.Focus();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            SetHovered(true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetHovered(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            if (bounds.Width <= 0 || bounds.Height <= 0)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? SystemColors.Control);

            using var fillPath = CreateRoundPath(bounds, BorderRadius);
            Region = new Region(fillPath);

            using var fillBrush = new SolidBrush(GetCurrentBackColor());
            e.Graphics.FillPath(fillBrush, fillPath);

            if (BorderSize > 0)
            {
                var borderSize = _focused ? FocusBorderSize : BorderSize;
                var inset = borderSize / 2;
                var borderBounds = new Rectangle(inset, inset, Width - borderSize - 1, Height - borderSize - 1);
                using var borderPath = CreateRoundPath(borderBounds, BorderRadius);
                using var borderPen = new Pen(GetCurrentBorderColor(), borderSize);
                e.Graphics.DrawPath(borderPen, borderPath);
            }
        }

        private Color GetCurrentBackColor()
        {
            return _focused ? FocusBackColor : BackColor;
        }

        private Color GetCurrentBorderColor()
        {
            if (_focused)
            {
                return FocusBorderColor;
            }

            return _hovered ? HoverBorderColor : BorderColor;
        }

        private void ApplyStateColors()
        {
            _textBox.BackColor = GetCurrentBackColor();
        }

        private void SetHovered(bool hovered)
        {
            if (_hovered == hovered)
            {
                return;
            }

            _hovered = hovered;
            Invalidate();
        }

        private void UpdateInnerTextBoxBounds()
        {
            _textBox.Location = new Point(Padding.Left, Math.Max(Padding.Top, (Height - _textBox.Height) / 2));
            _textBox.Width = Math.Max(0, Width - Padding.Horizontal);
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
