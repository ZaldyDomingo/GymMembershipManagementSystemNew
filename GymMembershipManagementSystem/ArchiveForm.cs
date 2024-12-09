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
            checkBoxStudent.Checked = true;
            checkBoxStudent.CheckedChanged += new EventHandler(checkBoxStudent_CheckedChanged);
            checkBoxRegular.CheckedChanged += new EventHandler(checkBoxRegular_CheckedChanged);
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
                    ReadOnly = false, // Allow interaction only with the checkbox
                    ThreeState = false // Avoid indeterminate state (can be omitted)
                };
                dataGridViewArchived.Columns.Insert(0, checkBoxColumn);
            }

      
            foreach (DataGridViewColumn column in dataGridViewArchived.Columns)
            {
                if (column.Name != "Select")
                {
                    column.ReadOnly = true;
                }
            }
            dataGridViewArchived.AllowUserToAddRows = false;
            dataGridViewArchived.ReadOnly = false;

            foreach (DataGridViewColumn column in dataGridViewArchived.Columns)
            {
                if (column.Name == "Select")
                    column.ReadOnly = false;
                else
                    column.ReadOnly = true; 
            }
        }
        private void LoadArchivedMembers()
        {
            try
            {
                string query = "";

                if (checkBoxStudent.Checked)
                {
                    // Query for Student Members
                    query = @"
                    SELECT [StudentId], [FirstName], [LastName], [DateOfBirth], [Age], [Gender], [Address], 
                           [MobileNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], 
                           [DateJoined], [ProfileImage], [MembershipStartDate], [MembershipFee], 
                           [MembershipEndDate], [ArchiveDate]
                    FROM [gymMembership].[dbo].[ArchivedStudentMember]";
                }
                else if (checkBoxRegular.Checked)
                {
                    // Query for Regular Members
                    query = @"
                    SELECT [RegularMemberId], [FirstName], [LastName], [DateOfBirth], [Age], [Gender], [Address], 
                           [MobileNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], 
                           [DateJoined], [ProfileImage], [MembershipStartDate], [MembershipFee], 
                           [MembershipEndDate], [ArchivedDate]
                    FROM [gymMembership].[dbo].[ArchivedMembers]";
                }

                if (!string.IsNullOrEmpty(query))
                {
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the query results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Bind the data to the DataGridView
                    dataGridViewArchived.DataSource = dataTable;
                }
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
        private void LabelHeaderDatagridViewSpacing() 
        {
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
        }
        private void buttonRestoreStudentMember_Click(object sender, EventArgs e)
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
                        int memberId = Convert.ToInt32(row.Cells["StudentId"].Value); // For Student members
                        selectedIds.Add(memberId);
                    }
                }

                if (selectedIds.Count == 0)
                {
                    MessageBox.Show("Please select at least one member to restore.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm restoration
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to restore the selected members?",
                    "Confirm Restoration",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();  // Open the connection once at the beginning of the method

                        foreach (int memberId in selectedIds)
                        {
                            // Query to get the student's data from the ArchivedStudentMember table
                            string selectQuery = "SELECT * FROM [gymMembership].[dbo].[ArchivedStudentMember] WHERE [StudentId] = @MemberId";
                            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                            {
                                selectCommand.Parameters.AddWithValue("@MemberId", memberId);

                                using (SqlDataReader reader = selectCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // Get the member's data
                                        string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                        string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                                        DateTime dateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                                        int age = reader.GetInt32(reader.GetOrdinal("Age"));
                                        string gender = reader.GetString(reader.GetOrdinal("Gender"));
                                        string address = reader.GetString(reader.GetOrdinal("Address"));
                                        string mobileNumber = reader.GetString(reader.GetOrdinal("MobileNumber"));
                                        string email = reader.GetString(reader.GetOrdinal("Email"));
                                        string emergencyContactName = reader.GetString(reader.GetOrdinal("EmergencyContactName"));
                                        string emergencyContactPhone = reader.GetString(reader.GetOrdinal("EmergencyContactPhone"));
                                        DateTime dateJoined = reader.GetDateTime(reader.GetOrdinal("DateJoined"));
                                        byte[] profileImage = reader.IsDBNull(reader.GetOrdinal("ProfileImage")) ? null : (byte[])reader["ProfileImage"];
                                        DateTime membershipStartDate = reader.GetDateTime(reader.GetOrdinal("MembershipStartDate"));
                                        decimal membershipFee = reader.GetDecimal(reader.GetOrdinal("MembershipFee"));
                                        DateTime membershipEndDate = reader.GetDateTime(reader.GetOrdinal("MembershipEndDate"));

                                        // Close the reader before performing insert and delete operations
                                        reader.Close();

                                        // Insert the data into the StudentMember table
                                        string insertQuery = @"
                                INSERT INTO [gymMembership].[dbo].[StudentMember] 
                                ([FirstName], [LastName], [DateOfBirth], [Age], [Gender], 
                                 [Address], [MobileNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], 
                                 [DateJoined], [ProfileImage], [MembershipStartDate], [MembershipFee], [MembershipEndDate])
                                VALUES
                                (@FirstName, @LastName, @DateOfBirth, @Age, @Gender, 
                                 @Address, @MobileNumber, @Email, @EmergencyContactName, @EmergencyContactPhone, 
                                 @DateJoined, @ProfileImage, @MembershipStartDate, @MembershipFee, @MembershipEndDate)";

                                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                        {
                                            insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                                            insertCommand.Parameters.AddWithValue("@LastName", lastName);
                                            insertCommand.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                                            insertCommand.Parameters.AddWithValue("@Age", age);
                                            insertCommand.Parameters.AddWithValue("@Gender", gender);
                                            insertCommand.Parameters.AddWithValue("@Address", address);
                                            insertCommand.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                                            insertCommand.Parameters.AddWithValue("@Email", email);
                                            insertCommand.Parameters.AddWithValue("@EmergencyContactName", emergencyContactName);
                                            insertCommand.Parameters.AddWithValue("@EmergencyContactPhone", emergencyContactPhone);
                                            insertCommand.Parameters.AddWithValue("@DateJoined", dateJoined);
                                            insertCommand.Parameters.AddWithValue("@ProfileImage", (object)profileImage ?? DBNull.Value);
                                            insertCommand.Parameters.AddWithValue("@MembershipStartDate", membershipStartDate);
                                            insertCommand.Parameters.AddWithValue("@MembershipFee", membershipFee);
                                            insertCommand.Parameters.AddWithValue("@MembershipEndDate", membershipEndDate);

                                            insertCommand.ExecuteNonQuery();
                                        }

                                        // Delete the member from the ArchivedStudentMember table
                                        string deleteQuery = "DELETE FROM [gymMembership].[dbo].[ArchivedStudentMember] WHERE [StudentId] = @MemberId";
                                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                        {
                                            deleteCommand.Parameters.AddWithValue("@MemberId", memberId);
                                            deleteCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Selected members have been restored to the Student Members list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload the archived members to reflect the changes
                    LoadArchivedMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while restoring members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRestoreRegularMember_Click(object sender, EventArgs e)
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
                        int memberId = Convert.ToInt32(row.Cells["RegularMemberId"].Value); // For Regular members
                        selectedIds.Add(memberId);
                    }
                }

                if (selectedIds.Count == 0)
                {
                    MessageBox.Show("Please select at least one member to restore.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm restoration
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to restore the selected members?",
                    "Confirm Restoration",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();  // Open the connection once at the beginning of the method

                        foreach (int memberId in selectedIds)
                        {
                            // Query to get the member's data from the ArchivedMembers table
                            string selectQuery = "SELECT * FROM [gymMembership].[dbo].[ArchivedMembers] WHERE [RegularMemberId] = @MemberId";
                            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                            {
                                selectCommand.Parameters.AddWithValue("@MemberId", memberId);

                                using (SqlDataReader reader = selectCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // Get the member's data
                                        string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                        string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                                        DateTime dateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth"));
                                        int age = reader.GetInt32(reader.GetOrdinal("Age"));
                                        string gender = reader.GetString(reader.GetOrdinal("Gender"));
                                        string address = reader.GetString(reader.GetOrdinal("Address"));
                                        string mobileNumber = reader.GetString(reader.GetOrdinal("MobileNumber"));
                                        string email = reader.GetString(reader.GetOrdinal("Email"));
                                        string emergencyContactName = reader.GetString(reader.GetOrdinal("EmergencyContactName"));
                                        string emergencyContactPhone = reader.GetString(reader.GetOrdinal("EmergencyContactPhone"));
                                        DateTime dateJoined = reader.GetDateTime(reader.GetOrdinal("DateJoined"));
                                        byte[] profileImage = reader.IsDBNull(reader.GetOrdinal("ProfileImage")) ? null : (byte[])reader["ProfileImage"];
                                        DateTime membershipStartDate = reader.GetDateTime(reader.GetOrdinal("MembershipStartDate"));
                                        decimal membershipFee = reader.GetDecimal(reader.GetOrdinal("MembershipFee"));
                                        DateTime membershipEndDate = reader.GetDateTime(reader.GetOrdinal("MembershipEndDate"));

                                        // Close the reader before performing insert and delete operations
                                        reader.Close();

                                        // Insert the data into the RegularMember table (without inserting RegularMemberId)
                                        string insertQuery = @"
                                    INSERT INTO [gymMembership].[dbo].[RegularMember] 
                                    ([FirstName], [LastName], [DateOfBirth], [Age], [Gender], 
                                     [Address], [MobileNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], 
                                     [DateJoined], [ProfileImage], [MembershipStartDate], [MembershipFee], [MembershipEndDate])
                                    VALUES
                                    (@FirstName, @LastName, @DateOfBirth, @Age, @Gender, 
                                     @Address, @MobileNumber, @Email, @EmergencyContactName, @EmergencyContactPhone, 
                                     @DateJoined, @ProfileImage, @MembershipStartDate, @MembershipFee, @MembershipEndDate)";

                                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                                        {
                                            insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                                            insertCommand.Parameters.AddWithValue("@LastName", lastName);
                                            insertCommand.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                                            insertCommand.Parameters.AddWithValue("@Age", age);
                                            insertCommand.Parameters.AddWithValue("@Gender", gender);
                                            insertCommand.Parameters.AddWithValue("@Address", address);
                                            insertCommand.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                                            insertCommand.Parameters.AddWithValue("@Email", email);
                                            insertCommand.Parameters.AddWithValue("@EmergencyContactName", emergencyContactName);
                                            insertCommand.Parameters.AddWithValue("@EmergencyContactPhone", emergencyContactPhone);
                                            insertCommand.Parameters.AddWithValue("@DateJoined", dateJoined);
                                            insertCommand.Parameters.AddWithValue("@ProfileImage", (object)profileImage ?? DBNull.Value);
                                            insertCommand.Parameters.AddWithValue("@MembershipStartDate", membershipStartDate);
                                            insertCommand.Parameters.AddWithValue("@MembershipFee", membershipFee);
                                            insertCommand.Parameters.AddWithValue("@MembershipEndDate", membershipEndDate);

                                            insertCommand.ExecuteNonQuery();
                                        }

                                        // Delete the member from the ArchivedMembers table
                                        string deleteQuery = "DELETE FROM [gymMembership].[dbo].[ArchivedMembers] WHERE [RegularMemberId] = @MemberId";
                                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                                        {
                                            deleteCommand.Parameters.AddWithValue("@MemberId", memberId);
                                            deleteCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Selected members have been restored to the Regular Members list.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload the archived members to reflect the changes
                    LoadArchivedMembers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while restoring members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStudent.Checked)
            {
                checkBoxRegular.Checked = false;
                buttonRestoreRegularMember.Hide(); 
                buttonRestoreStudentMember.Show();
                LoadArchivedMembers(); // Load regular members
                LabelHeaderDatagridViewSpacing();
            }

        }

        private void checkBoxRegular_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRegular.Checked)
            {
                checkBoxStudent.Checked = false;
                buttonRestoreStudentMember.Hide(); 
                buttonRestoreRegularMember.Show();
                LoadArchivedMembers(); // Load regular members
                LabelHeaderDatagridViewSpacing();
            }
        }
    }
}
