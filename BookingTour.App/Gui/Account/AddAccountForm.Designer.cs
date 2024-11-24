namespace BookingTour.App.Gui.Account
{
    partial class AddAccountForm
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
            var dummyLabel = new TextBox();
            dummyLabel.Size = new Size(0, 0); // Kích thước bằng 0
            dummyLabel.Location = new Point(0, 0); // Đặt ở góc trên cùng
            Controls.Add(dummyLabel);
            dummyLabel.Focus(); //

            titleLabel = new Label();
            usernameLabel = new Label();
            usernameTextbox = new TextBox();
            nameLabel = new Label();
            nameTextbox = new TextBox();
            emailLabel = new Label();
            mailTextbox = new TextBox();
            phoneLabel = new Label();
            phoneTextbox = new TextBox();
            passwordLabel = new Label();
            passTextbox = new TextBox();
            roleLabel = new Label();
            roleComboBox = new ComboBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(92, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(205, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Thêm tài khoản mới";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLabel.Location = new Point(46, 63);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(103, 20);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "Mã nhân viên";
            // 
            // usernameTextbox
            // 
            usernameTextbox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameTextbox.Location = new Point(46, 86);
            usernameTextbox.Name = "usernameTextbox";
            usernameTextbox.Size = new Size(295, 27);
            usernameTextbox.TabIndex = 2;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(46, 125);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(105, 20);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Tên nhân viên";
            // 
            // nameTextbox
            // 
            nameTextbox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameTextbox.Location = new Point(46, 148);
            nameTextbox.Name = "nameTextbox";
            nameTextbox.Size = new Size(295, 27);
            nameTextbox.TabIndex = 2;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLabel.Location = new Point(46, 187);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(46, 20);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Email";
            // 
            // mailTextbox
            // 
            mailTextbox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mailTextbox.Location = new Point(46, 210);
            mailTextbox.Name = "mailTextbox";
            mailTextbox.Size = new Size(295, 27);
            mailTextbox.TabIndex = 2;
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            phoneLabel.Location = new Point(46, 249);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(99, 20);
            phoneLabel.TabIndex = 1;
            phoneLabel.Text = "Số điện thoại";
            // 
            // phoneTextbox
            // 
            phoneTextbox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            phoneTextbox.Location = new Point(46, 272);
            phoneTextbox.Name = "phoneTextbox";
            phoneTextbox.Size = new Size(295, 27);
            phoneTextbox.TabIndex = 2;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(46, 311);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(74, 20);
            passwordLabel.TabIndex = 1;
            passwordLabel.Text = "Mật khẩu";
            // 
            // passTextbox
            // 
            passTextbox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passTextbox.Location = new Point(46, 334);
            passTextbox.Name = "passTextbox";
            passTextbox.PasswordChar = '*';
            passTextbox.Size = new Size(295, 27);
            passTextbox.TabIndex = 2;
            passTextbox.UseSystemPasswordChar = true;
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            roleLabel.Location = new Point(46, 373);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(54, 20);
            roleLabel.TabIndex = 1;
            roleLabel.Text = "Vai trò";
            // 
            // roleComboBox
            // 
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Location = new Point(46, 396);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(295, 23);
            roleComboBox.TabIndex = 3;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(21, 128, 61);
            saveButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveButton.ForeColor = SystemColors.ButtonHighlight;
            saveButton.Location = new Point(70, 451);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(96, 38);
            saveButton.TabIndex = 4;
            saveButton.Text = "Lưu";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(153, 27, 27);
            cancelButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(200, 451);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(97, 38);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Hủy";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // AddAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 506);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(roleComboBox);
            Controls.Add(passTextbox);
            Controls.Add(phoneTextbox);
            Controls.Add(mailTextbox);
            Controls.Add(nameTextbox);
            Controls.Add(usernameTextbox);
            Controls.Add(roleLabel);
            Controls.Add(passwordLabel);
            Controls.Add(phoneLabel);
            Controls.Add(emailLabel);
            Controls.Add(nameLabel);
            Controls.Add(usernameLabel);
            Controls.Add(titleLabel);
            Name = "AddAccountForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddAccountForm";
            Load += AddAccountForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label usernameLabel;
        private TextBox usernameTextbox;
        private Label nameLabel;
        private TextBox nameTextbox;
        private Label emailLabel;
        private TextBox mailTextbox;
        private Label phoneLabel;
        private TextBox phoneTextbox;
        private Label passwordLabel;
        private TextBox passTextbox;
        private Label roleLabel;
        private ComboBox roleComboBox;
        private Button saveButton;
        private Button cancelButton;
    }
}