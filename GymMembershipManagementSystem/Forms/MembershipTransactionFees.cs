using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GymMembershipManagementSystem
{
    public partial class MembershipTransactionFees : Form
    {
        private SqlConnection sqlConnection;
        public MembershipTransactionFees()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeRefreshTimer();
            SetupDataGridView();
            LoadMemberData();
            LoadMembershipFeeChart();
        }
        private void SetupDataGridView()
        {
            dataGridStudentFeeTotal.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridStudentFeeTotal.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridStudentFeeTotal.RowTemplate.Height = 28;
            dataGridStudentFeeTotal.ColumnHeadersHeight = 28;

        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void LoadMemberData()
        {
            try
            {
                // SQL query to combine StudentMember, RegularMember, and WalkInMember with respective MembershipFee
                string query = @"
                    SELECT [FirstName], [LastName], 350 AS MembershipFee
                    FROM [dbo].[StudentMember]
                    UNION ALL
                    SELECT [FirstName], [LastName], 400 AS MembershipFee
                    FROM [dbo].[RegularMember]
                    UNION ALL
                    SELECT [FirstName], [LastName], 60 AS MembershipFee
                    FROM [dbo].[WalkInMember]";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Bind data to DataGridView
                dataGridStudentFeeTotal.DataSource = dataTable;

                // Calculate total membership fee
                decimal totalMembershipFee = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    totalMembershipFee += Convert.ToDecimal(row["MembershipFee"]);
                }

                // Display total fee in the label
                labelTotalMembershipFee.Text = $"Total Membership Fee: {totalMembershipFee:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading member data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            refreshTimer.Stop();
            base.OnFormClosed(e);
        }
        private void InitializeRefreshTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 10000; // 10 seconds
            refreshTimer.Tick += (sender, e) => LoadMemberData();  // Reload the data every time the timer ticks
            refreshTimer.Start();
        }
        private void LoadMembershipFeeChart()
        {
            // SQL queries to calculate sum of MembershipFee for each member type
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

            // Add data to the series
            studentSeries.Points.AddXY("Student Members", studentFeeTotal);
            regularSeries.Points.AddXY("Regular Members", regularFeeTotal);
            walkInSeries.Points.AddXY("Walk-In Members", walkInFeeTotal);

            // Clear existing series and add new ones
            chartMembershipFees.Series.Clear();
            chartMembershipFees.Series.Add(studentSeries);
            chartMembershipFees.Series.Add(regularSeries);
            chartMembershipFees.Series.Add(walkInSeries);

            // Configure chart axes
            chartMembershipFees.ChartAreas[0].AxisX.Title = "Member Type";
            chartMembershipFees.ChartAreas[0].AxisY.Title = "Total Membership Fee (Pesos)";

            // Set the maximum value of the Y-axis to 1 million
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
    }
}
