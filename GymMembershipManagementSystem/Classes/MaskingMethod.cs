using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace GymMembershipManagementSystem
{
    public class MaskingMethod
    {
        private static MaskingMethod _instance;
        private static readonly object _lock = new object();
        private MaskingMethod() { }

        public static MaskingMethod Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MaskingMethod();
                    }
                    return _instance;
                }
            }
        }
        public void AddPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }
        public void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
            }
        }
        public void ValidateNameInput(object sender, KeyPressEventArgs e)
        {
            // Allow letters, digits, spaces, '-', '@', '.', and '_'
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '-' &&
                e.KeyChar != '@' &&
                e.KeyChar != '.' &&
                e.KeyChar != '_')
            {
                e.Handled = true; // Prevent invalid character input
            }

            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Prevent consecutive spaces
                if (textBox.Text.EndsWith(" ") && e.KeyChar == ' ')
                {
                    e.Handled = true;
                }

                // Prevent consecutive hyphens
                if (textBox.Text.EndsWith("-") && e.KeyChar == '-')
                {
                    e.Handled = true;
                }

                // Prevent consecutive '@'
                if (textBox.Text.EndsWith("@") && e.KeyChar == '@')
                {
                    e.Handled = true;
                }

                // Prevent multiple periods in a row
                if (textBox.Text.EndsWith(".") && e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
        }

    }
}
