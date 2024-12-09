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
    public partial class ViewRegularMember : Form
    {
        private SqlConnection sqlConnection;


        public ViewRegularMember()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeSearchTimer();
            LoadRegularMembers();
            FilterData();
            InitializeLoadMemberTimer();
            SetupDataGridView();
            buttonCheck.Visible = false;
            buttonCancel.Visible = false;
            buttonMultiDelete.Visible = true;

            buttonMultiDelete.Click += buttonMultiDelete_Click;
            buttonCheck.Click += buttonCheck_Click;
            buttonCancel.Click += buttonCancel_Click;
            dataGridViewRegular.CellContentClick += dataGridViewRegular_CellContentClick;
        }
        private void SetupDataGridView()
        {
            dataGridViewRegular.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewRegular.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewRegular.RowTemplate.Height = 28;
            dataGridViewRegular.ColumnHeadersHeight = 28;
            dataGridViewRegular.EditMode = DataGridViewEditMode.EditOnEnter;

            // Add TextChanged event for the search functionality
            textBoxSearchMember.TextChanged += (sender, e) =>
            {
                searchTimer.Stop();
                searchTimer.Start();  // This ensures a delay before applying the filter
            };
            if (dataGridViewRegular.Columns.Contains("FirstName"))
                dataGridViewRegular.Columns["FirstName"].HeaderText = "First Name";

            if (dataGridViewRegular.Columns.Contains("LastName"))
                dataGridViewRegular.Columns["LastName"].HeaderText = "Last Name";

            if (dataGridViewRegular.Columns.Contains("MobileNumber"))
                dataGridViewRegular.Columns["MobileNumber"].HeaderText = "Phone Number";

            if (dataGridViewRegular.Columns.Contains("RemainingDays"))
                dataGridViewRegular.Columns["RemainingDays"].HeaderText = "Days Left";

            if (dataGridViewRegular.Columns.Contains("EmergencyContactPhone"))
                dataGridViewRegular.Columns["EmergencyContactPhone"].HeaderText = "Emergency No";

            if (dataGridViewRegular.Columns.Contains("MembershipStartDate"))
                dataGridViewRegular.Columns["MembershipStartDate"].HeaderText = "Date Started";

            if (dataGridViewRegular.Columns.Contains("RegularMemberId"))
                dataGridViewRegular.Columns["RegularMemberId"].HeaderText = "Member Id";
        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public void LoadRegularMembers()
        {
            try
            {
                // SQL query for RegularMember table
                string query = "SELECT [RegularMemberId], [FirstName], [LastName], [DateOfBirth], [Age], [Gender], [Address], [MobileNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], [DateJoined], [ProfileImage], [MembershipStartDate], [MembershipFee], [MembershipEndDate] FROM [dbo].[RegularMember]";
                DataTable dataTable = new DataTable();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                // Add column for Remaining Days
                dataTable.Columns.Add("RemainingDays", typeof(int));

                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime membershipStartDate = Convert.ToDateTime(row["MembershipStartDate"]);
                    DateTime expirationDate = membershipStartDate.AddDays(31); // Assuming 31 days membership
                    int remainingDays = (expirationDate - DateTime.Now).Days;

                    if (remainingDays <= 0)
                    {
                        row.Delete(); // Remove expired members
                    }
                    else
                    {
                        row["RemainingDays"] = remainingDays;
                    }
                }

                dataTable.AcceptChanges();
                dataGridViewRegular.DataSource = dataTable;


                dataGridViewRegular.Columns["Age"].Visible = false;
                dataGridViewRegular.Columns["DateOfBirth"].Visible = false;
                dataGridViewRegular.Columns["ProfileImage"].Visible = false;
                dataGridViewRegular.Columns["Address"].Visible = false;
                dataGridViewRegular.Columns["Gender"].Visible = false;
                dataGridViewRegular.Columns["DateJoined"].Visible = false;
                dataGridViewRegular.Columns["EmergencyContactName"].Visible = false;
                dataGridViewRegular.Columns["MembershipFee"].Visible = false;
                dataGridViewRegular.Columns["Email"].Visible = false;
                dataGridViewRegular.Columns["MembershipEndDate"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading regular member data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeSearchTimer()
        {
            searchTimer = new Timer();
            searchTimer.Interval = 500; // 500ms delay
            searchTimer.Tick += searchTimer_Tick;
        }

        private void FilterData()
        {
            string searchTerm = textBoxSearchMember.Text.ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadRegularMembers();
                return;
            }

            try
            {
                DataTable dataTable = ((DataTable)dataGridViewRegular.DataSource).Copy();

                var filteredRows = dataTable.AsEnumerable()
                    .Where(row => row["FirstName"].ToString().ToLower().Contains(searchTerm) ||
                                  row["LastName"].ToString().ToLower().Contains(searchTerm) ||
                                  row["MobileNumber"].ToString().ToLower().Contains(searchTerm)).ToList();

                DataTable filteredDataTable = dataTable.Clone();

                // Add matching rows to the filtered DataTable first
                foreach (var row in filteredRows)
                {
                    filteredDataTable.ImportRow(row);
                }

                // Add remaining rows to the filtered DataTable after
                var remainingRows = dataTable.AsEnumerable()
                    .Where(row => !filteredRows.Contains(row)).ToList();

                foreach (var row in remainingRows)
                {
                    filteredDataTable.ImportRow(row);
                }

                // Bind the filtered DataTable back to the DataGridView
                dataGridViewRegular.DataSource = filteredDataTable;

                // Optionally hide unwanted columns
                dataGridViewRegular.Columns["ProfileImage"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();            
            FilterData();
        }

        private void dataGridViewRegular_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridViewRegular.Rows[e.RowIndex];

                    // Get member details (only first name and last name are needed now)
                    string firstName = selectedRow.Cells["FirstName"].Value.ToString();
                    string lastName = selectedRow.Cells["LastName"].Value.ToString();

                    // Open the MemberDetailsForm with only the first name and last name
                    MemberDetailsForm memberDetailsForm = new MemberDetailsForm(firstName, lastName);
                    memberDetailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening member details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private CheckBox headerCheckBox; // Declare a CheckBox for the header
        private bool isHeaderCheckBoxHandled = false;

        private void AddHeaderCheckBox()
        {
            if (headerCheckBox == null)
            {
                headerCheckBox = new CheckBox
                {
                    Size = new Size(15, 15), // Size of the checkbox
                    BackColor = Color.Transparent
                };

                // Add CheckedChanged event for the header checkbox
                headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

                // Ensure header checkbox is added dynamically when column headers are painted
                dataGridViewRegular.CellPainting += DataGridViewRegular_CellPainting;
            }
        }

        private void DataGridViewRegular_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (!isHeaderCheckBoxHandled && e.RowIndex == -1 && e.ColumnIndex == 0) // Check header row
            {
                // Position the checkbox inside the header cell
                var cellRectangle = dataGridViewRegular.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                headerCheckBox.Location = new Point(cellRectangle.X + (cellRectangle.Width - headerCheckBox.Width) / 2, cellRectangle.Y + (cellRectangle.Height - headerCheckBox.Height) / 2);

                // Add the checkbox to the DataGridView controls
                dataGridViewRegular.Controls.Add(headerCheckBox);

                isHeaderCheckBoxHandled = true;
            }
        }
        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = headerCheckBox.Checked;

            foreach (DataGridViewRow row in dataGridViewRegular.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Select"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null)
                {
                    checkBoxCell.Value = isChecked; // Check or uncheck all checkboxes
                }
            }
        }
        private void ToggleMultiDeleteMode(bool isMultiDeleteMode)
        {
            buttonMultiDelete.Visible = !isMultiDeleteMode;
            buttonCheck.Visible = isMultiDeleteMode;
            buttonCancel.Visible = isMultiDeleteMode;

            if (isMultiDeleteMode)
            {
                // Add "Select" checkbox column if not already present
                if (!dataGridViewRegular.Columns.Contains("Select"))
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                    {
                        Name = "Select",
                        HeaderText = "", // Leave header text blank; we add a checkbox instead
                        Width = 30,
                        ReadOnly = false
                    };
                    dataGridViewRegular.Columns.Insert(0, checkBoxColumn);
                }

                // Add the header checkbox dynamically
                AddHeaderCheckBox();

                // Allow only the checkbox column to be editable
                dataGridViewRegular.ReadOnly = false;
                foreach (DataGridViewColumn column in dataGridViewRegular.Columns)
                {
                    if (column.Name != "Select")
                    {
                        column.ReadOnly = true;
                    }
                }
            }
            else
            {
                // Remove "Select" column if present
                if (dataGridViewRegular.Columns.Contains("Select"))
                {
                    dataGridViewRegular.Columns.Remove("Select");
                }

                // Hide the header checkbox
                if (headerCheckBox != null)
                {
                    headerCheckBox.Visible = false;
                    headerCheckBox.Checked = false;
                    isHeaderCheckBoxHandled = false;
                }

                dataGridViewRegular.ReadOnly = true; // Revert to read-only mode
            }
        }
        private void ArchiveSelectedMembers(List<int> memberIds)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
                {
                    connection.Open();

                    foreach (int id in memberIds)
                    {
                        string insertArchivedQuery = @"
                        INSERT INTO ArchivedMembers
                        (RegularMemberId, FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, 
                        EmergencyContactName, EmergencyContactPhone, DateJoined, ProfileImage, MembershipStartDate, 
                        MembershipFee, MembershipEndDate)
                        SELECT RegularMemberId, FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, 
                           EmergencyContactName, EmergencyContactPhone, DateJoined, ProfileImage, MembershipStartDate, 
                           MembershipFee, MembershipEndDate
                        FROM RegularMember
                        WHERE RegularMemberId = @RegularMemberId";

                        using (SqlCommand insertCommand = new SqlCommand(insertArchivedQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@RegularMemberId", id);
                            insertCommand.ExecuteNonQuery();
                        }

                        string deleteMemberQuery = "DELETE FROM RegularMember WHERE RegularMemberId = @RegularMemberId";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteMemberQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@RegularMemberId", id);
                            deleteCommand.ExecuteNonQuery();
                        }

                        string deleteCheckInQuery = "DELETE FROM RegularMemberCheckIn WHERE RegularMemberId = @RegularMemberId";
                        using (SqlCommand deleteCheckInCommand = new SqlCommand(deleteCheckInQuery, connection))
                        {
                            deleteCheckInCommand.Parameters.AddWithValue("@RegularMemberId", id);
                            deleteCheckInCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while archiving members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> selectedIds = new List<int>();
                if (dataGridViewRegular.Columns.Contains("Select"))
                {
                    foreach (DataGridViewRow row in dataGridViewRegular.Rows)
                    {
                        // Check if the checkbox in the "Select" column is checked
                        if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                        {
                            int memberId = Convert.ToInt32(row.Cells["RegularMemberId"].Value);
                            selectedIds.Add(memberId);
                        }
                    }
                }

                if (selectedIds.Count == 0)
                {
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to archive the selected members?",
                    "Confirm Archive",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    ArchiveSelectedMembers(selectedIds);
                    MessageBox.Show("Selected members have been archived.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRegularMembers();  
                    ToggleMultiDeleteMode(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while archiving members: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonMultiDelete_Click(object sender, EventArgs e)
        {
            ToggleMultiDeleteMode(true);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ToggleMultiDeleteMode(false);
        }

        private void dataGridViewRegular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRegular.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                dataGridViewRegular.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

            private void timerLoad_Tick(object sender, EventArgs e)
            {
                LoadRegularMembers();
                timerLoad.Stop();
            }
            private void InitializeLoadMemberTimer()
            {
                timerLoad.Interval = 500;
                timerLoad.Tick += timerLoad_Tick;
                timerLoad.Start();
            }
    }
}
