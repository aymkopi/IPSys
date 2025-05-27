using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntdUI;

namespace IPSys
{
    public partial class ClientEdit : Form
    {
        private Form form;
        private Client client;



        public ClientEdit()
        {
            InitializeComponent();
        }

        public ClientEdit(Form form, Client client)
        {
            this.form = form;
            this.client = client;
            InitializeComponent();
            inputClientID.Text = client.ClientID;
            inputClientName.Text = client.ClientName;
            inputClientContact.Text = client.ClientContact;
            inputClientEmail.Text = client.ClientEmail;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            client.ClientID = inputClientID.Text;
            client.ClientName = inputClientName.Text;
            client.ClientContact = inputClientContact.Text;
            client.ClientEmail = inputClientEmail.Text;
            this.Close();
        }

        private void inputClientName_TextChanged(object sender, EventArgs e)
        {
            saveButton.Enabled = true; // Enable save button initially

            // Validate each input and update status
            if (string.IsNullOrWhiteSpace(inputClientName?.Text))
            {
                inputClientName.Status = TType.Error;
                saveButton.Enabled = false;
            }
            else
            {
                inputClientName.Status = TType.None;
            }

            if (string.IsNullOrWhiteSpace(inputClientContact?.Text) || inputClientContact.Text.Any(char.IsAsciiLetter) || inputClientContact.Text.Length != 11 || !inputClientContact.Text.StartsWith("09"))
            {
                saveButton.Enabled = false;
                inputClientContact.Status = TType.Error;

                AntdUI.Tooltip.open(new AntdUI.Tooltip.Config(inputClientContact, "Please enter a valid number.")
                {
                    Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
                    ArrowAlign = TAlign.BL,
                });
            }
            else
            {
                inputClientContact.Status = TType.None;
                this.Focus();
            }
            if (string.IsNullOrWhiteSpace(inputClientEmail?.Text))
            {
                inputClientEmail.Status = TType.Error;
                saveButton.Enabled = false;
            }
            else
            {
                inputClientEmail.Status = TType.None;
            }

        }
    }
}
