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
    public partial class CheckInListForm : Form
    {
        private DateTime selectedDate;
        private SqlConnection sqlConnection;
        public CheckInListForm(DateTime selectedDate)
        {
            InitializeComponent();
            this.selectedDate = selectedDate;
            InitializeDatabaseConnection();
            LoadCheckIns();
            SetupDataGridView();
        }
        private void SetupDataGridView()
        {
            dataGridViewCheckIns.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewCheckIns.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewCheckIns.RowTemplate.Height = 28;
            dataGridViewCheckIns.ColumnHeadersHeight = 28;

        }
        public void UpdateDate(DateTime newDate)
        {
            this.selectedDate = newDate; 
            LoadCheckIns(); 
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void LoadCheckIns()
        {
            try
            {
                sqlConnection.Open();

                // SQL Query to fetch both regular and student members' check-ins for the selected date
                string query = @"
                    SELECT 
                        'Regular Member: ' + rm.FirstName + ' ' + rm.LastName AS MemberName, 
                        rmc.CheckInDate
                    FROM RegularMemberCheckIn rmc
                    INNER JOIN RegularMember rm ON rmc.RegularMemberId = rm.RegularMemberId
                    WHERE CAST(rmc.CheckInDate AS DATE) = @SelectedDate

                    UNION ALL

                    SELECT 
                        'Student Member: ' + sm.FirstName + ' ' + sm.LastName AS MemberName, 
                        smc.CheckInDate
                    FROM StudentMemberCheckIn smc
                    INNER JOIN StudentMember sm ON smc.StudentId = sm.StudentId
                    WHERE CAST(smc.CheckInDate AS DATE) = @SelectedDate

                    ORDER BY CheckInDate DESC";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@SelectedDate", selectedDate.Date); // Set the selected date parameter

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable checkInDataTable = new DataTable();
                adapter.Fill(checkInDataTable);

                // Display the check-in data in a DataGridView
                dataGridViewCheckIns.DataSource = checkInDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading check-ins: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
