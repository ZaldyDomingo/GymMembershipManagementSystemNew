using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMembershipManagementSystem
{

    public class OvalButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Create a Graphics object
            Graphics g = pevent.Graphics;

            // Set a default color if the BackColor is transparent
            Color fillColor = this.BackColor == Color.Empty ? SystemColors.Control : this.BackColor;

            using (SolidBrush brush = new SolidBrush(fillColor))
            {
                // Draw the oval shape
                g.FillEllipse(brush, 0, 0, this.Width, this.Height);
            }

            // Draw the button text
            TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Call the base class OnPaint method
            base.OnPaint(pevent);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Redraw the button when resized
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.LightGray; // Change color on mouse enter
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = SystemColors.Control; // Restore color on mouse leave
            base.OnMouseLeave(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Prevent the default background painting
        }
    }
}