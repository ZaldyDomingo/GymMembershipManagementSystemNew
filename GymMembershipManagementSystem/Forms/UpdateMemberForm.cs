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
    public partial class UpdateMemberForm : Form
    {
        private SqlConnection sqlConnection;
        public UpdateMemberForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            LoadMemberData();
            SetupDataGridView();
        }
        private void SetupDataGridView()
        {
            dataGridViewMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewMembers.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridViewMembers.RowTemplate.Height = 28;
            dataGridViewMembers.ColumnHeadersHeight = 28;
            dataGridViewMembers.EditMode = DataGridViewEditMode.EditOnEnter;
            textBoxSearchMember.TextChanged += textBoxSearchMember_TextChanged;

        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public void LoadMemberData()
        {
            string query = @"
                SELECT RegularMemberId AS MemberId, FirstName, LastName, 'Regular' AS MemberType FROM RegularMember
                UNION
                SELECT StudentId AS MemberId, FirstName, LastName, 'Student' AS MemberType FROM StudentMember";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataGridViewMembers.DataSource = dataTable;
            dataGridViewMembers.Columns["MemberId"].Visible = false;
        }

        private void dataGridViewMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected member's ID and type
            int memberId = Convert.ToInt32(dataGridViewMembers.Rows[e.RowIndex].Cells["MemberId"].Value);
            string memberType = dataGridViewMembers.Rows[e.RowIndex].Cells["MemberType"].Value.ToString();

            // Open the UpdateMember form and pass the member ID and type
            UpdateMember updateMemberForm = new UpdateMember(memberId, memberType);
            updateMemberForm.Show();
        }

        private void textBoxSearchMember_TextChanged(object sender, EventArgs e)
        {
            // Get the search text
            string searchText = textBoxSearchMember.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // If the search box is empty, reload all data
                LoadMemberData();
                return;
            }

            // Create a filter query to search for members by first or last name
            string query = @"
                SELECT RegularMemberId AS MemberId, FirstName, LastName, 'Regular' AS MemberType FROM RegularMember
                WHERE FirstName LIKE @SearchText OR LastName LIKE @SearchText
                UNION
                SELECT StudentId AS MemberId, FirstName, LastName, 'Student' AS MemberType FROM StudentMember
                WHERE FirstName LIKE @SearchText OR LastName LIKE @SearchText";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // Rebind the filtered data
            dataGridViewMembers.DataSource = dataTable;

            // Ensure the first row is selected
            if (dataGridViewMembers.Rows.Count > 0)
            {
                dataGridViewMembers.Rows[0].Selected = true;
            }
        }
    }
}
