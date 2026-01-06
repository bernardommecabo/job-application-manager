using ProjectShared.DTOs.response;
using ProjectWinForms.Services;
using ProjectWinForms.Services.Interfaces;

namespace ProjectWinForms
{
    public partial class HomeForm : Form
    {
        private readonly IApplicantServiceForms _applicantService;
        private readonly IApplicationServiceForms _applicationService;

        public HomeForm(IApplicantServiceForms applicantService, IApplicationServiceForms applicationService)
        {
            InitializeComponent(); 
            _applicantService = applicantService;
            _applicationService = applicationService;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string loginInput = txtLoginInput.Text.Trim();

            bool isEmail = loginInput.Contains("@") && loginInput.Contains(".");


            FormSignUp signUpForm = new FormSignUp(loginInput, isEmail);
            signUpForm.ShowDialog();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoginInput.Text))
            {
                MessageBox.Show("Write your username or Email!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                Cursor = Cursors.WaitCursor;

                string loginInput = txtLoginInput.Text.Trim();

                LoginDTOResponse? user = await _applicantService.LoginAsync(loginInput);

                if (user != null)
                {
                    MessageBox.Show($"Welcome, {user.Name}!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var profileForm = new UserProfileForm(user, _applicationService);
                    this.Hide();
                    profileForm.ShowDialog();

                    this.Show();
                    txtLoginInput.Clear();
                }
                else
                {
                    var resposta = MessageBox.Show(
                        "User not found.\nWould you like to sign up now?",
                        "Login",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resposta == DialogResult.Yes)
                    {
                        bool isEmail = loginInput.Contains("@") && loginInput.Contains(".");

                        var formCadastro = new FormSignUp(loginInput, isEmail);
                        formCadastro.Show();
                    }
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"An error has occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }
}
