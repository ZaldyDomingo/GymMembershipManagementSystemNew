using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMembershipManagementSystem.Classes
{
    public class roundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 30;  // You can set the corner radius here

        public roundedPanel()
        {
            // Set the default property values for the panel.
            this.DoubleBuffered = true;
            this.Padding = new Padding(10); // Optional: adds padding inside the panel
        }

        // Override the OnPaint method to draw a custom panel with rounded edges
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Create a rounded rectangle path
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(this.Width - CornerRadius - 1, 0, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(this.Width - CornerRadius - 1, this.Height - CornerRadius - 1, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(0, this.Height - CornerRadius - 1, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            // Set the region for the panel, so its area is clipped to the rounded edges
            this.Region = new Region(path);

            // Optional: Draw the border if you want
            g.DrawPath(Pens.Black, path);

            // Fill the inside of the panel
            g.FillPath(Brushes.White, path);  // You can change the color here
        }
    }
}
