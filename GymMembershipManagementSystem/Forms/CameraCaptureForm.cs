using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace GymMembershipManagementSystem.Forms
{
    public partial class CameraCaptureForm : Form
    {
        private FilterInfoCollection videoDevices; // List of available video devices
        private VideoCaptureDevice videoSource;    // Current video device
        public Image CapturedImage { get; private set; } // To store the captured image
        public CameraCaptureForm()
        {
            InitializeComponent();
            InitializeCamera();
        }
        private void InitializeCamera()
        {
            try
            {
                // Get list of video input devices (webcams)
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("No camera devices found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close(); // Close the form if no camera is available
                    return;
                }

                // Initialize the first available camera
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;

                // Start the video feed
                videoSource.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize the camera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close(); // Close the form if there's an error
            }
        }
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Display the live feed in a PictureBox
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxLiveFeed.Image = frame;
        }
        private void buttonCapture_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                // Capture the current frame from the live feed
                CapturedImage = (Image)pictureBoxLiveFeed.Image.Clone();

                // Stop the video feed
                videoSource.SignalToStop();

                // Inform the user and close the form
                MessageBox.Show("Photo captured successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No active camera feed to capture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Stop the video feed and close the form
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Ensure the video feed is stopped when the form is closed
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
            }
            base.OnFormClosing(e);
        }
    }
}
