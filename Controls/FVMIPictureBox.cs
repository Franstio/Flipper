using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FVMI_INSPECTION.Controls
{
    public class FVMIPictureBox : PictureBox
    {
        public Point StartPos { get; set; } = Point.Empty;
        public Point MovPos { get; set; } = Point.Empty;
        public bool isActive { get; set; } = false;
        public bool isHovering { get; set; } = false;
        public float ZoomIncrement { get; set; } = 0.1F;
        public float ZoomValue { get; set; } = 1F;
        public Color BackgroundColor { get; set; } = Color.White;
        private bool _isUV = true;
        public bool AllowZoom { get; set; } = true;
        public bool AllowPan { get; set; } = true;
        public bool IsUV { get => _isUV;
            set 
            { 
                _isUV = value;
                if (IsHandleCreated)
                    Invalidate();
            } 
        } 
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isActive && (AllowPan || AllowZoom))
            {
                MovPos = new Point(e.Location.X - StartPos.X, e.Location.Y - StartPos.Y);
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!IsUV)
            {
                e.Graphics.Clear(BackgroundColor);
                using (Font font = new Font("Segoe UI", 48))
                {
                    StringFormat format = new StringFormat();
                    format.LineAlignment = StringAlignment.Center;
                    format.Alignment = StringAlignment.Center;
                    e.Graphics.DrawString("N\\A", font, Brushes.Red,ClientRectangle,format );
                }
                return;
            }
            if (Image is null || Height <1 || Width < 1)
                return;
            if ((isActive || isHovering) && (AllowZoom || AllowPan))
            {
                var image = new Bitmap(Image, GetDisplayedImageSize());
                e.Graphics.Clear(BackgroundColor);
                if (ZoomValue != 0.00F && (isHovering && AllowZoom) )
                    e.Graphics.ScaleTransform(ZoomValue, ZoomValue);
                if (AllowPan)
                    e.Graphics.DrawImage(image, MovPos);
            }
        }
        private Size GetDisplayedImageSize()
        {
            Size containerSize = ClientSize;
            float containerAspectRatio = (float)containerSize.Height / (float)containerSize.Width;
            Size originalImageSize = Image.Size;
            float imageAspectRatio = (float)originalImageSize.Height / (float)originalImageSize.Width;

            Size result = new Size();
            if (containerAspectRatio > imageAspectRatio)
            {
                result.Width = containerSize.Width;
                result.Height = (int)(imageAspectRatio * (float)containerSize.Width);
            }
            else
            {
                result.Height = containerSize.Height;
                result.Width = (int)((1.0f / imageAspectRatio) * (float)containerSize.Height);
            }
            return result;
        }
        protected override void OnMouseHover(EventArgs e)
        {

            base.OnMouseHover(e);
            isHovering = (AllowZoom || AllowZoom) && true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovering =  false;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!AllowPan && !AllowZoom)
                return;
            isActive = true;
            StartPos = new Point(e.Location.X - MovPos.X,
                            e.Location.Y - MovPos.Y);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            isActive  = false;
        }
    }
}
