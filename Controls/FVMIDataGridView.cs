using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVMI_INSPECTION.Controls
{
    internal class FVMIDataGridView : DataGridView
    {
        private bool isUV = true;
        public bool IsUV { get => isUV; set
            {
                isUV = value;
                Refresh();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!isUV)
            {
                Rows.Clear();
                TextRenderer.DrawText(e.Graphics, "N\\A", Font, ClientRectangle, Color.Red, BackgroundColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }
        }
    }
}
