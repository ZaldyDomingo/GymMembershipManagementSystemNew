using GymMembershipManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMembershipManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            MaskedUserNameText();
            MaskedUserPasswordText();   
            checkBoxPassword.CheckedChanged += checkBoxPassword_CheckedChanged;
            clockTimer = new Timer();
            clockTimer.Interval = 1000; // 1000 ms = 1 second
            clockTimer.Tick += clockTimer_Tick; // Event handler for Tick event
            clockTimer.Start(); // Start the timer
        }
        private void MaskedUserNameText()
        {
            textBoxUserName.ForeColor = Color.Gray;
            // Use Singleton to manage placeholder behavior
            MaskingMethod.Instance.AddPlaceholder(textBoxUserName, "Username");
            textBoxUserName.KeyPress += MaskingMethod.Instance.ValidateNameInput;

            textBoxUserName.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxUserName, "Username");
            textBoxUserName.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxUserName, "Username");
        }

        public void MaskedUserPasswordText()
        {
            textBoxPassword.ForeColor = Color.Gray;
            textBoxPassword.UseSystemPasswordChar = false; // Initially not masked
            textBoxPassword.Text = "Password"; // Set placeholder text initially

            // Use Singleton to handle placeholder logic
            textBoxPassword.Enter += (sender, e) =>
            {
                if (textBoxPassword.Text == "Password")
                {
                    textBoxPassword.Text = ""; // Clear placeholder on focus
                    textBoxPassword.ForeColor = Color.Black;
                    textBoxPassword.UseSystemPasswordChar = true; // Mask when focused
                }
            };

            textBoxPassword.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
                {
                    textBoxPassword.UseSystemPasswordChar = false;
                    textBoxPassword.Text = "Password";
                    textBoxPassword.ForeColor = Color.Gray;
                }
            };
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != "Password")
            {
                textBoxPassword.UseSystemPasswordChar = !checkBoxPassword.Checked;
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
  
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Username FROM LoginForm WHERE Username = @username AND Password = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", textBoxUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", textBoxPassword.Text.Trim());

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string loggedInUser = result.ToString();
                            MessageBox.Show($"Login Successful! Welcome, {loggedInUser}!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CurrentUser.Username = loggedInUser;
                            this.Hide();
                            MainPage mainPage = new MainPage();
                            mainPage.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?", "Exit",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            else
            {
                Application.Exit();
            }
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            labelClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
