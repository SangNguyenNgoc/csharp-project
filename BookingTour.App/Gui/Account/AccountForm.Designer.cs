namespace BookingTour.App.Gui.Account
{
    partial class AccountForm
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            username = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            phoneNumber = new DataGridViewTextBoxColumn();
            isBlock = new DataGridViewCheckBoxColumn();
            role = new DataGridViewTextBoxColumn();
            action = new DataGridViewImageColumn();
            createAccountButton = new FontAwesome.Sharp.IconButton();
            titleLabel = new Label();
            searchTextbox = new TextBox();
            searchButton = new FontAwesome.Sharp.IconButton();
            refershButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(244, 243, 247);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, username, name, email, phoneNumber, isBlock, role, action });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.Location = new Point(12, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Size = new Size(974, 550);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.DataPropertyName = "Id";
            id.FillWeight = 30F;
            id.HeaderText = "STT";
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // username
            // 
            username.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            username.DataPropertyName = "Username";
            username.HeaderText = "Mã nhân viên";
            username.Name = "username";
            username.ReadOnly = true;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.DataPropertyName = "Name";
            name.HeaderText = "Họ và tên";
            name.Name = "name";
            // 
            // email
            // 
            email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            email.DataPropertyName = "Email";
            email.HeaderText = "Email";
            email.Name = "email";
            // 
            // phoneNumber
            // 
            phoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            phoneNumber.DataPropertyName = "PhoneNumber";
            phoneNumber.HeaderText = "Số điện thoại";
            phoneNumber.Name = "phoneNumber";
            // 
            // isBlock
            // 
            isBlock.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            isBlock.DataPropertyName = "IsBlock";
            isBlock.FillWeight = 30F;
            isBlock.HeaderText = "Khóa";
            isBlock.Name = "isBlock";
            isBlock.Resizable = DataGridViewTriState.True;
            isBlock.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // role
            // 
            role.DataPropertyName = "Role";
            role.FillWeight = 50F;
            role.HeaderText = "Vai trò";
            role.Name = "role";
            // 
            // action
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = resources.GetObject("dataGridViewCellStyle5.NullValue");
            dataGridViewCellStyle5.Padding = new Padding(8);
            action.DefaultCellStyle = dataGridViewCellStyle5;
            action.HeaderText = "";
            action.Image = (Image)resources.GetObject("action.Image");
            action.ImageLayout = DataGridViewImageCellLayout.Zoom;
            action.Name = "action";
            action.Resizable = DataGridViewTriState.True;
            action.Width = 50;
            // 
            // createAccountButton
            // 
            createAccountButton.BackColor = Color.FromArgb(21, 128, 61);
            createAccountButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            createAccountButton.FlatAppearance.BorderSize = 2;
            createAccountButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createAccountButton.ForeColor = SystemColors.ButtonFace;
            createAccountButton.IconChar = FontAwesome.Sharp.IconChar.None;
            createAccountButton.IconColor = Color.Black;
            createAccountButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            createAccountButton.Location = new Point(907, 20);
            createAccountButton.Name = "createAccountButton";
            createAccountButton.Size = new Size(79, 29);
            createAccountButton.TabIndex = 1;
            createAccountButton.Text = "Mới";
            createAccountButton.UseVisualStyleBackColor = false;
            createAccountButton.Click += createAccountButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(12, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(173, 18);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Danh sách tài khoản";
            // 
            // searchTextbox
            // 
            searchTextbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchTextbox.Location = new Point(506, 24);
            searchTextbox.Name = "searchTextbox";
            searchTextbox.Size = new Size(231, 25);
            searchTextbox.TabIndex = 3;
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.Transparent;
            searchButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            searchButton.FlatAppearance.BorderSize = 2;
            searchButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchButton.ForeColor = Color.FromArgb(64, 64, 64);
            searchButton.IconChar = FontAwesome.Sharp.IconChar.None;
            searchButton.IconColor = Color.Black;
            searchButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            searchButton.Location = new Point(743, 21);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(79, 29);
            searchButton.TabIndex = 4;
            searchButton.Text = "Tìm";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // refershButton
            // 
            refershButton.BackColor = Color.Transparent;
            refershButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            refershButton.FlatAppearance.BorderSize = 2;
            refershButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refershButton.ForeColor = SystemColors.ActiveCaptionText;
            refershButton.IconChar = FontAwesome.Sharp.IconChar.None;
            refershButton.IconColor = Color.Black;
            refershButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            refershButton.Location = new Point(828, 20);
            refershButton.Name = "refershButton";
            refershButton.Size = new Size(79, 29);
            refershButton.TabIndex = 1;
            refershButton.Text = "Làm mới";
            refershButton.UseVisualStyleBackColor = false;
            refershButton.Click += refreshButton_Click;
            // 
            // AccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 243, 247);
            ClientSize = new Size(998, 617);
            Controls.Add(searchButton);
            Controls.Add(searchTextbox);
            Controls.Add(titleLabel);
            Controls.Add(refershButton);
            Controls.Add(createAccountButton);
            Controls.Add(dataGridView1);
            Name = "AccountForm";
            Text = "AccountForm";
            Load += AccountForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton createAccountButton;
        private Label titleLabel;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn username;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn phoneNumber;
        private DataGridViewCheckBoxColumn isBlock;
        private DataGridViewTextBoxColumn role;
        private DataGridViewImageColumn action;
        private TextBox searchTextbox;
        private FontAwesome.Sharp.IconButton searchButton;
        private FontAwesome.Sharp.IconButton refershButton;
    }
}