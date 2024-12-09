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

namespace GymMembershipManagementSystem
{
    public partial class UpdateMember : Form
    {
        private SqlConnection sqlConnection;
        private int memberId;
        private string memberType;
        public UpdateMember(int memberId, string memberType)
        {
            InitializeComponent();
            this.memberId = memberId;
            this.memberType = memberType;
            InitializeDatabaseConnection();
            LoadMemberDetails();
            string firstname = textBoxFirstName.Text;
            string lastname = textBoxLastName.Text;
            string dateofbirth = dateTimePickerDOB.Value.ToString("yyyy-MM-dd");
            int age = int.Parse(textBoxAge.Text);
            string homeaddress = textBoxAddress.Text;
            string gender = radioButtonMale.Checked ? "Male" : "Female";
            string mobileNumber = textBoxMobileNumber.Text;
            string email = textBoxEmail.Text;
            string guardianname = textBoxGuardianFullName.Text;
            string guardiannumber = textBoxGuardianNumber.Text;

        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void LoadMemberDetails()
        {
            string query = "";

            if (memberType == "Regular")
            {
                query = @"
            SELECT RegularMemberId, FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, EmergencyContactName, EmergencyContactPhone, DateJoined, ProfileImage, MembershipStartDate, MembershipFee, MembershipEndDate
            FROM RegularMember
            WHERE RegularMemberId = @MemberId";
            }
            else if (memberType == "Student")
            {
                query = @"
            SELECT StudentId, FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, EmergencyContactName, EmergencyContactPhone, DateJoined, ProfileImage, MembershipStartDate, MembershipFee, MembershipEndDate
            FROM StudentMember
            WHERE StudentId = @MemberId";
            }

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@MemberId", memberId);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                textBoxFirstName.Text = row["FirstName"].ToString();
                textBoxLastName.Text = row["LastName"].ToString();
                dateTimePickerDOB.Value = Convert.ToDateTime(row["DateOfBirth"]);
                textBoxAge.Text = row["Age"].ToString();
                radioButtonMale.Checked = row["Gender"].ToString() == "Male";
                radioButtonFemale.Checked = row["Gender"].ToString() == "Female";
                textBoxAddress.Text = row["Address"].ToString();
                textBoxMobileNumber.Text = row["MobileNumber"].ToString();
                textBoxEmail.Text = row["Email"].ToString();
                textBoxGuardianFullName.Text = row["EmergencyContactName"].ToString();
                textBoxGuardianNumber.Text = row["EmergencyContactPhone"].ToString();

                // Convert image if it exists
                if (row["ProfileImage"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])row["ProfileImage"];
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBoxMember.Image = Image.FromStream(ms);
                    }
                }
            }

            // Hide the update button based on member type
            if (memberType == "Regular")
            {
                buttonUpdateRegular.Visible = true;
                buttonUpdateStudent.Visible = false;
            }
            else if (memberType == "Student")
            {
                buttonUpdateRegular.Visible = false;
                buttonUpdateStudent.Visible = true;
            }
        }



        private void pictureBoxMember_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxMember.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private bool AreTextBoxesEmpty()
        {
            // Check if any of the textboxes are empty
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                string.IsNullOrWhiteSpace(textBoxAge.Text) ||
                string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
                string.IsNullOrWhiteSpace(textBoxMobileNumber.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxGuardianFullName.Text) ||
                string.IsNullOrWhiteSpace(textBoxGuardianNumber.Text))
            {
                MessageBox.Show("You cannot leave the text boxes blank.");
                return true; // Text boxes are empty
            }
            return false; // All text boxes are filled
        }

        private bool IsDataUnchanged()
        {
            string query = memberType == "Regular" ?
                "SELECT FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, EmergencyContactName, EmergencyContactPhone FROM RegularMember WHERE RegularMemberId = @MemberId" :
                "SELECT FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, EmergencyContactName, EmergencyContactPhone FROM StudentMember WHERE StudentId = @MemberId";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@MemberId", memberId);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    bool isSame =
                        reader["FirstName"].ToString() == textBoxFirstName.Text &&
                        reader["LastName"].ToString() == textBoxLastName.Text &&
                        Convert.ToDateTime(reader["DateOfBirth"]).ToString("yyyy-MM-dd") == dateTimePickerDOB.Value.ToString("yyyy-MM-dd") &&
                        reader["Age"].ToString() == textBoxAge.Text &&
                        reader["Gender"].ToString() == (radioButtonMale.Checked ? "Male" : "Female") &&
                        reader["Address"].ToString() == textBoxAddress.Text &&
                        reader["MobileNumber"].ToString() == textBoxMobileNumber.Text &&
                        reader["Email"].ToString() == textBoxEmail.Text &&
                        reader["EmergencyContactName"].ToString() == textBoxGuardianFullName.Text &&
                        reader["EmergencyContactPhone"].ToString() == textBoxGuardianNumber.Text;

                    sqlConnection.Close();
                    return isSame;
                }

                sqlConnection.Close();
                return false;
            }
        }

        private void buttonUpdateStudent_Click(object sender, EventArgs e)
        {
            if (AreTextBoxesEmpty())
            {
                return; // Exit if any text box is empty
            }

            if (IsDataUnchanged())
            {
                MessageBox.Show("You cannot input the same value.");
                return;
            }

            // Proceed with the update logic
            string updateQuery = @"
            UPDATE StudentMember 
            SET FirstName = @FirstName,
            LastName = @LastName,
            DateOfBirth = @DateOfBirth,
            Age = @Age,
            Gender = @Gender,
            Address = @Address,
            MobileNumber = @MobileNumber,
            Email = @Email,
            EmergencyContactName = @GuardianName,
            EmergencyContactPhone = @GuardianNumber
            WHERE StudentId = @MemberId";

            UpdateMemberDetails(updateQuery);
        }

        private void buttonUpdateRegular_Click(object sender, EventArgs e)
        {
            if (AreTextBoxesEmpty())
            {
                return; // Exit if any text box is empty
            }

            if (IsDataUnchanged())
            {
                MessageBox.Show("You cannot input the same value.");
                return;
            }
            // Proceed with the update logic
            string updateQuery = @"
            UPDATE RegularMember 
            SET FirstName = @FirstName,
            LastName = @LastName,
            DateOfBirth = @DateOfBirth,
            Age = @Age,
            Gender = @Gender,
            Address = @Address,
            MobileNumber = @MobileNumber,
            Email = @Email,
            EmergencyContactName = @GuardianName,
            EmergencyContactPhone = @GuardianNumber
            WHERE RegularMemberId = @MemberId";

            UpdateMemberDetails(updateQuery);
        }
        private void UpdateMemberDetails(string updateQuery)
        {
            SqlCommand command = new SqlCommand(updateQuery, sqlConnection);
            command.Parameters.AddWithValue("@FirstName", textBoxFirstName.Text);
            command.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
            command.Parameters.AddWithValue("@DateOfBirth", dateTimePickerDOB.Value.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Age", int.Parse(textBoxAge.Text));
            command.Parameters.AddWithValue("@Gender", radioButtonMale.Checked ? "Male" : "Female");
            command.Parameters.AddWithValue("@Address", textBoxAddress.Text);
            command.Parameters.AddWithValue("@MobileNumber", textBoxMobileNumber.Text);
            command.Parameters.AddWithValue("@Email", textBoxEmail.Text);
            command.Parameters.AddWithValue("@GuardianName", textBoxGuardianFullName.Text);
            command.Parameters.AddWithValue("@GuardianNumber", textBoxGuardianNumber.Text);
            command.Parameters.AddWithValue("@MemberId", memberId);

            try
            {
                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Member details updated successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: Member details not updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
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
