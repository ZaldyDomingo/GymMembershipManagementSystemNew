using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GymMembershipManagementSystem
{
    public partial class WalkInMember : Form
    {
        private SqlConnection sqlConnection;
        public WalkInMember()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            InitializeMaskedTextFields();
        }

        private void InitializeMaskedTextFields()
        {
            MaskTextField(textBoxFirstName, "First name");
            MaskTextField(textBoxLastName, "Last name");
            MaskTextField(textBoxAddress, "Address");
            MaskTextField(textBoxPhoneNumber, "Phone Number");
        }

        private void MaskTextField(TextBox textBox, string placeholder)
        {
            MaskingMethod.Instance.AddPlaceholder(textBox, placeholder);
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBox, placeholder);
            textBox.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBox, placeholder);

            textBox.KeyPress += MaskingMethod.Instance.ValidateNameInput;
        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            // Validate that all required fields are filled
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhoneNumber.Text) ||
                textBoxFirstName.Text == "First name" ||
                textBoxLastName.Text == "Last name" ||
                textBoxAddress.Text == "Address" ||
                textBoxPhoneNumber.Text == "Phone Number")
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Retrieve data from the form
                string firstName = textBoxFirstName.Text.Trim();
                string lastName = textBoxLastName.Text.Trim();
                string address = textBoxAddress.Text.Trim();
                string phoneNumber = textBoxPhoneNumber.Text.Trim();
                string registrationDate = dateTimePickerJoinedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string expirationDate = DateTime.Now.AddHours(12).ToString("yyyy-MM-dd HH:mm:ss");
                decimal membershipFee = 60.00m; // Fixed fee

                // SQL Insert Query
                string query = "INSERT INTO WalkInMember (FirstName, LastName, Address, PhoneNumber, RegistrationDate, ExpirationDate, MembershipFee) " +
                               "VALUES (@FirstName, @LastName, @Address, @PhoneNumber, @RegistrationDate, @ExpirationDate, @MembershipFee)";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@RegistrationDate", registrationDate);
                    command.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                    command.Parameters.AddWithValue("@MembershipFee", membershipFee);

                    // Open the connection, execute the query, and close the connection
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    sqlConnection.Close();

                    // Success message
                    MessageBox.Show("Walk-in member registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear form fields after successful registration
                    ClearForm();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxAddress.Clear();                                                                                                                 
            textBoxPhoneNumber.Clear();
            dateTimePickerJoinedDate.Value = DateTime.Now; // Reset the DateTimePicker to the current date
        }
    }
}
