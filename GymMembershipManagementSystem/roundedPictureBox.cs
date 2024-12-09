using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMembershipManagementSystem
{
    public partial class roundedPictureBox : UserControl
    {
        private Image _image;
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                this.Invalidate();  // Forces a repaint when the image is changed
            }
        }
        public roundedPictureBox()
        {
            InitializeComponent();
            this.DoubleBuffered = true;  // To reduce flickering during resizing
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_image != null)
            {
                // Create a GraphicsPath to define the rounded shape (circle or rounded rectangle)
                GraphicsPath path = new GraphicsPath();
                int radius = Math.Min(this.Width, this.Height) / 2; // Use the smaller dimension to ensure a circle
                path.AddEllipse(0, 0, this.Width, this.Height); // Rounded (ellipse) shape

                // Set the region to the path so only the rounded area is drawn
                this.Region = new Region(path);

                // Clip the graphics to the rounded path and draw the image
                e.Graphics.SetClip(path);
                e.Graphics.DrawImage(_image, 0, 0, this.Width, this.Height); // Draw image within the rounded path
            }
            else
            {
                // Optional: Draw a placeholder (like a gray circle) if no image is set
                e.Graphics.FillEllipse(Brushes.Gray, 0, 0, this.Width, this.Height);  // Placeholder circle
            }
        }

        // Override the OnResize method to trigger repaint on resizing
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();  // Forces the control to repaint when resized
        }

    }
}
