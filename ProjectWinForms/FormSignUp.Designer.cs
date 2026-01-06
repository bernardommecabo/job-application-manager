namespace ProjectWinForms
{
    partial class FormSignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            txtWebsite = new TextBox();
            websiteLabel = new Label();
            txtPhone = new TextBox();
            phoneLabel = new Label();
            signupLabel = new Label();
            btnSignUp = new Button();
            btnClose = new Button();
            mandatory = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 132);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(103, 132);
            txtUsername.Margin = new Padding(1);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(257, 23);
            txtUsername.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(103, 163);
            txtEmail.Margin = new Padding(1);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(257, 23);
            txtEmail.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 163);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Email";
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(103, 218);
            txtWebsite.Margin = new Padding(1);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(257, 23);
            txtWebsite.TabIndex = 7;
            // 
            // websiteLabel
            // 
            websiteLabel.AutoSize = true;
            websiteLabel.Location = new Point(39, 218);
            websiteLabel.Margin = new Padding(1, 0, 1, 0);
            websiteLabel.Name = "websiteLabel";
            websiteLabel.Size = new Size(49, 15);
            websiteLabel.TabIndex = 6;
            websiteLabel.Text = "Website";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(103, 190);
            txtPhone.Margin = new Padding(1);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(257, 23);
            txtPhone.TabIndex = 5;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(26, 190);
            phoneLabel.Margin = new Padding(1, 0, 1, 0);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(63, 15);
            phoneLabel.TabIndex = 4;
            phoneLabel.Text = "Phone No.";
            // 
            // signupLabel
            // 
            signupLabel.AutoSize = true;
            signupLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            signupLabel.Location = new Point(156, 51);
            signupLabel.Margin = new Padding(1, 0, 1, 0);
            signupLabel.Name = "signupLabel";
            signupLabel.Size = new Size(98, 32);
            signupLabel.TabIndex = 8;
            signupLabel.Text = "Sign Up";
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(126, 257);
            btnSignUp.Margin = new Padding(1);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(79, 22);
            btnSignUp.TabIndex = 9;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(212, 257);
            btnClose.Margin = new Padding(1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(79, 22);
            btnClose.TabIndex = 10;
            btnClose.Text = "Cancel";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // mandatory
            // 
            mandatory.AutoSize = true;
            mandatory.ForeColor = Color.Red;
            mandatory.Location = new Point(89, 132);
            mandatory.Margin = new Padding(1, 0, 1, 0);
            mandatory.Name = "mandatory";
            mandatory.Size = new Size(12, 15);
            mandatory.TabIndex = 11;
            mandatory.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(89, 163);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 12;
            label3.Text = "*";
            // 
            // FormSignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 344);
            Controls.Add(btnClose);
            Controls.Add(btnSignUp);
            Controls.Add(signupLabel);
            Controls.Add(txtWebsite);
            Controls.Add(websiteLabel);
            Controls.Add(txtPhone);
            Controls.Add(phoneLabel);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(mandatory);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(1);
            Name = "FormSignUp";
            Text = "FormSignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private Label label2;
        private TextBox txtWebsite;
        private Label websiteLabel;
        private TextBox txtPhone;
        private Label phoneLabel;
        private Label signupLabel;
        private Button btnSignUp;
        private Button btnClose;
        private Label mandatory;
        private Label label3;
    }
}