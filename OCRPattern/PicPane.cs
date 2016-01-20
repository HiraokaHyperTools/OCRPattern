using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OCRPattern {
    public partial class PicPane : UserControl {
        public PicPane() {
            InitializeComponent();
        }

        Image _Image = null;

        public Image Image {
            get { return _Image; }
            set {
                _Image = value; Invalidate();
                if (_Image != null) {
                    PelsPerMeter = new SizeF(
                        _Image.HorizontalResolution * 1.0f / 25.4f / 1000.0f,
                        _Image.VerticalResolution * 1.0f / 25.4f / 1000.0f
                        );
                    OnImageChanged();
                    OnResize(null);
                }
            }
        }

        private void OnImageChanged() {
            if (ImageChanged != null)
                ImageChanged(this, new EventArgs());
        }

        public event EventHandler ImageChanged;

        bool _CanSelRect = true;

        public bool CanSelRect { get { return _CanSelRect; } set { _CanSelRect = value; } }

        public override Size GetPreferredSize(Size proposedSize) {
            if (_Image != null) {
                return new Size(
                    (int)Math.Ceiling(_Image.Width * _Zoom),
                    (int)Math.Ceiling(_Image.Height * _Zoom)
                    );
            }
            return base.GetPreferredSize(proposedSize);
        }

        SizeF _PelsPerMeter = SizeF.Empty;

        public SizeF PelsPerMeter { get { return _PelsPerMeter; } set { _PelsPerMeter = value; } }

        float _Zoom = 1;

        public float Zoom {
            get { return _Zoom; }
            set {
                _Zoom = value;
                Invalidate();
                OnResize(null);
            }
        }

        bool _UseBright = false;

        public bool UseBright { get { return _UseBright; } set { _UseBright = value; Invalidate(); } }

        private void PicPane_Paint(object sender, PaintEventArgs e) {
            if (DesignMode) return;

            if (_Image != null) {
                Graphics cv = e.Graphics;
                cv.DrawImage(_Image, RectangleF.FromLTRB(0, 0, (_Image.Width * _Zoom), (_Image.Height * _Zoom)));

                if (RectangleF.Empty != _SelRect && PelsPerMeter.Width > 0 && PelsPerMeter.Height > 0) {
                    Rectangle rc = Rectangle.Truncate(RectangleF.FromLTRB(
                        _SelRect.Left * PelsPerMeter.Width * 1000 * _Zoom,
                        _SelRect.Top * PelsPerMeter.Height * 1000 * _Zoom,
                        _SelRect.Right * PelsPerMeter.Width * 1000 * _Zoom,
                        _SelRect.Bottom * PelsPerMeter.Height * 1000 * _Zoom
                        ));
                    cv.DrawRectangle(Pens.Blue, rc);
                    if (UseBright) cv.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Yellow)), rc);
                }
            }
        }

        private void PicPane_Load(object sender, EventArgs e) {
            DoubleBuffered = true;
        }

        RectangleF _SelRect = RectangleF.Empty;

        public RectangleF SelRect {
            get { return _SelRect; }
            set {
                if (_SelRect != value) {
                    _SelRect = value;
                    OnSelRectChanged(true);
                    Invalidate();
                }
            }
        }

        private void OnSelRectChanged(bool final) {
            if (SelRectChanged != null) SelRectChanged(this, new SelRectChangedEventArgs(final));
        }

        public event EventHandler<SelRectChangedEventArgs> SelRectChanged;

        PointF ptStart;

        private void PicPane_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && _CanSelRect) {
                ptStart = new PointF(
                    e.X / (PelsPerMeter.Width * 1000 * _Zoom),
                    e.Y / (PelsPerMeter.Height * 1000 * _Zoom)
                    );
                _SelRect = new RectangleF(
                    ptStart, SizeF.Empty
                );
                OnSelRectChanged(false);
                Invalidate();
            }
        }

        private void PicPane_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && Capture && _CanSelRect) {
                float x0 = ptStart.X;
                float x1 = e.X / (PelsPerMeter.Width * 1000 * _Zoom);
                float y0 = ptStart.Y;
                float y1 = e.Y / (PelsPerMeter.Height * 1000 * _Zoom);
                _SelRect = RectangleF.FromLTRB(
                    Math.Min(x0, x1),
                    Math.Min(y0, y1),
                    Math.Max(x0, x1),
                    Math.Max(y0, y1)
                );
                OnSelRectChanged(false);
                Invalidate();
            }
        }

        private void PicPane_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && Capture && _CanSelRect) {
                float x0 = ptStart.X;
                float x1 = e.X / (PelsPerMeter.Width * 1000 * _Zoom);
                float y0 = ptStart.Y;
                float y1 = e.Y / (PelsPerMeter.Height * 1000 * _Zoom);
                _SelRect = RectangleF.FromLTRB(
                    Math.Min(x0, x1),
                    Math.Min(y0, y1),
                    Math.Max(x0, x1),
                    Math.Max(y0, y1)
                );
                OnSelRectChanged(true);
                Invalidate();
            }
        }
    }

    public class SelRectChangedEventArgs : EventArgs {
        bool final;

        public SelRectChangedEventArgs(bool final) {
            this.final = final;
        }

        public bool Final { get { return final; } }
    }
}
