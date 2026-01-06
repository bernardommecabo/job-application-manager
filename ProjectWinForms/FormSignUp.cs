using ProjectShared.DTOs.request;
using ProjectWinForms.Services;
using ProjectWinForms.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectWinForms
{
    public partial class FormSignUp : Form
    {

        private readonly IApplicantServiceForms _service;
        public FormSignUp()
        {
            InitializeComponent();
            _service = new ApplicantServiceForms();
        }

        public FormSignUp(string input, bool isEmail) : this()
        {
            if (string.IsNullOrWhiteSpace(input)) return;

            if (isEmail)
            {
                txtEmail.Text = input;
            }
            else
            {
                txtUsername.Text = input;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            btnSignUp.Enabled = false;
            txtUsername.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtWebsite.ReadOnly = true;
            txtPhone.ReadOnly = true;
            Cursor = Cursors.WaitCursor;

            try
            {
                var newApplicant = new ApplicantDTORequest
                {
                    Name = txtUsername.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Website = txtWebsite.Text.Trim()
                };

                if (string.IsNullOrEmpty(newApplicant.Name) || string.IsNullOrEmpty(newApplicant.Email))
                {
                    MessageBox.Show("Username and Email must not be null!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                await _service.CreateAsync(newApplicant);

                MessageBox.Show("Registration successful!", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registration was not possible.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnSignUp.Enabled = true;
                txtUsername.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtWebsite.ReadOnly = false;
                txtPhone.ReadOnly = false;
                Cursor = Cursors.Default;
            }
        }
    }
}
