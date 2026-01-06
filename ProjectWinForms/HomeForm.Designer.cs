namespace ProjectWinForms
{
    partial class HomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnLogin = new Button();
            btnSignUp = new Button();
            txtLoginInput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 4);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 0;
            label1.Text = "Job Application Manager";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(234, 165);
            btnLogin.Margin = new Padding(1);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(79, 22);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(330, 165);
            btnSignUp.Margin = new Padding(1);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(79, 22);
            btnSignUp.TabIndex = 4;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // txtLoginInput
            // 
            txtLoginInput.Location = new Point(234, 143);
            txtLoginInput.Margin = new Padding(1);
            txtLoginInput.Name = "txtLoginInput";
            txtLoginInput.PlaceholderText = "Username / Email";
            txtLoginInput.Size = new Size(177, 23);
            txtLoginInput.TabIndex = 5;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 401);
            Controls.Add(txtLoginInput);
            Controls.Add(btnSignUp);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Margin = new Padding(1);
            Name = "HomeForm";
            Text = "Job Application Manager by Bernardo Mecabo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLogin;
        private Button btnSignUp;
        private TextBox txtLoginInput;
    }
}
