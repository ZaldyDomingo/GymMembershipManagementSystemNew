using GymMembershipManagementSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GymMembershipManagementSystem
{
    public partial class MainPage : Form
    {
        private NewMemberForm newMemberForm;
        private NewMemberNotStudent newMemberNotStudent;
        private CalendarUserInteract calendar;
        private WalkInMember walkInMember;
 
        public MainPage()
        {
            InitializeComponent();
            clockTimer = new Timer();
            clockTimer.Interval = 1000; // 1000 ms = 1 second
            clockTimer.Tick += clockTimer_Tick; // Event handler for Tick event
            clockTimer.Start(); // Start the timer
            UpdateDate();
            
        }
        private void clockTimer_Tick(object sender, EventArgs e)
        {
            labelClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            UpdateDate();
        }
        private void UpdateDate()
        {
            labelDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }
        private void MainPage_Load(object sender, EventArgs e)
        {
            var headerLabel = new ToolStripLabel()
            {
                Font = new Font("Century Gothic", 9, FontStyle.Bold),
                ForeColor = Color.Black,
                Alignment = ToolStripItemAlignment.Left,
                TextAlign = ContentAlignment.MiddleLeft
            };
            headerLabel.Margin = new Padding(10, 5, 0, 5);
            menuStripNavigation.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            menuStripNavigation.Items.Insert(0, headerLabel);

            if (panelContainer.Controls.OfType<DashboardForm>().Any()) return;
            panelContainer.Controls.Clear();

            DashboardForm dashboardForm = new DashboardForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(dashboardForm);
            dashboardForm.Show();
        }
        private void ShowForm(Form form, string headerText)
        {
            labelHeaderMenu.Text = headerText;
            var existingForm = panelContainer.Controls.OfType<Form>().FirstOrDefault(f => f.GetType() == form.GetType());
            if (existingForm != null) return;

            panelContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            try
            {
                panelContainer.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateHeaderAndShowForm(string headerText, Form form)
        {
            labelHeaderMenu.Text = headerText;
            ShowForm(form, headerText);
        }
        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateHeaderAndShowForm("C.H.C Dashboard", new DashboardForm());
        }
        private void monthlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newMemberForm == null || newMemberForm.IsDisposed)
            {
                newMemberForm = new NewMemberForm();
                newMemberForm.Show();
            }
            else
            {
                newMemberForm.BringToFront();
            }
        }
        private void monthlyStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (newMemberNotStudent == null || newMemberNotStudent.IsDisposed)
            {
                newMemberNotStudent = new NewMemberNotStudent();
                newMemberNotStudent.Show();
            }
            else
            {
                newMemberNotStudent.BringToFront();
            }
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to log out? Confirm?", "Log Out", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelHeaderMenu.Text = "C.H.C Dashboard";
            if (panelContainer.Controls.OfType<DashboardForm>().Any()) return;
            panelContainer.Controls.Clear();

            DashboardForm dashboardForm = new DashboardForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(dashboardForm);
            dashboardForm.Show();
        }
        private void viewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelContainer.Controls.OfType<ViewStudentMember>().Any()) return;
            panelContainer.Controls.Clear();

            ViewStudentMember viewStudentMember = new ViewStudentMember
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(viewStudentMember);
            viewStudentMember.Show();
        }
        private void regularMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelContainer.Controls.OfType<ViewRegularMember>().Any()) return;
            panelContainer.Controls.Clear();

            ViewRegularMember viewRegularMember = new ViewRegularMember
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(viewRegularMember);
            viewRegularMember.Show();
        }
        private void notificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelContainer.Controls.OfType<NotificationTimeRemainingForm>().Any()) return;
            panelContainer.Controls.Clear();

            NotificationTimeRemainingForm notificationTimeRemainingForm = new NotificationTimeRemainingForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(notificationTimeRemainingForm);
            notificationTimeRemainingForm.Show();
        }
        private void walkInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (walkInMember == null || walkInMember.IsDisposed)
            {
                walkInMember = new WalkInMember();
                walkInMember.Show();
            }
            else
            {
                walkInMember.BringToFront();
            }
        }
        private void calendarMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (calendar == null || calendar.IsDisposed)
            {
                calendar = new CalendarUserInteract();
                calendar.Show();
            }
            else
            {
                calendar.BringToFront();
            }
        }
        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?", "Exit",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            else
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void totalTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelContainer.Controls.OfType<MembershipTransactionFees>().Any()) return;
            panelContainer.Controls.Clear();

            MembershipTransactionFees membershipTransactionFees = new MembershipTransactionFees
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(membershipTransactionFees);
            membershipTransactionFees.Show();
        }

        private void walkedinMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelContainer.Controls.OfType<ViewWalkedInMembers>().Any()) return;
            panelContainer.Controls.Clear();
            ViewWalkedInMembers viewWalkedIn = new ViewWalkedInMembers
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(viewWalkedIn);
            viewWalkedIn.Show();
        }

        private void minMaxSizeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is currently maximized
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(800, 600);  
            }
            else
            {
                // Maximize the form
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is ViewStudentMember viewStudentForm)
                {
                    viewStudentForm.LoadStudents(); // Refresh the students
                }
                else if (form is ViewRegularMember viewRegularForm)
                {
                    viewRegularForm.LoadRegularMembers(); 
                }
                else if (form is ViewWalkedInMembers viewWalkinForm)
                {
                    viewWalkinForm.LoadNewWalkInMember();
                    viewWalkinForm.LoadOldWalkInMembers();
                    viewWalkinForm.UpdateTotalWalkInMemberCount();
                }
                else if(form is UpdateMemberForm update)
                {
                    update.LoadMemberData();
                }
                else if(form is DashboardForm dashboard)
                {
                    dashboard.LoadMemberJoinChart();
                    dashboard.LoadMembershipFeeChart();
                    dashboard.LoadRecentlyAddedMembers();
                    dashboard.LoadAllMembers();
                }
            }
        }

        private void updateMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelContainer.Controls.OfType<UpdateMemberForm>().Any()) return;
            panelContainer.Controls.Clear();

            UpdateMemberForm updateMemberForm = new UpdateMemberForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(updateMemberForm);
            updateMemberForm.Show();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Currently logged in as: {CurrentUser.Username}","Info",MessageBoxButtons.OK);
        }

        private void archiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panelContainer.Controls.OfType<ArchiveForm>().Any()) return;
            panelContainer.Controls.Clear();

            ArchiveForm archiveForm = new ArchiveForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelContainer.Controls.Add(archiveForm);
            archiveForm.Show();
        }
    }
}
