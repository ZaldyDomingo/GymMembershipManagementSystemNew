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
    public partial class ArchiveForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public ArchiveForm()
        {
            InitializeComponent();
            LoadArchivedMembers();
            SetupDataGridView();
            dataGridViewArchived.Columns["Age"].Visible = false;
            dataGridViewArchived.Columns["DateOfBirth"].Visible = false;
            dataGridViewArchived.Columns["ProfileImage"].Visible = false;
            dataGridViewArchived.Columns["Address"].Visible = false;
            dataGridViewArchived.Columns["Gender"].Visible = false;
            dataGridViewArchived.Columns["DateJoined"].Visible = false;
            dataGridViewArchived.Columns["EmergencyContactName"].Visible = false;
            dataGridViewArchived.Columns["MembershipFee"].Visible = false;
            dataGridViewArchived.Columns["Email"].Visible = false;
            dataGridViewArchived.Columns["MembershipEndDate"].Visible = false;
        }
        private void SetupDataGridView()
        {
            dataGridViewArchived.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewArchived.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewArchived.RowTemplate.Height = 28;
            dataGridViewArchived.ColumnHeadersHeight = 28;
            dataGridViewArchived.EditMode = DataGridViewEditMode.EditOnEnter;

            if (!dataGridViewArchived.Columns.Contains("Select"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "Select",
                    HeaderText = "Select",
                    Width = 50,
                    ReadOnly = false, // Allow interaction
                    ThreeState = false // Avoid indeterminate state (can be omitted)
                };
                dataGridViewArchived.Columns.Insert(0, checkBoxColumn);
            }

            if (dataGridViewArchived.Columns.Contains("FirstName"))
                dataGridViewArchived.Columns["FirstName"].HeaderText = "First Name";

            if (dataGridViewArchived.Columns.Contains("LastName"))
                dataGridViewArchived.Columns["LastName"].HeaderText = "Last Name";

            if (dataGridViewArchived.Columns.Contains("MobileNumber"))
                dataGridViewArchived.Columns["MobileNumber"].HeaderText = "Phone Number";

            if (dataGridViewArchived.Columns.Contains("RemainingDays"))
                dataGridViewArchived.Columns["RemainingDays"].HeaderText = "Days Left";

            if (dataGridViewArchived.Columns.Contains("EmergencyContactPhone"))
                dataGridViewArchived.Columns["EmergencyContactPhone"].HeaderText = "Emergency No";

            if (dataGridViewArchived.Columns.Contains("MembershipStartDate"))
                dataGridViewArchived.Columns["MembershipStartDate"].HeaderText = "Date Started";

            if (dataGridViewArchived.Columns.Contains("RegularMemberId"))
                dataGridViewArchived.Columns["RegularMemberId"].HeaderText = "Member Id";

            if (dataGridViewArchived.Columns.Contains("StudentId"))
                dataGridViewArchived.Columns["StudentId"].HeaderText = "Member Id";

            dataGridViewArchived.AllowUserToAddRows = false; 
            dataGridViewArchived.ReadOnly = false; 
        }
     
        public void LoadArchivedMembers()
        {
            try
            {
                // SQL query to UNION data from both tables
                string query = @"
            SELECT [StudentId], [FirstName], [LastName], [DateOfBirth], [Age], [Gender], [Address], 
                   [MobileNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], 
                   [DateJoined], [ProfileImage], [MembershipStartDate], [MembershipFee], 
                   [MembershipEndDate], [ArchiveDate]
            FROM [gymMembership].[dbo].[ArchivedStudentMember]
            
            UNION
            
            SELECT [RegularMemberId], [FirstName], [LastName], [DateOfBirth], [Age], [Gender], [Address], 
                   [MobileNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], 
                   [DateJoined], [ProfileImage], [MembershipStartDate], [MembershipFee], 
                   [MembershipEndDate], [ArchivedDate]
            FROM [gymMembership].[dbo].[ArchivedMembers]";

                DataTable dataTable = new DataTable();

                // Fill the DataTable with the UNION query results
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                {
                    adapter.Fill(dataTable);
                }

                // Bind the data to the DataGridView
                dataGridViewArchived.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading archived members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRenew_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeletePermanent_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> selectedIds = new List<int>();

                // Iterate through the rows and check the checkboxes to gather selected IDs
                foreach (DataGridViewRow row in dataGridViewArchived.Rows)
                {
                    // Check if the checkbox in the "Select" column is checked
                    if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                    {
                        int memberId;
                        if (row.Cells["StudentId"].Value != DBNull.Value)
                        {
                            memberId = Convert.ToInt32(row.Cells["StudentId"].Value); // For Student members
                        }
                        else
                        {
                            memberId = Convert.ToInt32(row.Cells["RegularMemberId"].Value); // For Regular members
                        }
                        selectedIds.Add(memberId);
                    }
                }

                if (selectedIds.Count == 0)
                {
                    MessageBox.Show("Please select at least one member to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to permanently delete the selected members?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        foreach (int memberId in selectedIds)
                        {
                            // SQL query to delete from ArchivedStudentMember table
                            string deleteStudentQuery = "DELETE FROM [gymMembership].[dbo].[ArchivedStudentMember] WHERE [StudentId] = @MemberId";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteStudentQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@MemberId", memberId);
                                deleteCommand.ExecuteNonQuery();
                            }

                            // SQL query to delete from ArchivedMembers table (in case of regular members)
                            string deleteRegularQuery = "DELETE FROM [gymMembership].[dbo].[ArchivedMembers] WHERE [RegularMemberId] = @MemberId";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteRegularQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@MemberId", memberId);
                                deleteCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Selected members have been permanently deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload the archived members to reflect the changes
                    LoadArchivedMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
