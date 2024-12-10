using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMembershipManagementSystem.Classes
{
    public class ShadowPanel : Panel
    {
        public int ShadowSize { get; set; } = 10;
        public Color ShadowColor { get; set; } = Color.Gray;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw shadow
            Graphics g = e.Graphics;
            Rectangle shadowRect = new Rectangle(
                ShadowSize,
                ShadowSize,
                this.Width - ShadowSize,
                this.Height - ShadowSize);
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(80, ShadowColor)))
            {
                g.FillRectangle(shadowBrush, shadowRect);
            }
        }
    }
}
