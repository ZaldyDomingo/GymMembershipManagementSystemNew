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
    public partial class ViewWalkedInMembers : Form
    {
        private string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        private SqlConnection sqlConnection;
        public ViewWalkedInMembers()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            SetupDataGridView();
            SetupTimer();
        }
        private void SetupDataGridView()
        {
            dataGridViewNewWalkin.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewNewWalkin.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewNewWalkin.RowTemplate.Height = 28;
            dataGridViewNewWalkin.ColumnHeadersHeight = 28;

            dataGridViewOldWalkedin.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewOldWalkedin.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewOldWalkedin.RowTemplate.Height = 28;
            dataGridViewOldWalkedin.ColumnHeadersHeight = 28;
            dataGridViewOldWalkedin.SelectionChanged += dataGridViewOldWalkedin_SelectionChanged;

        }
        private void InitializeDatabaseConnection()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        private void SetupTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 30000; 
            refreshTimer.Tick += (sender, e) => {
                LoadNewWalkInMember();
                LoadOldWalkInMembers();
                UpdateTotalWalkInMemberCount();
            };
            refreshTimer.Start(); 
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {

        }

        private void ViewWalkedInMembers_Load(object sender, EventArgs e)
        {
            LoadNewWalkInMember();  // Load the most recent walk-in member
            LoadOldWalkInMembers();
            UpdateTotalWalkInMemberCount();
        }
        public void LoadNewWalkInMember()
        {
            try
            {
                // Use the established connection to load data
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT TOP 1 [MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [RegistrationDate], [ExpirationDate], [MembershipFee]
                        FROM [gymMembership].[dbo].[WalkInMember]
                        ORDER BY [RegistrationDate] DESC";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind data to dataGridViewNewWalkin
                    dataGridViewNewWalkin.DataSource = dataTable;
                    HideSensitiveColumns(dataGridViewNewWalkin);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading new walk-in member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadOldWalkInMembers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Modify the query to retrieve all walk-in members
                    string query = @"
                SELECT [MemberID], [FirstName], [LastName], [Address], [PhoneNumber], [RegistrationDate], [ExpirationDate], [MembershipFee]
                FROM [gymMembership].[dbo].[WalkInMember]
                ORDER BY [RegistrationDate] DESC";

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind the data to dataGridViewOldWalkedin
                    dataGridViewOldWalkedin.DataSource = dataTable;

                    // Hide sensitive columns as needed
                    HideSensitiveColumns(dataGridViewOldWalkedin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading walk-in members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideSensitiveColumns(DataGridView dataGridView)
        {
            dataGridView.Columns["MemberID"].Visible = false;
            dataGridView.Columns["Address"].Visible = false;
            dataGridView.Columns["PhoneNumber"].Visible = false;
            dataGridView.Columns["ExpirationDate"].Visible = false;
            dataGridView.Columns["MembershipFee"].Visible = false;
        }
        public void UpdateTotalWalkInMemberCount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM [gymMembership].[dbo].[WalkInMember]";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    int totalCount = (int)command.ExecuteScalar(); // Execute the query and get the count

                    // Update the label with the total member count
                    labelTotalWalkedInMember.Text = $"{totalCount}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating total walk-in member count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            refreshTimer.Stop(); // Stop the timer when the form is closed
            base.OnFormClosed(e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (dataGridViewOldWalkedin.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a member to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewOldWalkedin.SelectedRows[0];
                string memberId = selectedRow.Cells["MemberID"].Value.ToString(); // Ensure "MemberID" column is present

                // Confirm deletion
                DialogResult confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this member?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Delete the member from the database
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string deleteQuery = "DELETE FROM [gymMembership].[dbo].[WalkInMember] WHERE [MemberID] = @MemberID";

                        SqlCommand command = new SqlCommand(deleteQuery, connection);
                        command.Parameters.AddWithValue("@MemberID", memberId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Refresh the DataGridView
                            LoadOldWalkInMembers();
                            UpdateTotalWalkInMemberCount();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewOldWalkedin_SelectionChanged(object sender, EventArgs e)
        {
            buttonDelete.Visible = dataGridViewOldWalkedin.SelectedRows.Count > 0;
        }
    }
}
