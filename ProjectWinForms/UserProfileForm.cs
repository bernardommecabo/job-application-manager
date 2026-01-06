using ProjectShared.DTOs.response;
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

namespace ProjectWinForms
{
    public partial class UserProfileForm : Form
    {
        private readonly IApplicationServiceForms _appService;
        private LoginDTOResponse _currentUser;

        public UserProfileForm(LoginDTOResponse user, IApplicationServiceForms service)
        {
            InitializeComponent();
            _currentUser = user;
            _appService = service;
        }

        private async void UserProfileForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_currentUser.Name ?? "User"}!";
            ConfigureGrid();
            await LoadApplicationsAsync();
            ClearInputs();
        }
        private void ConfigureGrid()
        {
            gridApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridApplications.MultiSelect = false;
            gridApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private async Task LoadApplicationsAsync()
        {
            try
            {
                gridApplications.Enabled = false;
                List<ApplicationSummaryDTOResponse> applications = await _appService.GetApplicationsAsync(_currentUser.Id);
                gridApplications.DataSource = applications;

                if (gridApplications.Columns["PreviewAnswer"] != null)
                    gridApplications.Columns["PreviewAnswer"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load applications: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                gridApplications.Enabled = true;
            }
        }

        private async void btnAddApplication_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var newApp = new ApplicationSummaryDTOResponse
            {
                CompanyName = txtCompany.Text,
                PositionTitle = txtPosition.Text,
                Status = cmbStatus.Text,
                AppliedDate = dtpAppliedDate.Value,
                PreviewAnswerDate = dtpPreviewAnswer.Value
            };

            try
            {
                await _appService.AddApplicationAsync(_currentUser.Id, newApp);
                await LoadApplicationsAsync();
                ClearInputs();
                MessageBox.Show("Application added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void btnEditApplication_Click(object sender, EventArgs e)
        {
            if (gridApplications.SelectedRows.Count == 0) return;
            if (!ValidateInputs()) return;

            var selectedApp = (ApplicationSummaryDTOResponse)gridApplications.SelectedRows[0].DataBoundItem;

            selectedApp.CompanyName = txtCompany.Text;
            selectedApp.PositionTitle = txtPosition.Text;
            selectedApp.Status = cmbStatus.Text;
            selectedApp.AppliedDate = dtpAppliedDate.Value;
            selectedApp.PreviewAnswerDate = dtpPreviewAnswer.Value;

            try
            {
                await _appService.UpdateApplicationAsync(_currentUser.Id, selectedApp);
                await LoadApplicationsAsync();
                MessageBox.Show("Application updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private async void btnDeleteApplication_Click(object sender, EventArgs e)
        {
            if (gridApplications.SelectedRows.Count == 0) return;

            var selectedApp = (ApplicationSummaryDTOResponse)gridApplications.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Delete {selectedApp.CompanyName}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _appService.DeleteApplicationAsync(_currentUser.Id, selectedApp.Id);
                    await LoadApplicationsAsync();
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void gridApplications_SelectionChanged(object sender, EventArgs e)
        {
            if (gridApplications.SelectedRows.Count > 0)
            {
                var selectedApp = (ApplicationSummaryDTOResponse)gridApplications.SelectedRows[0].DataBoundItem;

                txtCompany.Text = selectedApp.CompanyName;
                txtPosition.Text = selectedApp.PositionTitle;
                cmbStatus.Text = selectedApp.Status;

                if (selectedApp.AppliedDate > dtpAppliedDate.MinDate)
                {
                    dtpAppliedDate.Value = selectedApp.AppliedDate;
                }
                else
                {
                    dtpAppliedDate.Value = DateTime.Now;
                }
                var previewDate = selectedApp.PreviewAnswerDate ?? DateTime.Now;

                if (previewDate > dtpPreviewAnswer.MinDate)
                {
                    dtpPreviewAnswer.Value = previewDate;
                }
                else
                {
                    dtpPreviewAnswer.Value = DateTime.Now;
                }
            }
            else
            {
                ClearInputs();
            }
            UpdateButtonsState();
        }


        //Helper Methods
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearInputs()
        {
            txtCompany.Clear();
            txtPosition.Clear();
            cmbStatus.SelectedIndex = -1;
            dtpAppliedDate.Value = DateTime.Now;
            dtpPreviewAnswer.Value = DateTime.Now;
            gridApplications.ClearSelection();
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCompany.Text) || string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Please fill Company and Position fields.");
                return false;
            }
            return true;
        }
        private void UpdateButtonsState()
        {
            bool hasSelection = gridApplications.SelectedRows.Count > 0;
            btnAddApplication.Enabled = true;
            btnEditApplication.Enabled = hasSelection;
            btnDeleteApplication.Enabled = hasSelection;
        }
    }
}
