namespace ProjectWinForms
{
    partial class UserProfileForm
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
            lblWelcome = new Label();
            btnLogout = new Button();
            gridApplications = new DataGridView();
            groupBoxApplication = new GroupBox();
            label4 = new Label();
            cmbStatus = new ComboBox();
            dtpPreviewAnswer = new DateTimePicker();
            dtpAppliedDate = new DateTimePicker();
            websiteLabel = new Label();
            phoneLabel = new Label();
            txtPosition = new TextBox();
            label2 = new Label();
            txtCompany = new TextBox();
            label1 = new Label();
            btnAddApplication = new Button();
            btnEditApplication = new Button();
            btnDeleteApplication = new Button();
            ((System.ComponentModel.ISupportInitialize)gridApplications).BeginInit();
            groupBoxApplication.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(12, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(156, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, user";
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(1067, 11);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(97, 31);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // gridApplications
            // 
            gridApplications.AllowUserToAddRows = false;
            gridApplications.AllowUserToDeleteRows = false;
            gridApplications.AllowUserToResizeRows = false;
            gridApplications.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gridApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridApplications.Location = new Point(21, 58);
            gridApplications.Name = "gridApplications";
            gridApplications.ReadOnly = true;
            gridApplications.Size = new Size(762, 633);
            gridApplications.TabIndex = 2;
            gridApplications.SelectionChanged += gridApplications_SelectionChanged;
            // 
            // groupBoxApplication
            // 
            groupBoxApplication.Controls.Add(label4);
            groupBoxApplication.Controls.Add(cmbStatus);
            groupBoxApplication.Controls.Add(dtpPreviewAnswer);
            groupBoxApplication.Controls.Add(dtpAppliedDate);
            groupBoxApplication.Controls.Add(websiteLabel);
            groupBoxApplication.Controls.Add(phoneLabel);
            groupBoxApplication.Controls.Add(txtPosition);
            groupBoxApplication.Controls.Add(label2);
            groupBoxApplication.Controls.Add(txtCompany);
            groupBoxApplication.Controls.Add(label1);
            groupBoxApplication.Location = new Point(813, 58);
            groupBoxApplication.Name = "groupBoxApplication";
            groupBoxApplication.Size = new Size(351, 249);
            groupBoxApplication.TabIndex = 3;
            groupBoxApplication.TabStop = false;
            groupBoxApplication.Text = "Application";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 191);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 26;
            label4.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Applied", "Interviewing", "Offer", "Accepted", "Rejected" });
            cmbStatus.Location = new Point(89, 188);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(258, 23);
            cmbStatus.TabIndex = 25;
            // 
            // dtpPreviewAnswer
            // 
            dtpPreviewAnswer.Location = new Point(90, 147);
            dtpPreviewAnswer.Name = "dtpPreviewAnswer";
            dtpPreviewAnswer.Size = new Size(257, 23);
            dtpPreviewAnswer.TabIndex = 24;
            // 
            // dtpAppliedDate
            // 
            dtpAppliedDate.Location = new Point(90, 109);
            dtpAppliedDate.Name = "dtpAppliedDate";
            dtpAppliedDate.Size = new Size(257, 23);
            dtpAppliedDate.TabIndex = 23;
            // 
            // websiteLabel
            // 
            websiteLabel.AutoSize = true;
            websiteLabel.Location = new Point(34, 147);
            websiteLabel.Margin = new Padding(1, 0, 1, 0);
            websiteLabel.Name = "websiteLabel";
            websiteLabel.Size = new Size(51, 30);
            websiteLabel.TabIndex = 19;
            websiteLabel.Text = "Preview \r\nAnswer";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(10, 115);
            phoneLabel.Margin = new Padding(1, 0, 1, 0);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(75, 15);
            phoneLabel.TabIndex = 17;
            phoneLabel.Text = "Applied Date";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(90, 73);
            txtPosition.Margin = new Padding(1);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(257, 23);
            txtPosition.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 76);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 15;
            label2.Text = "Position";
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(90, 38);
            txtCompany.Margin = new Padding(1);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(257, 23);
            txtCompany.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 38);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 13;
            label1.Text = "Company";
            // 
            // btnAddApplication
            // 
            btnAddApplication.Location = new Point(809, 313);
            btnAddApplication.Name = "btnAddApplication";
            btnAddApplication.Size = new Size(75, 23);
            btnAddApplication.TabIndex = 4;
            btnAddApplication.Text = "Add";
            btnAddApplication.UseVisualStyleBackColor = true;
            btnAddApplication.Click += btnAddApplication_Click;
            // 
            // btnEditApplication
            // 
            btnEditApplication.Location = new Point(950, 313);
            btnEditApplication.Name = "btnEditApplication";
            btnEditApplication.Size = new Size(75, 23);
            btnEditApplication.TabIndex = 5;
            btnEditApplication.Text = "Edit";
            btnEditApplication.UseVisualStyleBackColor = true;
            btnEditApplication.Click += btnEditApplication_Click;
            // 
            // btnDeleteApplication
            // 
            btnDeleteApplication.Location = new Point(1085, 313);
            btnDeleteApplication.Name = "btnDeleteApplication";
            btnDeleteApplication.Size = new Size(75, 23);
            btnDeleteApplication.TabIndex = 6;
            btnDeleteApplication.Text = "Delete";
            btnDeleteApplication.UseVisualStyleBackColor = true;
            btnDeleteApplication.Click += btnDeleteApplication_Click;
            // 
            // UserProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1176, 703);
            Controls.Add(btnDeleteApplication);
            Controls.Add(btnEditApplication);
            Controls.Add(btnAddApplication);
            Controls.Add(groupBoxApplication);
            Controls.Add(gridApplications);
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserProfileForm";
            Text = "UserProfileForm";
            Load += UserProfileForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridApplications).EndInit();
            groupBoxApplication.ResumeLayout(false);
            groupBoxApplication.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnLogout;
        private DataGridView gridApplications;
        private GroupBox groupBoxApplication;
        private Button btnAddApplication;
        private Button btnEditApplication;
        private Button btnDeleteApplication;
        private Label websiteLabel;
        private Label phoneLabel;
        private TextBox txtPosition;
        private Label label2;
        private TextBox txtCompany;
        private Label label1;
        private DateTimePicker dtpPreviewAnswer;
        private DateTimePicker dtpAppliedDate;
        private Label label4;
        private ComboBox cmbStatus;
    }
}