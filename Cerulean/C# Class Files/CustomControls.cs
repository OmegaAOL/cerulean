using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Cerulean
{
    public class BorderPanel : FlowLayoutPanel
    {
        private const int ScrollStep = 150;

        public BorderPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(Color.LightGray))
            {
                e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Clear properly so no "lines" remain after scrolling
            e.Graphics.Clear(this.BackColor);
            base.OnPaintBackground(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.VerticalScroll.Visible)
            {
                int newValue = this.VerticalScroll.Value - Math.Sign(e.Delta) * ScrollStep;

                // Clamp to min/max
                if (newValue < this.VerticalScroll.Minimum) newValue = this.VerticalScroll.Minimum;
                if (newValue > this.VerticalScroll.Maximum) newValue = this.VerticalScroll.Maximum;

                this.VerticalScroll.Value = newValue;
                this.PerformLayout(); // forces scroll update
            }

            base.OnMouseWheel(e);
        }
    }

    public class BorderTreeView : TreeView
    {
        public BorderTreeView()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.BorderStyle = BorderStyle.None; // remove default border
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            using (Pen p = new Pen(Color.LightGray))
            {
                pevent.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }


    public class CeruleanButton : Button
    {
        private readonly Padding fixedPadding = new Padding(6, 1, 5, 0);
        private readonly Size fixedMinSize = new Size(75, 23);

        public CeruleanButton()
        {
            base.AutoSize = true;
            base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimumSize = fixedMinSize;
            this.Padding = fixedPadding;
            this.AutoEllipsis = true;
        }

        public override Size MinimumSize
        {
            get { return fixedMinSize; }
            set { /* ignore */ }
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.Padding = fixedPadding;
            base.OnPaddingChanged(e);
        }
    }

    public class TypeaheadBox : ListBox
    {
        public TypeaheadBox()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(Color.DarkGray))
            {
                e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }

    public class LinkButton : LinkLabel
    {
        private bool isMouseInside;
        private Color _originalLinkColor;
        private Color _linkColor;

        public new Color LinkColor
        {
            get { return _linkColor; }
            set
            {
                if (_linkColor != value)
                {
                    _linkColor = value;
                    base.LinkColor = value;
                    _originalLinkColor = value; // store original for hover
                    if (isMouseInside)
                        base.LinkColor = Darken(_originalLinkColor, false);
                }
            }
        }

        private Color Darken(Color color, bool dark)
        {
            float factor = dark ? 0.8f : 1.2f;
            int r = (int)(color.R * factor);
            int g = (int)(color.G * factor);
            int b = (int)(color.B * factor);

            r = Math.Min(255, r);
            g = Math.Min(255, g);
            b = Math.Min(255, b);

            return Color.FromArgb(color.A, r, g, b);
        }

        public LinkButton()
        {
            base.ActiveLinkColor = Darken(this.LinkColor, true);
            _originalLinkColor = this.LinkColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isMouseInside = true;
            base.OnMouseEnter(e);
            base.LinkColor = Darken(_originalLinkColor, false); // lighten on hover
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isMouseInside = false;
            base.OnMouseLeave(e);
            base.LinkColor = _originalLinkColor; // restore original color
        }
    }


    public class BorderPicBox : PictureBox
    {
        public BorderPicBox()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(Color.DarkGray))
            {
                e.Graphics.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}


