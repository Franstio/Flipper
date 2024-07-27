using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Models
{
    public class ImageZoomPanModel
    {
        public Point StartPos { get; set; } = Point.Empty;
        public Point MovPos { get; set; } = Point.Empty;
        public PictureBox PictureBox { get; set; }
        public bool isActive { get; set; } = false;
        public bool isHovering { get; set; } = false;    
        public float ZoomIncrement { get; set; } = 0.1F;
        public float ZoomValue { get; set; } = 0F;
        public Color BackgroundColor { get; set; } = Color.White;

        public ImageZoomPanModel(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
        }
    }
}
