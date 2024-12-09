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
using System.Windows.Forms.DataVisualization.Charting;



namespace GymMembershipManagementSystem
{
    public partial class DashboardForm : Form
    {
        private SqlConnection sqlConnection;
        private BackgroundWorker searchWorker;
        
        public DashboardForm()
        {

            InitializeComponent();
            InitializeDatabaseConnection();
            LoadAllMembers();                   
            DisplayMemberCounts();
            LoadMemberJoinChart();
            LoadMembershipFeeChart();
            searchWorker = new BackgroundWorker();
            searchWorker.DoWork += searchWorker_DoWork;
            searchWorker.RunWorkerCompleted += searchWorker_RunWorkerCompleted;
            dataGridViewResult.Visible = false;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            countRefreshTimer = new Timer();
            countRefreshTimer.Interval = 5000;
            countRefreshTimer.Tick += countRefreshTimer_Tick;
            countRefreshTimer.Start();
            timerRecentMember = new Timer();
            timerRecentMember.Interval = 5000;
            timerRecentMember.Tick += timerRecentMember_Tick;
            timerRecentMember.Start();
            LoadRecentlyAddedMembers();
            dataGridViewRecentlyAdded.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewRecentlyAdded.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewRecentlyAdded.RowTemplate.Height = 28;
            dataGridViewRecentlyAdded.ColumnHeadersHeight = 28;
            dataGridViewRecentlyAdded.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            if (dataGridViewRecentlyAdded.Columns.Contains("FirstName"))
                dataGridViewRecentlyAdded.Columns["FirstName"].HeaderText = "First Name";
            if (dataGridViewRecentlyAdded.Columns.Contains("LastName"))
                dataGridViewRecentlyAdded.Columns["LastName"].HeaderText = "Last Name";
            dataGridViewRecentlyAdded.Columns["ProfileImage"].Visible = false;
        }
 
        private void searchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            e.Result = e.Argument.ToString();
        }
        private void searchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string searchTerm = e.Result.ToString();
            SearchMember(searchTerm);
        }

        public void DisplayMemberCounts()
        {
            labelStudentCount.Text = GetMemberCount("StudentMember").ToString();
            labelNotStudentMemberCount.Text = GetMemberCount("RegularMember").ToString();
            int totalMembers = GetMemberCount("StudentMember") + GetMemberCount("RegularMember");
            labelTotalMembers.Text = totalMembers.ToString();
        }
        private int GetMemberCount(string tableName)
        {
            int count = 0;
            string query = $"SELECT COUNT(*) FROM [{tableName}]";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }

                    count = (int)command.ExecuteScalar();
                }
                catch (SqlException ex) when (ex.Message.Contains("Invalid object name"))
                {
                    MessageBox.Show($"Error: The table '{tableName}' does not exist in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while counting members from {tableName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                }
            }
            return count;
        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public void LoadAllMembers()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT [FirstName], [LastName], [MobileNumber], [EmergencyContactPhone] FROM [dbo].[StudentMember] " +
                           "UNION ALL " +
                           "SELECT [FirstName], [LastName], [MobileNumber], [EmergencyContactPhone] FROM [dbo].[RegularMember]";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            dataGridViewResult.DataSource = dataTable;
            if (dataGridViewResult.Columns.Contains("ProfileImage"))
            {
                dataGridViewResult.Columns.Remove("ProfileImage");
            }
           
        }
        private void SearchMember(string searchTerm)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT [FirstName], [LastName], [MobileNumber], [EmergencyContactPhone] FROM [dbo].[StudentMember] " +
                           "WHERE [FirstName] LIKE @search OR " +
                           "[LastName] LIKE @search OR " +
                           "[MobileNumber] LIKE @search OR " +
                           "[EmergencyContactPhone] LIKE @search " +
                           "UNION ALL " +
                           "SELECT [FirstName], [LastName], [MobileNumber], [EmergencyContactPhone] FROM [dbo].[RegularMember] " +
                           "WHERE [FirstName] LIKE @search OR " +
                           "[LastName] LIKE @search OR " +
                           "[MobileNumber] LIKE @search OR " +
                           "[EmergencyContactPhone] LIKE @search";
            try
            {
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    sqlConnection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }

                dataGridViewResult.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            if (!searchWorker.IsBusy)
            {
                searchWorker.RunWorkerAsync(textBoxSearchMember.Text);
            }
        }
        private void dataGridViewResult_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewResult.Rows[e.RowIndex];

                // Extract first name and last name from the selected row
                string firstName = row.Cells["FirstName"].Value.ToString();
                string lastName = row.Cells["LastName"].Value.ToString();

                // Pass the first name and last name to the MemberDetailsForm constructor
                MemberDetailsForm detailsForm = new MemberDetailsForm(firstName, lastName);

                // Show the MemberDetailsForm as a dialog
                detailsForm.ShowDialog();
            }

        }
        private void countRefreshTimer_Tick(object sender, EventArgs e)
        {
            DisplayMemberCounts();
        }
        private void buttonViewMember_Click(object sender, EventArgs e)
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
        private void buttonViewRegularMember_Click(object sender, EventArgs e)
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
        public void LoadRecentlyAddedMembers()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT [FirstName], [LastName], [ProfileImage] FROM [dbo].[StudentMember] " +
                           "UNION ALL " +
                           "SELECT [FirstName], [LastName], [ProfileImage] FROM [dbo].[RegularMember]";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            dataGridViewRecentlyAdded.DataSource = dataTable;
        }
        private void timerRecentMember_Tick(object sender, EventArgs e)
        {
            LoadRecentlyAddedMembers();
        }
        private void textBoxSearchMember_TextChanged_1(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
            if (!string.IsNullOrWhiteSpace(textBoxSearchMember.Text))
            {
                dataGridViewResult.Visible = true;
              
            }
            else 
            {
                dataGridViewResult.Visible = false;
            }
        }
        private void textBoxSearchMember_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxSearchMember.Text))
            {
                dataGridViewResult.Visible = true;
            }
        }
        private CheckInListForm checkInListForm = null;
        private void monthCalendarMemberCheckedIn_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start;

            if (checkInListForm == null || checkInListForm.IsDisposed)
            {
                checkInListForm = new CheckInListForm(selectedDate);
                checkInListForm.FormClosed += (s, args) => checkInListForm = null; 
                checkInListForm.Show();
            }
            else
            {
                checkInListForm.UpdateDate(selectedDate);
                checkInListForm.Activate();
            }
        }

        public void LoadMemberJoinChart()
        {
            // SQL queries for Regular and Student Members
            string regularMemberQuery = @"
                SELECT FORMAT(DateJoined, 'yyyy-MM') AS JoinMonth, COUNT(*) AS MemberCount
                FROM gymMembership.dbo.RegularMember
                GROUP BY FORMAT(DateJoined, 'yyyy-MM')
                ORDER BY JoinMonth;";

            string studentMemberQuery = @"
                SELECT FORMAT(DateJoined, 'yyyy-MM') AS JoinMonth, COUNT(*) AS MemberCount
                FROM gymMembership.dbo.StudentMember
                GROUP BY FORMAT(DateJoined, 'yyyy-MM')
                ORDER BY JoinMonth;";

            // Fetch data for Regular and Student Members
            Dictionary<string, int> regularData = FetchData(regularMemberQuery);
            Dictionary<string, int> studentData = FetchData(studentMemberQuery);

            // Merge keys (months) from both data sources
            var allMonths = Enumerable.Range(1, 12).Select(i => new DateTime(2024, i, 1).ToString("yyyy-MM")).ToArray();

            // Prepare chart series
            Series regularSeries = new Series("Regular Members")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue
            };

            Series studentSeries = new Series("Student Members")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Green
            };

            // Add data to the series
            foreach (var month in allMonths)
            {
                regularSeries.Points.AddXY(month, regularData.ContainsKey(month) ? regularData[month] : 0);
                studentSeries.Points.AddXY(month, studentData.ContainsKey(month) ? studentData[month] : 0);
            }

            // Clear existing series and add the new ones
            chartDetails.Series.Clear();
            chartDetails.Series.Add(regularSeries);
            chartDetails.Series.Add(studentSeries);

            chartDetails.ChartAreas[0].AxisX.Title = "Month";
            chartDetails.ChartAreas[0].AxisY.Title = "Number of Members";

            chartDetails.ChartAreas[0].AxisY.Maximum = 1000;

            chartDetails.Legends.Clear();
            chartDetails.Legends.Add(new Legend() { Docking = Docking.Top, Alignment = StringAlignment.Center });
        }

        private Dictionary<string, int> FetchData(string query)
        {
            var data = new Dictionary<string, int>();
            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string month = reader["JoinMonth"].ToString();
                        int count = Convert.ToInt32(reader["MemberCount"]);
                        data[month] = count;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching data: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return data;
        }
        public void LoadMembershipFeeChart()
        {
            string studentMemberQuery = "SELECT SUM(MembershipFee) AS TotalMembershipFee FROM [gymMembership].[dbo].[StudentMember]";
            string regularMemberQuery = "SELECT SUM(MembershipFee) AS TotalMembershipFee FROM [gymMembership].[dbo].[RegularMember]";
            string walkInMemberQuery = "SELECT SUM(MembershipFee) AS TotalMembershipFee FROM [gymMembership].[dbo].[WalkInMember]";

            // Fetch the data
            decimal studentFeeTotal = FetchMembershipFee(studentMemberQuery);
            decimal regularFeeTotal = FetchMembershipFee(regularMemberQuery);
            decimal walkInFeeTotal = FetchMembershipFee(walkInMemberQuery);

            // Prepare chart series
            Series studentSeries = new Series("Student Members")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.Silver
            };

            Series regularSeries = new Series("Regular Members")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.Khaki
            };

            Series walkInSeries = new Series("Walk-In Members")
            {
                ChartType = SeriesChartType.Bar,
                Color = Color.Orange

            };

            studentSeries.Points.AddXY("Student Members", studentFeeTotal);
            regularSeries.Points.AddXY("Regular Members", regularFeeTotal);
            walkInSeries.Points.AddXY("Walk-In Members", walkInFeeTotal);

            chartMembershipFees.Series.Clear();
            chartMembershipFees.Series.Add(studentSeries);
            chartMembershipFees.Series.Add(regularSeries);
            chartMembershipFees.Series.Add(walkInSeries);

            // Configure chart axes
            chartMembershipFees.ChartAreas[0].AxisX.Title = "Member Type";
            chartMembershipFees.ChartAreas[0].AxisY.Title = "Total Membership Fee (Pesos)";

            // Set the maximum value of the Y-axis to 500000
            chartMembershipFees.ChartAreas[0].AxisY.Maximum = 500000;

            // Add a legend
            chartMembershipFees.Legends.Clear();
            chartMembershipFees.Legends.Add(new Legend() { Docking = Docking.Top, Alignment = StringAlignment.Center });
        }

        private decimal FetchMembershipFee(string query)
        {
            decimal totalFee = 0;

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                try
                {
                    sqlConnection.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalFee = Convert.ToDecimal(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching membership fee: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return totalFee;
        }

        private void button4Months_Click(object sender, EventArgs e)
        {
            chartMembershipFees.ChartAreas[0].AxisY.Maximum = 90000;
        }

        private void button7Months_Click(object sender, EventArgs e)
        {
            chartMembershipFees.ChartAreas[0].AxisY.Maximum = 150000;
        }

        private void button1year_Click(object sender, EventArgs e)
        {
            chartMembershipFees.ChartAreas[0].AxisY.Maximum = 500000;
        }

        private void buttonMember1Year_Click(object sender, EventArgs e)
        {
            chartDetails.ChartAreas[0].AxisY.Maximum = 1000;
        }

        private void buttonMember7Months_Click(object sender, EventArgs e)
        {
            chartDetails.ChartAreas[0].AxisY.Maximum = 400;
        }

        private void buttonMember4Months_Click(object sender, EventArgs e)
        {
            chartDetails.ChartAreas[0].AxisY.Maximum = 200;
        }
    }
}


