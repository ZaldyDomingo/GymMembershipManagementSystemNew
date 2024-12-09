using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMembershipManagementSystem
{
    public partial class CalendarUserInteract : Form
    {
        int month, year;
        public CalendarUserInteract()
        {
            InitializeComponent();

        }
        private void CalendarUserInteract_Load(object sender, EventArgs e)
        {
            DisplayDays();
        }
        private void DisplayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            UpdateCalendarDisplay();
        }

        private void UpdateCalendarDisplay()
        {
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayofweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            daycontainer.Controls.Clear();

            // Add empty controls for the days before the first day of the month
            for (int i = 1; i < dayofweek; i++)
            {
                UserControl1Blank userControl = new UserControl1Blank();
                daycontainer.Controls.Add(userControl);
            }

            // Add the actual day buttons for the current month
            for (int i = 1; i <= days; i++)
            {
                UserControlDays userControlDays = new UserControlDays();
                userControlDays.days(i);

                // Highlight the current day only if the displayed month/year matches the current month/year
                DateTime now = DateTime.Now;
                if (month == now.Month && year == now.Year && i == now.Day)
                {
                    userControlDays.BackColor = Color.Silver;  // Highlight with silver background
                    userControlDays.ForeColor = Color.Black;   // Change text color to black
                }

                daycontainer.Controls.Add(userControlDays);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            try
            {
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
                UpdateCalendarDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                month--;
                if (month < 1)
                {
                    month = 12;
                    year--;
                }
                UpdateCalendarDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
