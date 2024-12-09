using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymMembershipManagementSystem
{
    public partial class NewMemberForm : Form
    {
        private SqlConnection sqlConnection;
        private const decimal MembershipFee = 350;
        public NewMemberForm()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            MaskedFirstNameText();
            MaskedLastNameText();
            MaskedAddressText();
            MaskedAgeText();
            MaskedMobileNumber();
            MaskedEmail();
            MaskedGuardianFullName();
            MaskedGuardianMobileNumber();
        }

        private void MaskedAddressText()
        {
            textBoxAddress.Text = "Address";
            textBoxAddress.ForeColor = Color.Gray;
            // Use Singleton Pattern for placeholder management
            MaskingMethod.Instance.AddPlaceholder(textBoxAddress, "Address");
            textBoxAddress.KeyPress += MaskingMethod.Instance.ValidateNameInput;
            textBoxAddress.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxAddress, "Address");
            textBoxAddress.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxAddress, "Address");
        }

        private void MaskedFirstNameText()
        {
            textBoxFirstName.ForeColor = Color.Gray;
            // Use Singleton Pattern for placeholder management
            MaskingMethod.Instance.AddPlaceholder(textBoxFirstName, "First name");
            textBoxFirstName.KeyPress += MaskingMethod.Instance.ValidateNameInput;
            textBoxFirstName.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxFirstName, "First name");
            textBoxFirstName.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxFirstName, "First name");
        }

        private void MaskedLastNameText()
        {
            textBoxLastName.ForeColor = Color.Gray;
            // Use Singleton Pattern for placeholder management
            MaskingMethod.Instance.AddPlaceholder(textBoxLastName, "Last name");
            textBoxLastName.KeyPress += MaskingMethod.Instance.ValidateNameInput;
            textBoxLastName.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxLastName, "Last name");
            textBoxLastName.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxLastName, "Last name");
        }
        private void MaskedAgeText()
        {
            textBoxAge.ForeColor = Color.Gray;
            // Use Singleton Pattern for placeholder management
            MaskingMethod.Instance.AddPlaceholder(textBoxAge, "Age");
            textBoxAge.KeyPress += MaskingMethod.Instance.ValidateNameInput;
            textBoxAge.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxAge, "Age");
            textBoxAge.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxAge, "Age");
        }
        private void MaskedMobileNumber()
        {
            textBoxMobileNumber.ForeColor = Color.Gray;
            // Use Singleton Pattern for placeholder management
            MaskingMethod.Instance.AddPlaceholder(textBoxMobileNumber, "Mobile Number");
            textBoxMobileNumber.KeyPress += MaskingMethod.Instance.ValidateNameInput;
            textBoxMobileNumber.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxMobileNumber, "Mobile Number");
            textBoxMobileNumber.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxMobileNumber, "Mobile Number");
        }
        private void MaskedEmail()
        {
            textBoxEmail.ForeColor = Color.Gray;
            // Use Singleton Pattern for placeholder management
            MaskingMethod.Instance.AddPlaceholder(textBoxEmail, "Email");
            textBoxEmail.KeyPress += MaskingMethod.Instance.ValidateNameInput;
            textBoxEmail.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxEmail, "Email");
            textBoxEmail.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxEmail, "Email");
        }
        private void MaskedGuardianFullName()
        {
            textBoxGuardianFullName.ForeColor = Color.Gray;
            // Use Singleton Pattern for placeholder management
            MaskingMethod.Instance.AddPlaceholder(textBoxGuardianFullName, "Full Name");
            textBoxGuardianFullName.KeyPress += MaskingMethod.Instance.ValidateNameInput;
            textBoxGuardianFullName.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxGuardianFullName, "Full Name");
            textBoxGuardianFullName.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxGuardianFullName, "Full Name");
        }
        private void MaskedGuardianMobileNumber()
        {
            textBoxGuardianNumber.ForeColor = Color.Gray;
            // Use Singleton Pattern for placeholder management
            MaskingMethod.Instance.AddPlaceholder(textBoxGuardianNumber, "Mobile Number");
            textBoxGuardianNumber.KeyPress += MaskingMethod.Instance.ValidateNameInput;
            textBoxGuardianNumber.Enter += (sender, e) => MaskingMethod.Instance.RemovePlaceholder(textBoxGuardianNumber, "Mobile Number");
            textBoxGuardianNumber.Leave += (sender, e) => MaskingMethod.Instance.AddPlaceholder(textBoxGuardianNumber, "Mobile Number");
        }
        private void buttonRegister_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAge.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
                    string.IsNullOrWhiteSpace(textBoxMobileNumber.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                    string.IsNullOrWhiteSpace(textBoxGuardianFullName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxGuardianNumber.Text))
                {
                    MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    // Collect member details
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
                    string datejoined = dateTimePickerJoinedDate.Value.ToString("yyyy-MM-dd");
                    DateTime startDate = dateTimePickerJoinedDate.Value;
                    DateTime expirationDate = startDate.AddDays(31); // Add 31 days for membership

                    byte[] imageBytes = ConvertImageToByteArray(pictureBoxMember.Image);

                    // Insert into database
                    string query = "INSERT INTO StudentMember (FirstName, LastName, DateOfBirth, Age, Gender, Address, MobileNumber, Email, EmergencyContactName, EmergencyContactPhone, DateJoined, ProfileImage, MembershipStartDate, MembershipFee, MembershipEndDate) " +
                                   "VALUES (@FirstName, @LastName, @DateOfBirth, @Age, @Gender, @Address, @MobileNumber, @Email, @EmergencyContactName, @EmergencyContactPhone, @DateJoined, @ProfileImage, @MembershipStartDate, @MembershipFee, @MembershipEndDate)";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstname);
                        command.Parameters.AddWithValue("@LastName", lastname);
                        command.Parameters.AddWithValue("@DateOfBirth", dateofbirth);
                        command.Parameters.AddWithValue("@Age", age);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", homeaddress);
                        command.Parameters.AddWithValue("@MobileNumber", mobileNumber);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@EmergencyContactName", guardianname);
                        command.Parameters.AddWithValue("@EmergencyContactPhone", guardiannumber);
                        command.Parameters.AddWithValue("@DateJoined", datejoined);
                        command.Parameters.AddWithValue("@ProfileImage", imageBytes);
                        command.Parameters.AddWithValue("@MembershipStartDate", startDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@MembershipFee", MembershipFee);
                        command.Parameters.AddWithValue("@MembershipEndDate", expirationDate.ToString("yyyy-MM-dd"));

                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();

                        // Generate Invoice
                        string savePath = GetSavePath($"{firstname}_{lastname}'s_Invoice.pdf");
                        try
                        {
                            InvoiceGenerator.GenerateInvoice(
                                firstname,
                                lastname,
                                homeaddress,
                                mobileNumber,
                                MembershipFee,
                                startDate,
                                expirationDate,
                                savePath
                            );
                            MessageBox.Show($"Member registered successfully! Invoice saved at: {savePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Member registered, but failed to generate invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // Clear form
                        ClearFormFields();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetSavePath(string defaultFileName)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "Save Invoice As";
                saveFileDialog.FileName = defaultFileName;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
                else
                {
                    throw new Exception("Save operation was canceled.");
                }
            }
        }
        private void ClearFormFields()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxEmail.Clear();
            textBoxAddress.Clear();
            textBoxMobileNumber.Clear();
            textBoxAge.Clear();
            textBoxGuardianFullName.Clear();
            textBoxGuardianNumber.Clear();
            pictureBoxMember.Image = null;
            dateTimePickerJoinedDate.Value = DateTime.Now; // Reset the DateTimePicker to current date
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=LAPTOP-9VQCFDCQ\\SQLEXPRESS01;Initial Catalog=gymMembership;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null) return null;

            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
