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
    public partial class ViewStudentMember : Form
    {
        private SqlConnection sqlConnection;
        public ViewStudentMember()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeSearchTimer();
            LoadStudents();
            FilterData();
            SetupDataGridView();
            buttonCheck.Visible = false;
            buttonCancel.Visible = false;
            buttonMultiDelete.Visible = true;

            // Hook up button click events
            buttonMultiDelete.Click += buttonMultiDelete_Click;
            buttonCheck.Click += buttonCheck_Click;
            buttonCancel.Click += buttonCancel_Click;
            dataGridViewStudent.CellContentClick += dataGridViewStudent_CellContentClick;
        }
        private void SetupDataGridView()
        {
            dataGridViewStudent.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewStudent.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewStudent.RowTemplate.Height = 28;
            dataGridViewStudent.ColumnHeadersHeight = 28;
            dataGridViewStudent.EditMode = DataGridViewEditMode.EditOnEnter;

            // Add TextChanged event for the search functionality
            textBoxSearchMember.TextChanged += (sender, e) =>
            {
                searchTimer.Stop();
                searchTimer.Start();  // This ensures a delay before applying the filter
            };
            if (dataGridViewStudent.Columns.Contains("FirstName"))
                dataGridViewStudent.Columns["FirstName"].HeaderText = "First Name";

            if (dataGridViewStudent.Columns.Contains("LastName"))
                dataGridViewStudent.Columns["LastName"].HeaderText = "Last Name";

            if (dataGridViewStudent.Columns.Contains("MobileNumber"))
                dataGridViewStudent.Columns["MobileNumber"].HeaderText = "Phone Number";

            if (dataGridViewStudent.Columns.Contains("RemainingDays"))
                dataGridViewStudent.Columns["RemainingDays"].HeaderText = "Days Left";

            if (dataGridViewStudent.Columns.Contains("EmergencyContactPhone"))
                dataGridViewStudent.Columns["EmergencyContactPhone"].HeaderText = "Emergency No";

            if (dataGridViewStudent.Columns.Contains("MembershipStartDate"))
                dataGridViewStudent.Columns["MembershipStartDate"].HeaderText = "Date Started";

            if (dataGridViewStudent.Columns.Contains("StudentId"))
                dataGridViewStudent.Columns["StudentId"].HeaderText = "Student Id";
        }
        private void InitializeSearchTimer()
        {
            searchTimer = new Timer();
            searchTimer.Interval = 500; // 500ms delay
            searchTimer.Tick += searchTimer_Tick;
        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public void LoadStudents()
        {
            try
            {
                // SQL query to get all necessary student information
                string query = "SELECT [StudentId], [FirstName], [LastName], [DateOfBirth], [Age], [Gender], [Address], [MobileNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], [DateJoined], [ProfileImage], [MembershipStartDate], [MembershipFee], [MembershipEndDate] FROM [dbo].[StudentMember]";
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                // Add columns for additional data if needed (e.g., RemainingDays)
                dataTable.Columns.Add("RemainingDays", typeof(int));

                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime membershipStartDate = Convert.ToDateTime(row["MembershipStartDate"]);
                    DateTime expirationDate = membershipStartDate.AddDays(31);
                    int remainingDays = (expirationDate - DateTime.Now).Days;

                    if (remainingDays <= 0)
                    {
                        row.Delete();
                    }
                    else
                    {
                        row["RemainingDays"] = remainingDays;
                    }
                }

                dataTable.AcceptChanges();


                dataGridViewStudent.DataSource = dataTable;


                dataGridViewStudent.Columns["Age"].Visible = false;
                dataGridViewStudent.Columns["ProfileImage"].Visible = false;
                dataGridViewStudent.Columns["DateOfBirth"].Visible = false;
                dataGridViewStudent.Columns["Address"].Visible = false;
                dataGridViewStudent.Columns["Gender"].Visible = false;
                dataGridViewStudent.Columns["DateJoined"].Visible = false;
                dataGridViewStudent.Columns["EmergencyContactName"].Visible = false;
                dataGridViewStudent.Columns["MembershipFee"].Visible = false;
                dataGridViewStudent.Columns["Email"].Visible = false;
                dataGridViewStudent.Columns["MembershipEndDate"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridViewStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Ensure it's not the header row
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridViewStudent.Rows[e.RowIndex];

                    // Retrieve only firstName and lastName now
                    string firstName = selectedRow.Cells["FirstName"].Value.ToString();
                    string lastName = selectedRow.Cells["LastName"].Value.ToString();

                    // Open the MemberDetailsForm with just the firstName and lastName
                    MemberDetailsForm detailsForm = new MemberDetailsForm(firstName, lastName);
                    detailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while opening student details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FilterData()
        {
            string searchTerm = textBoxSearchMember.Text.ToLower();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadStudents();
                return;
            }

            try
            {
                DataTable dataTable = ((DataTable)dataGridViewStudent.DataSource).Copy();

                var filteredRows = dataTable.AsEnumerable()
                    .Where(row => row["FirstName"].ToString().ToLower().Contains(searchTerm) ||
                                  row["LastName"].ToString().ToLower().Contains(searchTerm) ||
                                  row["MobileNumber"].ToString().ToLower().Contains(searchTerm)).ToList();

                DataTable filteredDataTable = dataTable.Clone();

                // Add matching rows first
                foreach (var row in filteredRows)
                {
                    filteredDataTable.ImportRow(row);
                }

                // Add remaining non-matching rows
                var remainingRows = dataTable.AsEnumerable()
                    .Where(row => !filteredRows.Contains(row)).ToList();

                foreach (var row in remainingRows)
                {
                    filteredDataTable.ImportRow(row);
                }

                // Bind the filtered data to the DataGridView
                dataGridViewStudent.DataSource = filteredDataTable;

                // Optionally hide unwanted columns
                dataGridViewStudent.Columns["ProfileImage"].Visible = false;
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
                dataGridViewStudent.CellPainting += DataGridViewStudent_CellPainting;
            }
        }

        private void DataGridViewStudent_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (!isHeaderCheckBoxHandled && e.RowIndex == -1 && e.ColumnIndex == 0) // Check header row
            {
                // Position the checkbox inside the header cell
                var cellRectangle = dataGridViewStudent.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                headerCheckBox.Location = new Point(cellRectangle.X + (cellRectangle.Width - headerCheckBox.Width) / 2, cellRectangle.Y + (cellRectangle.Height - headerCheckBox.Height) / 2);

                // Add the checkbox to the DataGridView controls
                dataGridViewStudent.Controls.Add(headerCheckBox);

                isHeaderCheckBoxHandled = true;
            }
        }
        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = headerCheckBox.Checked;

            foreach (DataGridViewRow row in dataGridViewStudent.Rows)
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
                if (!dataGridViewStudent.Columns.Contains("Select"))
                {
                    DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                    {
                        Name = "Select",
                        HeaderText = "", // Leave header text blank; we add a checkbox instead
                        Width = 30,
                        ReadOnly = false
                    };
                    dataGridViewStudent.Columns.Insert(0, checkBoxColumn);
                }

                // Add the header checkbox dynamically
                AddHeaderCheckBox();

                // Allow only the checkbox column to be editable
                dataGridViewStudent.ReadOnly = false;
                foreach (DataGridViewColumn column in dataGridViewStudent.Columns)
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
                if (dataGridViewStudent.Columns.Contains("Select"))
                {
                    dataGridViewStudent.Columns.Remove("Select");
                }

                // Hide the header checkbox
                if (headerCheckBox != null)
                {
                    headerCheckBox.Visible = false;
                    headerCheckBox.Checked = false;
                    isHeaderCheckBoxHandled = false;
                }

                dataGridViewStudent.ReadOnly = true; // Revert to read-only mode
            }
        }
        private void ArchiveSelectedStudents(List<int> studentIds)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString))
                {
                    connection.Open();

                    foreach (int id in studentIds)
                    {
                        // Archive student data
                        string insertArchivedQuery = @"
                    INSERT INTO ArchivedStudentMember
                    (StudentId, FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, 
                    EmergencyContactName, EmergencyContactPhone, DateJoined, ProfileImage, MembershipStartDate, 
                    MembershipFee, MembershipEndDate, ArchiveDate)
                    SELECT StudentId, FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, 
                           EmergencyContactName, EmergencyContactPhone, DateJoined, ProfileImage, MembershipStartDate, 
                           MembershipFee, MembershipEndDate, GETDATE()
                    FROM StudentMember
                    WHERE StudentId = @StudentId";

                        using (SqlCommand insertCommand = new SqlCommand(insertArchivedQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@StudentId", id);
                            insertCommand.ExecuteNonQuery();
                        }

                        // Remove the student from the original table
                        string deleteStudentQuery = "DELETE FROM StudentMember WHERE StudentId = @StudentId";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteStudentQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@StudentId", id);
                            deleteCommand.ExecuteNonQuery();
                        }

                        // Optionally remove check-in data related to the student (if not needed after archiving)
                        string deleteCheckInQuery = "DELETE FROM StudentMemberCheckIn WHERE StudentId = @StudentId";
                        using (SqlCommand deleteCheckInCommand = new SqlCommand(deleteCheckInQuery, connection))
                        {
                            deleteCheckInCommand.Parameters.AddWithValue("@StudentId", id);
                            deleteCheckInCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while archiving students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> selectedIds = new List<int>();
                if (dataGridViewStudent.Columns.Contains("Select"))
                {
                    foreach (DataGridViewRow row in dataGridViewStudent.Rows)
                    {
                        // Check if the checkbox in the "Select" column is checked
                        if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                        {
                            int studentId = Convert.ToInt32(row.Cells["StudentId"].Value);
                            selectedIds.Add(studentId);
                        }
                    }
                }

                if (selectedIds.Count == 0)
                {
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to archive the selected students?",
                    "Confirm Archive",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    ArchiveSelectedStudents(selectedIds);
                    MessageBox.Show("Selected students have been archived.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ToggleMultiDeleteMode(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while archiving students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudent.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                dataGridViewStudent.CommitEdit(DataGridViewDataErrorContexts.Commit); 
            }
        }
    }
}